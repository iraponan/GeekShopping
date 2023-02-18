using Duende.IdentityServer.Models;

namespace GeekShopping.IdentityServer.Configuration {
    public static class IdentityConfiguration {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> identityResources => new List<IdentityResource> {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> apiScopes => new List<ApiScope> {
            new ApiScope("geek_shopping", "GeekShopping Server"),
            new ApiScope("read", "Read data."),
            new ApiScope("write", "Write data."),
            new ApiScope("delete", "Delete data.")
        };

        public static IEnumerable<Client> clients => new List<Client> {
            new Client {
                ClientId = "client",
                ClientSecrets = {
                    new Secret("my_super_secret".Sha256())
                },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {
                    "read",
                    "write",
                    "profile"
                }
            }
        };
    }
}
