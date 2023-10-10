using OpenStore.Domain.Contexts.Produto;

namespace OpenStore.Infra.Produto.Persistence
{
    public class ProductEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string InternCode { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public double Stock { get; set; }
        public decimal CostPrice { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal WholesalePrice { get; set; }
        public double WholesaleQuantity { get; set; }
        public bool IsActive { get; set; }

        public ProductEntity()
        {
            Code = "";
            InternCode = "";
            Description = "";
            Unit = ProductUnit.INDETERMINADO.ToString();
        }

        public ProductEntity(long Id, string code, string internCode, string description, string unit, double stock,
                       decimal costPrice, decimal retailPrice, decimal wholesalePrice, double wholesaleQuantity, bool isActive)
        {
            this.Id = Id;
            Code = code;
            InternCode = internCode;
            Description = description;
            Unit = unit;
            Stock = stock;
            CostPrice = costPrice;
            RetailPrice = retailPrice;
            WholesalePrice = wholesalePrice;
            WholesaleQuantity = wholesaleQuantity;
            IsActive = isActive;
        }

        public static ProductEntity From(Product produto)
        {
            return new ProductEntity(
                produto.Id,
                produto.Code,
                produto.InternCode,
                produto.Description,
                produto.ProductUnit.ToString(),
                produto.Stock,
                produto.CostPrice,
                produto.RetailPrice,
                produto.WholesalePrice,
                produto.WholesaleQuantity,
                produto.IsActive
                );
        }

        public Product ToDomain()
        {
            return new Product(
                Id,
                Code,
                InternCode,
                Description,
                (ProductUnit)Enum.Parse(typeof(ProductUnit), Unit),
                Stock,
                CostPrice,
                RetailPrice,
                WholesalePrice,
                WholesaleQuantity,
                IsActive
            );
        }


    }
}
