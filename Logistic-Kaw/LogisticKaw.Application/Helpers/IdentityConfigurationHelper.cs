using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace LogisticKaw.Application.Helpers
{
    public static class IdentityConfigurationHelper
    {


        /// <summary>
        /// Created test user to use in this project demonstration.
        /// </summary>
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1144",
                    Username = "filipe",
                    Password = "123456",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Filipe Maia"),
                        new Claim(JwtClaimTypes.GivenName, "Filipe"),
                        new Claim(JwtClaimTypes.FamilyName, "Maia"),
                        new Claim(JwtClaimTypes.WebSite, "https://github.com/nulzhar/")
                    }                    
                }
            };

        /// <summary>
        /// Set up the resources available on Identity Server.
        /// </summary>
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        /// <summary>
        /// Set up api scopes to specify what the user could our not do.
        /// </summary>
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi.read"),
                new ApiScope("myApi.write"),
                //new ApiScope(IdentityServerConstants.StandardScopes.OpenId)
            };

        /// <summary>
        /// Set up api resources with scopes supported and the api secret that uses Sha256.
        /// </summary>
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("myApi")
                {
                    Scopes = new List<string> { "myApi.read", "myApi.write"},
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256())},
                    UserClaims = new [] { "custom_claim" }
                },
            };

        /// <summary>
        /// Set up the client and the interaction way
        /// </summary>
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "cwm.client",
                    ClientName = "Client Credentials Client",
                    //AllowedGrantTypes = GrantTypes.ClientCredentials,
                    //http://docs.identityserver.io/en/latest/topics/grant_types.html
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedScopes = {
                        "myApi.read",
                        "roles",
                        "openid",
                        "profile"
                    },

                }
            };
    }
}
