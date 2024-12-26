using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IndentityServer
{
    public static class Config
    {
        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId = "movies_mvc_client",
                ClientName = "Movies MVC Web App",
                AllowedGrantTypes = GrantTypes.Hybrid,
                RequirePkce = false,
                AllowRememberConsent = false,
                RedirectUris = new List<string>()
                {
                    "https://localhost:5002/signin-oidc"
                },
                PostLogoutRedirectUris = new List<string>()
                {
                    "https://localhost:5002/signout-callback-oidc"
                },
                ClientSecrets =
                {
                    new Secret("secret".ToSha256())
                },
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Address,
                    IdentityServerConstants.StandardScopes.Email,
                    "movieAPI",
                    "roles"
                }
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("movieAPI","Movie API")
        };

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[] { };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Address(),
            new IdentityResources.Email(),
            new IdentityResource(
                "roles",
                "Your role(s)",
                new List<string>(){
                    "role"
                }),

        };

        public static List<TestUser> TestUsers => new List<TestUser>()
        {
            new TestUser
            {
                SubjectId = "4652067D-1887-491C-9A7C-CB632BDD60AD",
                Username = "vasim",
                Password = "vasim",
                Claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.GivenName, "Vasim"),
                    new Claim(JwtClaimTypes.FamilyName, "Sunni")
                }
            },
        };


        public static IdentityServer4.EntityFramework.Entities.Client ToClientEntity(this Client clientConfig)
        {
            if (clientConfig == null) throw new ArgumentNullException(nameof(clientConfig));

            return new IdentityServer4.EntityFramework.Entities.Client
            {
                Enabled = clientConfig.Enabled,
                ClientId = clientConfig.ClientId,
                ProtocolType = clientConfig.ProtocolType,
                ClientSecrets = clientConfig.ClientSecrets?
                    .Select(secret => new IdentityServer4.EntityFramework.Entities.ClientSecret
                    {
                        Value = secret.Value,
                        Type = secret.Type,
                        Description = secret.Description,
                        Expiration = secret.Expiration
                    })
                    .ToList(),
                RequireClientSecret = clientConfig.RequireClientSecret,
                ClientName = clientConfig.ClientName,
                Description = clientConfig.Description,
                ClientUri = clientConfig.ClientUri,
                LogoUri = clientConfig.LogoUri,
                RequireConsent = clientConfig.RequireConsent,
                AllowRememberConsent = clientConfig.AllowRememberConsent,
                AlwaysIncludeUserClaimsInIdToken = clientConfig.AlwaysIncludeUserClaimsInIdToken,
                AllowedGrantTypes = clientConfig.AllowedGrantTypes?
                    .Select(grantType => new IdentityServer4.EntityFramework.Entities.ClientGrantType { GrantType = grantType })
                    .ToList(),
                RequirePkce = clientConfig.RequirePkce,
                AllowPlainTextPkce = clientConfig.AllowPlainTextPkce,
                RequireRequestObject = clientConfig.RequireRequestObject,
                AllowAccessTokensViaBrowser = clientConfig.AllowAccessTokensViaBrowser,
                RedirectUris = clientConfig.RedirectUris?
                    .Select(uri => new IdentityServer4.EntityFramework.Entities.ClientRedirectUri { RedirectUri = uri })
                    .ToList(),
                PostLogoutRedirectUris = clientConfig.PostLogoutRedirectUris?
                    .Select(uri => new IdentityServer4.EntityFramework.Entities.ClientPostLogoutRedirectUri { PostLogoutRedirectUri = uri })
                    .ToList(),
                FrontChannelLogoutUri = clientConfig.FrontChannelLogoutUri,
                FrontChannelLogoutSessionRequired = clientConfig.FrontChannelLogoutSessionRequired,
                BackChannelLogoutUri = clientConfig.BackChannelLogoutUri,
                BackChannelLogoutSessionRequired = clientConfig.BackChannelLogoutSessionRequired,
                AllowOfflineAccess = clientConfig.AllowOfflineAccess,
                AllowedScopes = clientConfig.AllowedScopes?
                    .Select(scope => new IdentityServer4.EntityFramework.Entities.ClientScope { Scope = scope })
                    .ToList(),
                IdentityTokenLifetime = clientConfig.IdentityTokenLifetime,
                AllowedIdentityTokenSigningAlgorithms = clientConfig.AllowedIdentityTokenSigningAlgorithms.FirstOrDefault(),
                AccessTokenLifetime = clientConfig.AccessTokenLifetime,
                AuthorizationCodeLifetime = clientConfig.AuthorizationCodeLifetime,
                ConsentLifetime = clientConfig.ConsentLifetime,
                AbsoluteRefreshTokenLifetime = clientConfig.AbsoluteRefreshTokenLifetime,
                SlidingRefreshTokenLifetime = clientConfig.SlidingRefreshTokenLifetime,
                UpdateAccessTokenClaimsOnRefresh = clientConfig.UpdateAccessTokenClaimsOnRefresh,
                EnableLocalLogin = clientConfig.EnableLocalLogin,
                IdentityProviderRestrictions = clientConfig.IdentityProviderRestrictions?
                    .Select(restriction => new IdentityServer4.EntityFramework.Entities.ClientIdPRestriction { Provider = restriction })
                    .ToList(),
                IncludeJwtId = clientConfig.IncludeJwtId,
                Claims = clientConfig.Claims?
                    .Select(claim => new IdentityServer4.EntityFramework.Entities.ClientClaim { Type = claim.Type, Value = claim.Value })
                    .ToList(),
                AlwaysSendClientClaims = clientConfig.AlwaysSendClientClaims,
                ClientClaimsPrefix = clientConfig.ClientClaimsPrefix,
                PairWiseSubjectSalt = clientConfig.PairWiseSubjectSalt,
                AllowedCorsOrigins = clientConfig.AllowedCorsOrigins?
                    .Select(origin => new IdentityServer4.EntityFramework.Entities.ClientCorsOrigin { Origin = origin })
                    .ToList(),
                Properties = clientConfig.Properties?
                    .Select(property => new IdentityServer4.EntityFramework.Entities.ClientProperty { Key = property.Key, Value = property.Value })
                    .ToList(),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                LastAccessed = DateTime.UtcNow,
                UserSsoLifetime = clientConfig.UserSsoLifetime,
                UserCodeType = clientConfig.UserCodeType,
                DeviceCodeLifetime = clientConfig.DeviceCodeLifetime,
                NonEditable = false,
            };
        }


        public static IdentityServer4.EntityFramework.Entities.IdentityResource ToIdentityResounseEntity(this IdentityResource entity)
        {
            return new IdentityServer4.EntityFramework.Entities.IdentityResource
            {
                Name = entity.Name,
                DisplayName = entity.DisplayName,
                Description = entity.Description,
                Required = entity.Required,
                Emphasize = entity.Emphasize,
                ShowInDiscoveryDocument = entity.ShowInDiscoveryDocument,
                Enabled = true,
                Created=DateTime.UtcNow,
                Updated=DateTime.UtcNow,
                NonEditable = false
            };
        }

        public static IdentityServer4.EntityFramework.Entities.ApiScope ToApiScopeEntity(this ApiScope apiScope)
        {
            return new IdentityServer4.EntityFramework.Entities.ApiScope
            {
                Name = apiScope.Name,
                DisplayName = apiScope.DisplayName,
                Description = apiScope.Description,
                Required = apiScope.Required,
                Emphasize = apiScope.Emphasize,
                ShowInDiscoveryDocument = apiScope.ShowInDiscoveryDocument,
            };
        }
    }
}
