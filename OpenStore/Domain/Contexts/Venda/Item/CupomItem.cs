using OpenStore.Domain.Contexts.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStore.Domain.Contexts.Venda.Item
{
    public class CupomItem
    {

        public long CupomId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }

        public CupomItem()
        {
            Code = "";
            Description = "";
        }

        public CupomItem(long cupomId, string code, string description, decimal price, float quantity)
        {
            CupomId = cupomId;
            Code = code;
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public static CupomItem NewCupomItem(long cupomId, Product product, float quantity)
        {
            return new CupomItem(cupomId, product.Code, product.Description, product.RetailPrice, quantity);
        }

        public static CupomItem NewCupomItem(long cupomId, string code, string description, decimal price, float quantity)
        {
            return new CupomItem(cupomId, code, description, price, quantity);
        }

        public decimal GetTotal()
        {
            return Price * (decimal)Quantity;
        }


    }
}
