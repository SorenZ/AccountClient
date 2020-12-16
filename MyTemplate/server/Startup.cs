using System;
using System.Collections.Generic;
using System.Text;
using DotNetify;
using DotNetify.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MyTemplate.server.Config;
using MyTemplate.server.Helpers;
using MyTemplate.server.Queue;
using MyTemplate.server.Services;
using Xero.NetStandard.OAuth2.Api;
using Xero.NetStandard.OAuth2.Config;

namespace MyTemplate.server
{
   public class Startup
   {
      
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }
      
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddHttpClient();
         // Add OpenID Connect server to produce JWT access tokens.
         services.AddAuthenticationServer();

         services.AddSignalR();
         services.AddDotNetify();
         services.Configure<XeroConfiguration>(Configuration.GetSection("XeroConfiguration"));
         services.AddTransient<ILiveDataService, MockLiveDataService>();
         services.AddSingleton<IEmployeeService, XeroEmployeeService>();
         services.TryAddSingleton<IAccountingApi, AccountingApi>();
         
         services.TryAddSingleton(Configuration.GetSection("PayloadQueueSettings").Get<PayloadQueueSettings>());
         services.TryAddSingleton(Configuration.GetSection("WebhookSettings").Get<WebhookSettings>());
         services.TryAddSingleton(Configuration.GetSection("XeroConfiguration").Get<XeroConfiguration>());

         services.TryAddTransient<IQueue<string>, PayloadQueue>();
         services.TryAddSingleton<ISignatureVerifier, SignatureVerifier>();
      }

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         app.UseAuthentication();

         app.UseWebSockets();
         app.UseDotNetify(config =>
         {
            // Middleware to do authenticate token in incoming request headers.
            config.UseJwtBearerAuthentication(new TokenValidationParameters
            {
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthServer.SecretKey)),
               ValidateIssuerSigningKey = true,
               ValidateAudience = false,
               ValidateIssuer = false,
               ValidateLifetime = true,
               ClockSkew = TimeSpan.FromSeconds(0)
            });

            // Filter to check whether user has permission to access view models with [Authorize] attribute.
            // config.UseFilter<AuthorizeFilter>();
            // config.Register<ContactVm>();
         });

         if (env.IsDevelopment())
         {
#pragma warning disable CS0618
            app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
            {
               HotModuleReplacement = true,
               HotModuleReplacementClientOptions = new Dictionary<string, string> { { "reload", "true" } },
            });
#pragma warning restore CS0618
         }

         app.UseFileServer();
         app.UseRouting();
         app.UseEndpoints(endpoints =>
         {
            endpoints.MapHub<DotNetifyHub>("/dotnetify");
            endpoints.MapControllers();
            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            // endpoints.MapFallbackToFile("index.html");
         });
      }
   }
}