using OpenStore.Domain.Contexts.Produto;

namespace OpenStore.Application.Produto.List
{
    public record ListProductOutput(
        long Id,
        string Code,
        string InternCode,
        string Description,
        string Unit,
        decimal RetailPrice,
        double Stock
        )
    {

        public static ListProductOutput From(Product product)
        {
            return new ListProductOutput(
                product.Id,
                product.Code,
                product.InternCode,
                product.Description,
                product.ProductUnit.ToString(),
                product.RetailPrice,
                product.Stock);
        }
    }
}
