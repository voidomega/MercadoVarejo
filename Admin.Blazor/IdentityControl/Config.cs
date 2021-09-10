// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Linq;

namespace IdentityControl
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()                
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {                
                new ApiScope("mvapi","Mercado Varejo API")
                //new ApiScope("MercadoVarejoApi")                
            };


        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]{
                new ApiResource()
                {
                   Name = "mvapi", 
                    DisplayName ="Mercado Varejo API",
                    Scopes = new []{ "mvapi" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "blazorMercadoVarejo",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,                    
                    RequireClientSecret = false,
                    ClientSecrets={                        
                        new Secret("@xinBUGolg(1z".Sha512())
                    },
                    AllowedCorsOrigins = { "https://localhost:44366" },
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile, "mvapi" },
                    
                    RedirectUris = { "https://localhost:44366/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:44366/signout-callback-oidc" },
                    Enabled = true,
                    AllowOfflineAccess = true
                },

                new Client
                {
                    ClientId = "blazorMercadoVarejoCliApi",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,                                        
                    ClientSecrets =
                    {
                        //"@xinBUGolg(1z".Sha256()
                        new Secret("@xinBUGolg(1z".Sha512())
                    },
                    AllowedScopes = { "mvapi" }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,


                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "scope1", "scope2" }
                },
            };
    }
}