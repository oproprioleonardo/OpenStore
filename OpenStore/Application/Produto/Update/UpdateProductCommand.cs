namespace OpenStore.Application.Produto.Update
{
    public record UpdateProductCommand(
        long Id,
        string InternCode,
        string Description,
        string Unit,
        double Stock,
        decimal CostPrice,
        decimal RetailPrice,
        decimal WholesalePrice,
        double WholesaleQuantity
        )
    {

        public static UpdateProductCommand With(long id, string internCode, string description, string unit, double stock,
                       decimal costPrice, decimal retailPrice, decimal wholesalePrice, double wholesaleQuantity)
        {
            return new UpdateProductCommand(id, internCode, description, unit, stock, costPrice, retailPrice, wholesalePrice, wholesaleQuantity);
        }
    }
}
