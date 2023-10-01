namespace OpenStore.Infra.Produto.Models
{
    public record ListProductResponse(
        long Id,
        string Code,
        string InternCode,
        string Description,
        string Unit,
        double Stock,
        decimal RetailPrice)
    {
    }
}
