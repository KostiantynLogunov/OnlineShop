// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("OnlineShop.Api"), // for services communication
                new ApiScope("OnlineShop.Web"), // for users which use web interface
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // test.client for service communication
                new Client
                {
                    ClientId = "test.client",
                    ClientName = "Test client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = 
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "OnlineShop.Api",
                        "OnlineShop.Web",
                    }
                },

                // External client for users which enter by login and password
                new Client
                {
                    ClientId = "external",
                    ClientName = "External client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword, // the setting 
                    RequireClientSecret = false,

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "OnlineShop.Web",
                    }
                },
            };
    }
}