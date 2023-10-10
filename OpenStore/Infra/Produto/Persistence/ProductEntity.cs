using Newtonsoft.Json;
using OpenStore.Domain.Contexts.Produto;

namespace OpenStore.Infra.Produto.Persistence
{

    [JsonObject]
    public class ProductEntity
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("internCode")]
        public string InternCode { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("unit")]
        public string Unit { get; set; }
        [JsonProperty("stock")]
        public double Stock { get; set; }
        [JsonProperty("costPrice")]
        public decimal CostPrice { get; set; }
        [JsonProperty("retailPrice")]
        public decimal RetailPrice { get; set; }
        [JsonProperty("wholesalePrice")]
        public decimal WholesalePrice { get; set; }
        [JsonProperty("wholesaleQuantity")]
        public double WholesaleQuantity { get; set; }
        [JsonProperty("isActive")]
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
