using OpenStore.Domain.Shared.Validation;

namespace OpenStore.Domain.Contexts.Produto
{
    public class Product
    {
        private long _id;

        public Product()
        {
            Code = "";
            InternCode = "";
            Description = "";
            ProductUnit = ProductUnit.INDETERMINADO;
        }

        public long Id
        {
            get => _id;
            set => _id = value;
        }

        public Product(long id, string code, string internCode, string description, ProductUnit productUnit, double stock,
            decimal costPrice, decimal retailPrice, decimal wholesalePrice, double wholesaleQuantity, bool isActive)
        {
            Id = id;
            Code = code;
            InternCode = internCode;
            Description = description;
            ProductUnit = productUnit;
            Stock = stock;
            CostPrice = costPrice;
            RetailPrice = retailPrice;
            WholesalePrice = wholesalePrice;
            WholesaleQuantity = wholesaleQuantity;
            IsActive = isActive;
        }

        public static Product NewProduct(string code, string? internCode, string description, ProductUnit productUnit,
            double stock, decimal costPrice, decimal retailPrice, decimal wholesalePrice, double wholesaleQuantity)
        {
            return new Product(
                0,
                code,
                internCode ?? "",
                description,
                productUnit,
                stock,
                costPrice,
                retailPrice,
                wholesalePrice,
                wholesaleQuantity,
                true
            );
        }

        public void UpdateProduct(
            string? internCode, string description, ProductUnit productUnit,
            double stock, decimal costPrice, decimal retailPrice, decimal wholesalePrice, double wholesaleQuantity)
        {
            InternCode = internCode ?? "";
            Description = description;
            ProductUnit = productUnit;
            Stock = stock;
            CostPrice = costPrice;
            RetailPrice = retailPrice;
            WholesalePrice = wholesalePrice;
            WholesaleQuantity = wholesaleQuantity;
        }

        public string Code { get; private set; }

        public string InternCode { get; private set; }

        public string Description { get; private set; }

        public ProductUnit ProductUnit { get; private set; }

        public double Stock { get; private set; }

        public decimal CostPrice { get; private set; }

        public decimal RetailPrice { get; private set; }

        public decimal WholesalePrice { get; private set; }

        public double WholesaleQuantity { get; private set; }

        public bool Wholesale => WholesaleQuantity > 0;

        public bool IsActive { get; set; }

        public void Validate(Notification notification)
        {
            new ProductValidator(this).Validate(notification);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var other = (Product)obj;
            return Code.Equals(other.Code);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(_id);
            hash.Add(Id);
            hash.Add(Code);
            hash.Add(InternCode);
            hash.Add(Description);
            hash.Add(ProductUnit);
            hash.Add(Stock);
            hash.Add(CostPrice);
            hash.Add(RetailPrice);
            hash.Add(WholesalePrice);
            hash.Add(WholesaleQuantity);
            hash.Add(Wholesale);
            return hash.ToHashCode();
        }

     
        public override string ToString()
        {
            return $"ID: {Id}\n" +
               $"Code: {Code}\n" +
               $"InternCode: {InternCode}\n" +
               $"Description: {Description}\n" +
               $"ProductUnit: {ProductUnit}\n" +
               $"Stock: {Stock}\n" +
               $"CostPrice: {CostPrice}\n" +
               $"RetailPrice: {RetailPrice}\n" +
               $"WholesalePrice: {WholesalePrice}\n" +
               $"WholesaleQuantity: {WholesaleQuantity}\n" +
               $"Wholesale: {Wholesale}\n" +
               $"IsActive: {IsActive}";
        }
    }
}