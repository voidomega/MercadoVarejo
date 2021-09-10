using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ma.Util.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;
//using Ma.MercadoAssistente.Api.Contexto;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using IdentityServer4.AccessTokenValidation;
using Microsoft.IdentityModel.Tokens;
using IdentityModel;
using Ma.MercadoAssistente.Api.Contexto;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Net;

namespace Sa2s.DicionarioDados.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            StartupUtil.AppTitle = Assembly.GetEntryAssembly().GetName().Name;

            StartupUtil.AppVersion = "v2";
            StartupUtil.RouteTemplateName = "dataswagger";
        }

        public IConfiguration Configuration { get; }


        const string MinhasOrigens = "_origens";

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {

            IdentityModelEventSource.ShowPII = true;

            services.AddControllers().AddNewtonsoftJson();
            // options => {options.AllowInputFormatterExceptionMessages = false;});

            //services.AddAuthorization();

            //services.AddAuthorization();
            //options =>
            //{
            //    options.AddPolicy("ApiScope", policy =>
            //    {
            //        policy.RequireAuthenticatedUser();
            //        policy.RequireClaim("mvapi");
            //    });
            //});

            
            //////services.AddAuthentication("Bearer")
            //////    .AddJwtBearer("Bearer", options =>
            //////    {
            //////        options.RequireHttpsMetadata = false;
            //////        options.Audience = "mvapi";
            //////        options.Authority = "https://is4.celersupermer.tk"; //"https://localhost:5000";
                    
                    
            //////        options.TokenValidationParameters = new TokenValidationParameters
            //////        {
            //////            ValidateAudience = false                        
            //////        };
            //////        options.Configuration = new OpenIdConnectConfiguration();

            //////    });

            //////ServicePointManager.Expect100Continue = true;
            //////ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
            //////| SecurityProtocolType.Tls11
            //////| SecurityProtocolType.Tls12;
            ////////| SecurityProtocolType.Ssl3;

            //////services.AddAuthorization(options =>
            //////{
            //////    options.AddPolicy("mvapi", policy =>
            //////    {
            //////        policy.RequireClaim(JwtClaimTypes.ClientId);
            //////    });
            //////});






            // services.AddDbContext<CnxContext>(options => options.UseInMemoryDatabase(databaseName: "ConnectionsDB"));
            //////services.AddCors(options =>
            //////{
            //////    options.AddPolicy(MinhasOrigens,
            //////    builder =>
            //////    {
            //////        // "https://celersupermer.tk","https://localhost:44366"
            //////        builder.WithOrigins().AllowCredentials().AllowAnyHeader().WithMethods("GET, PATCH, DELETE, PUT, POST, OPTIONS");
            //////        //.AllowAnyMethod();//""

            //////        //builder.WithOrigins().AllowCredentials().AllowAnyHeader().AllowAnyMethod();
            //////        //"https://celersupermer.tk",
            //////        //builder.AllowAnyHeader().AllowAnyMethod();
            //////    });
            //////});

            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //ConnectionParams.ServerType = Configuration.GetValue<string>("BOSERVERTYPE");
            //ConnectionParams.AutoCreateContext = Configuration.GetValue<Boolean>("BOAUTOCONTEXT");
            //ConnectionParams.DevConnectionString = Configuration.GetValue<string>("BODEVCONNECTIONSTRING");


            //// define a leitura da string de conexao via appSettings.json
            //ConnectionParams.GetDataFromLocalCfg = true;


            MakeContextOptions.AddDbContextPool(services);


          

            //    options => options.EnableEndpointRouting = false)
            //.AddJsonOptions(options => {

            //     options.JsonSerializerOptions.MaxDepth = 1;
            //     options.JsonSerializerOptions.IgnoreNullValues = true;
            // });




            StartupUtil​.AddSwaggerGen(services);
            StartupUtil​.AddJsonOptions(services);

          //  var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
          //  var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);


            //services.AddHttpsRedirection(Options => {                
            //     Options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            //     Options.HttpsPort = 5011;
            //});

          //  services.AddSwaggerGen(c => c.IncludeXmlComments(xmlPath));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //  CallHttp();          


            string contentRootPath = Directory.GetCurrentDirectory();

           // contentRootPath = Path.Combine(contentRootPath, @"bin/Debug/netcoreapp2.2/");

            var configurationBuilder = new ConfigurationBuilder()
                                 .SetBasePath(contentRootPath)
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                 .AddEnvironmentVariables();


            var customConfiguration = configurationBuilder.Build();



            //ConnectionParams.UserName = customConfiguration.GetValue<string>("BOUSERNAME");
            // ConnectionParams.Password = customConfiguration.GetValue<string>("BOPASSWORD");
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            

            ///app.UseCors(MinhasOrigens);
            app.UseHttpsRedirection();
            

            app.UseRouting();

            //////app.UseAuthentication();
            app.UseAuthorization();
            
           // StartupUtil.AddUseSwaggerUi(app);


            //app.UseMvc();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
               /// .RequireAuthorization("mvapi");
            });


        }

        private async Task<string> CallHttp()
        {
        
            HttpClient httpClient = new HttpClient();

            DataSend dataSend = new DataSend()
            {
                IdConexao = 3605,
                DsChave = "31200312509035000130650010000438021004542205"
            };


            var lstForm = new List<KeyValuePair<string, string>>();

           // lstForm.Add(new KeyValuePair<string, string>("IdConexao", dataSend.IdConexao.ToString()));            
          //  lstForm.Add(new KeyValuePair<string, string>("DsChave", dataSend.DsChave));

            var content = new FormUrlEncodedContent(lstForm);



            // using (StringContent strcontent = CreateJsonStringContent(dataSend))
            // {

            ////?IdConexao=3605&DsChave=31200312509035000130650010000438021004542205
            using (var response = await httpClient.PostAsync(
                "http://189.1.170.180/Conexao/ObterDanfe?IdConexao=3605&DsChave=31200312509035000130650010000438021004542205", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<string>(apiResponse);
                }
           // }

        }

        private StringContent CreateJsonStringContent(Object Data)
        {
            return new StringContent(JsonConvert.SerializeObject(Data), Encoding.UTF8, "application/json");
        }
    }

    public class DataSend
    {
        public Int32 IdConexao {get; set;}
        public string DsChave {get; set; }        
    }
}
