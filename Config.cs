// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using static IdentityServer4.IdentityServerConstants;

namespace Identity.Api
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
                };
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
                {
                     new ApiResource("pruebaAPI", "Prueba API",new [] { JwtClaimTypes.Role })
                };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("pruebaAPI")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "pruebaClient",
                    RequirePkce = true,
                    Enabled = true,
                    ClientName = "Client Credentials Client",
                    UpdateAccessTokenClaimsOnRefresh = true,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedScopes = { StandardScopes.OpenId, StandardScopes.Profile ,"pruebaAPI" }
                }                
            };
    }
}