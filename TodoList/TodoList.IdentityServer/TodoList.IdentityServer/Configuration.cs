using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace TodoList.IdentityServer
{
    public class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("TodoListWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("TodoListWebAPI", "Web API", new [] {JwtClaimTypes.Name})
                {
                    Scopes = { "TodoListWebAPI" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "todo-list-web-api",
                    ClientName = "Todo List Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "https://.../signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "https://..."
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://.../signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "TodoListWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true,
                }
            };
    }
}
