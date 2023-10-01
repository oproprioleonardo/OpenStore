using OpenStore.Domain.Contexts.Venda.Item;
using OpenStore.Infra.Produto;
using OpenStore.Infra.Produto.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStore.Infra.Sale.Item.Persistence
{
    public class CupomItemEntity
    {

        public long CupomId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }

        public CupomItemEntity() {
            Code = "";
            Description = "";
        }

        public CupomItemEntity(long cupomId, string code, string description, decimal price, float quantity)
        {
            CupomId = cupomId;
            Code = code;
            Description = description;
            Price = price;
            Quantity = quantity;
        }
       

        public static CupomItemEntity From(CupomItem cupomItem)
        {
            return new CupomItemEntity(cupomItem.CupomId, cupomItem.Code, cupomItem.Description, cupomItem.Price, cupomItem.Quantity);
        }

        public CupomItem ToDomain()
        {
            return CupomItem.NewCupomItem(CupomId, Code, Description, Price, Quantity);
        }

    }
}
