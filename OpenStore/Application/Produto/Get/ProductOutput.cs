using OpenStore.Domain.Contexts.Produto;

namespace OpenStore.Application.Produto.Get
{
    public record ProductOutput(
        long Id,
        string Code,
        string InternCode,
        string Description,
        string Unit,
        double Stock,
        decimal CostPrice,
        decimal RetailPrice,
        decimal WholesalePrice,
        double WholesaleQuantity,
        bool IsActive
        )
    {

        public static ProductOutput From(Product product)
        {
            return new ProductOutput(
                product.Id,
                product.Code,
                product.InternCode,
                product.Description,
                product.ProductUnit.ToString(),
                product.Stock,
                product.CostPrice,
                product.RetailPrice,
                product.WholesalePrice,
                product.WholesaleQuantity,
                product.IsActive);
        }

    }
}
