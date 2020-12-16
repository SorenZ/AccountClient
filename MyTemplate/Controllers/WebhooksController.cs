using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyTemplate.server.Dto;
using MyTemplate.server.Helpers;
using MyTemplate.server.Queue;
using MyTemplate.server.Services;
using Newtonsoft.Json;

namespace MyTemplate.Controllers
{
    [Route("webhooks")]
    [AllowAnonymous]
    public class WebhooksController : ControllerBase
    {
        private readonly ISignatureVerifier _signatureVerifier;
        private readonly ILogger<WebhooksController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly ContactObservable _contactObservable;

        public WebhooksController(IQueue<string> payloadQueue, 
            ISignatureVerifier signatureVerifier, 
            ILogger<WebhooksController> logger,
            IEmployeeService employeeService, 
            ILiveDataService service)
        {
            _signatureVerifier = signatureVerifier;
            _logger = logger;
            _employeeService = employeeService;
            _contactObservable = service.RecentActivity as ContactObservable;

        }

        // for test scenarios 
        [HttpGet]
        public IActionResult Get()
        {
            // _employeeService.Add(new EmployeeModel()
            // {
            //     Id = 10,
            //     FirstName = "Mohammad",
            //     LastName = "Najafi",
            //     ContactId = Guid.Parse("92dcb214-f16c-44f7-bae7-3a5db9ebe9c7")
            // });
            
            _contactObservable.AddActivity(
                new Activity
                {
                    Id = 10,
                    PersonName = "Mohammad Najafi",
                    Status =  "new"
                });
        
            return Ok();
        }
        

        [HttpPost]
        public IActionResult Post()
        {
            var payload = ReadPayload();
            _logger.LogInformation("Received a webhook");

            var signatureHeader = Request.Headers["x-xero-signature"].FirstOrDefault();

            _logger.LogInformation("Verifying the signature to confirm that the payload is from Xero.");
            var isValid = _signatureVerifier.VerifySignature(payload, signatureHeader);

            if (!isValid)
            {
                _logger.LogWarning("The signature is incorrect. Responding with HTTP 401 Unauthorised.");
                return Unauthorized();
            }

            _logger.LogInformation("The signature is correct. Saving the payload for processing later (so that we can respond as quickly as possible).");

            if (!payload.Contains("resourceId")) // hand-shake 
                return Ok();
            
            // _payloadQueue.Enqueue(payload);
            // var update = JsonConvert.DeserializeXNode(payload);

            var objectToUpdate = JsonConvert.DeserializeObject<Payload>(payload);


            var @event = objectToUpdate.Events.FirstOrDefault();

            if (@event != null)
                return Ok();

            var model = new EmployeeModel {ContactId = @event.ResourceId};


            switch (@event.EventType)
                {
                    case "UPDATE":
                        _employeeService.Update(model);
                        break;
                    case "ADD":
                        _employeeService.Add(model);
                        break;
                }
            
            _contactObservable.AddActivity(
                new Activity
                {
                    Id = model.Id,
                    PersonName = model.FullName,
                    Status =  @event.EventType
                });

            _logger.LogInformation("Webhook is saved. Returning an empty 200 OK");
            return Ok();
        }

        private string ReadPayload()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                return reader.ReadToEndAsync().Result;
            }
        }

    }
}
