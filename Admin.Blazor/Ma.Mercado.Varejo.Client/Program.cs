using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using IdentityModel.Client;
using IdentityModel;
using Blazored.SessionStorage;
using Ma.Mercado.Varejo.Client.Classes;
using Syncfusion.Blazor;
using System.IO;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.ComponentModel;
using Ma.Mercado.Varejo.Client;

namespace Ma.Mercado.Varejo.Client
{
    public class Program
    {

        
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);           
            builder.RootComponents.Add<App>("app");


            if (Constants.RunIs4Client)
            {

                var client = new HttpClient();
                var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5000/");
                if (disco.IsError)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Não foi possível acessar o ID4" + disco.Error);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("==========================================================================");
                    Console.WriteLine("");
                    // return;
                }

                if (!disco.IsError)
                {
                    Constants.GlobalToken = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                    {
                        Address = disco.TokenEndpoint,
                        ClientId = "blazorMercadoVarejoCliApi",
                        ClientSecret = "@xinBUGolg(1z",
                        Scope = "mvapi"
                    });

                    if (Constants.GlobalToken.IsError)
                    {
                        Console.WriteLine("error GlobalToken: " + Constants.GlobalToken.Error);
                        Console.WriteLine("==========================================================================");
                        Environment.Exit(2);
                    }

                    Console.WriteLine(Constants.GlobalToken.Json);


                }

            }

            

            builder.Services.AddOidcAuthentication(options =>
            {
                
                options.ProviderOptions.Authority = "https://is4.celersupermer.tk";//"https://localhost:5000/";

                options.ProviderOptions.ClientId = "blazorMercadoVarejo";
                options.ProviderOptions.ResponseType = "code";                

                options.ProviderOptions.DefaultScopes.Add("openid");
                options.ProviderOptions.DefaultScopes.Add("profile");
                options.ProviderOptions.DefaultScopes.Add("mvapi");

                //options.ProviderOptions.DefaultScopes.Add("scope1");
                //options.ProviderOptions.DefaultScopes.Add("scope2");

                //options.ProviderOptions.DefaultScopes.Add("api");
                // Configure your authentication provider options here.
                // For more information, see https://aka.ms/blazor-standalone-auth
                //builder.Configuration.Bind("Local", options.ProviderOptions);
                //builder.Configuration.Bind("oidc", options.ProviderOptions.);
                //builder.Configuration.Bind("oidc", options.ProviderOptions);
            });

            builder.Services.AddScoped(sp => new HttpClient {  BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //Uri("http://localhost:5040/api/") 
            // "http://localhost:5040" ,

            builder.Services.AddHttpClient("api",
                client => client.BaseAddress = new Uri("https://localhost:2443/api/") //"https://api.celersupermer.tk/api/");  ; // //
                );
            //.AddHttpMessageHandler(sp =>
            //{
            //    var handler = sp.GetService<AuthorizationMessageHandler>()

            //        .ConfigureHandler(
            //            authorizedUrls: new[] { "https://localhost:2443" },                            
            //            scopes: new[] { "mvapi" });
            //    return handler;
            //});

            builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("api"));

            builder.Services.AddSyncfusionBlazor();
            await builder.Build().RunAsync();
        }

        //public static string ToLiteral(string input)
        //{
        //    using (var writer = new StringWriter())
        //    {
        //        using (var provider = CodeDomProvider.CreateProvider("CSharp"))
        //        {
        //            provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
        //            return writer.ToString();
        //        }
        //    }
        //}
    }
   
}
