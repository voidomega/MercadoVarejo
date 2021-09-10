// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityControl.Data;
using IdentityControl.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IdentityServer4.Models;
using System.Security.Cryptography.X509Certificates;

namespace IdentityControl
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            MercadoAssistente.Data.Layer.Context.MakeContextOptions.AddDbContextPool(services);

            SeedData.EnsureSeedData(Configuration.GetConnectionString("DefaultConnection"));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })
                //.AddDeveloperSigningCredential(true, "D:\\certs.ByteON\\dev.cert.pfx")
                .AddSigningCredential(new X509Certificate2("/app/certs/sa2s.b.certificate.pfx", "40##paocomovoBATATAFrango20@@"))
                .AddInMemoryIdentityResources(Config.IdentityResources)                                
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients)
                .AddAspNetIdentity<ApplicationUser>();

            //.AddSigningCredential(new X509Certificate2("D:\\certs.ByteON\\sa2s.b.certificate.pfx", "40##paocomovoBATATAFrango20@@"))



            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            services.AddAuthentication();

                ////.AddGoogle(options =>
                ////{
                ////    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    
                ////    // register your IdentityServer with Google at https://console.developers.google.com
                ////    // enable the Google+ API
                ////    // set the redirect URI to https://localhost:5001/signin-google
                ////    options.ClientId = "copy client ID from Google here";
                ////    options.ClientSecret = "copy client secret from Google here";
                ////});
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }


            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}