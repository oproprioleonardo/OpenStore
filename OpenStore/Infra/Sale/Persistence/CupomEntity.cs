using OpenStore.Domain.Contexts.Venda;
using OpenStore.Infra.Sale.Item.Persistence;

namespace OpenStore.Infra.Sale
{
    public class CupomEntity
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Cliente { get; set; }
        public bool IsClosed { get; set; }
        public bool IsCanceled { get; set; }
        public List<CupomItemEntity> Items { get; set; }

        public CupomEntity() {
            Cliente = "";
            Items = new List<CupomItemEntity>();
        }

        public CupomEntity(long id, DateTime date, string cliente, List<CupomItemEntity> items)
        {
            Id = id;
            Date = date;
            Cliente = cliente;
            Items = items;
        }

        public static CupomEntity From(Cupom cupom)
        {
            return new CupomEntity(cupom.Id, cupom.Date, cupom.Cliente, cupom.Items.ConvertAll(i => CupomItemEntity.From(i)));
        }

        public Cupom ToDomain()
        {
            return new Cupom(Id, Date, Cliente, Items.ConvertAll(i => i.ToDomain()), IsClosed, IsCanceled);
        }

    }
}
