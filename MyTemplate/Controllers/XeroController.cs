using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using mytemplate;
using Xero.NetStandard.OAuth2.Client;
using Xero.NetStandard.OAuth2.Config;
using Xero.NetStandard.OAuth2.Models;

namespace MyTemplate.Controllers
{
    [AllowAnonymous]
    public class XeroController : Controller
    {
        private readonly ILogger<XeroController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<XeroConfiguration> XeroConfig;

        public XeroController(IOptions<XeroConfiguration> config, ILogger<XeroController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            this.XeroConfig = config;
        }

        public IActionResult Index()
        {
            var xconfig = new XeroConfiguration();
            xconfig.ClientId = "713B16BE2997493E8F3F37AD00400F25";
            xconfig.ClientSecret = "GCu6vvrQ6HFgzWKsOAysK2Q78rtQW_jB_V97sKbGvulKuhib";
            xconfig.CallbackUri = new Uri("http://localhost:5000/signin-oidc"); //default for standard webapi template
            xconfig.Scope = "openid profile email offline_access files accounting.transactions accounting.contacts";

            var client = new XeroClient(xconfig, _httpClientFactory);

            return Redirect(client.BuildLoginUri());
        }
        
        [Route("signin-oidc")]
        public async Task<IActionResult> CallBack(string code, string session_state)
        {
            XeroConfiguration xconfig = new XeroConfiguration(); 
    
            xconfig.ClientId = "713B16BE2997493E8F3F37AD00400F25";
            xconfig.ClientSecret = "GCu6vvrQ6HFgzWKsOAysK2Q78rtQW_jB_V97sKbGvulKuhib";
            xconfig.CallbackUri = new Uri("http://localhost:5000/signin-oidc"); //default for standard webapi template
            xconfig.Scope = "openid profile email files accounting.transactions accounting.contacts offline_access accounting.contacts.read";
	
            var client = new XeroClient(xconfig, _httpClientFactory);
	
            //before getting the access token please check that the state matches
            var token = await client.RequestAccessTokenAsync(code);

            XeroEmployeeService.Token = token;
            XeroEmployeeService.Client = client;
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