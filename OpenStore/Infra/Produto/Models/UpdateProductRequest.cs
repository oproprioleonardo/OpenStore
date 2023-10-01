namespace OpenStore.Infra.Produto.Models
{
    public record UpdateProductRequest(
        string Code,
        string InternCode,
        string Description,
        char Unit,
        double Stock,
        decimal CostPrice,
        decimal RetailPrice,
        decimal WholesalePrice,
        double WholesaleQuantity
        )
    {
    }
}
