using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyTemplate.server.Services;
using Xero.NetStandard.OAuth2.Client;
using Xero.NetStandard.OAuth2.Config;
using Xero.NetStandard.OAuth2.Token;

namespace MyTemplate.Controllers
{
    [AllowAnonymous]
    public class XeroController : Controller
    {
        private readonly ILogger<XeroController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly XeroConfiguration _xeroConfig;

        public XeroController(IOptions<XeroConfiguration> config, ILogger<XeroController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _xeroConfig = config.Value;
        }

        public IActionResult Index()
        {
            
            var client = new XeroClient(_xeroConfig, _httpClientFactory);

            return Redirect(client.BuildLoginUri());
        }
        
        [Route("signin-oidc")]
        public async Task<IActionResult> CallBack(string code, string sessionState)
        {
            
            var client = new XeroClient(_xeroConfig, _httpClientFactory);
	
            //before getting the access token please check that the state matches
            IXeroToken token = null;
            try
            {
                token = await client.RequestAccessTokenAsync(code);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,ex);
                ViewData["Message"] = ex.Message;
                return View("Error"); 
            }
            
            XeroEmployeeService.Token = token;
            XeroEmployeeService.XeroClient = client;
            
            // //from here you will need to access your Xero Tenants
            // List<Tenant> tenants = await client.GetConnectionsAsync(token);
            //
            // // you will now have the tenant id and access token
            // foreach (Tenant tenant in tenants)
            // {
            //     // do something with your tenant and access token
            //     //client.AccessToken;
            //     //tenant.TenantId;
            // }

            return Redirect("index.html");    
        }
    }
}