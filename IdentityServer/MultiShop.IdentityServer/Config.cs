using Duende.IdentityServer.Models;

namespace MultiShop.IdentityServer;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]{
        new ApiResource("ResourceCatalog") { Scopes ={ "CatalogFullPermission","CatalogReadPermission"}},
        new ApiResource("ResourceDiscount") { Scopes ={ "DiscountFullPermission","DiscountReadPermission"}},
        new ApiResource("ResourceOrder") { Scopes ={ "OrderFullPermission","OrderReadPermission"}}
    };
    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]{
       new IdentityResources.OpenId(),
       new IdentityResources.Email(),
       new IdentityResources.Profile()
    };

    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]{
        new ApiScope("CatalogFullPermission","Full authority for catolog operations"),
        new ApiScope("CatalogReadPermission","Reading authority for catolog operations"),
        new ApiScope("DiscountFullPermission","Full authority for Discount operations"),
        new ApiScope("DiscountReadPermission","Reading authority for Discount operations"),
        new ApiScope("OrderFullPermission","Full authority for order operations"),
        new ApiScope("OrderReadPermission","Reading authority for order operations")
    };
}
