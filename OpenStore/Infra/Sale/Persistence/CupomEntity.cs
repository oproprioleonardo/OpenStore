using Newtonsoft.Json;
using OpenStore.Domain.Contexts.Venda;
using OpenStore.Infra.Sale.Item.Persistence;

namespace OpenStore.Infra.Sale
{
    [JsonObject]
    public class CupomEntity
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("cliente")]
        public string Cliente { get; set; }
        [JsonProperty("isClosed")]
        public bool IsClosed { get; set; }
        [JsonProperty("isCanceled")]
        public bool IsCanceled { get; set; }
        [JsonProperty("items")]
        public List<CupomItemEntity> Items { get; set; }

        public CupomEntity() {
            Cliente = "";
            Items = new List<CupomItemEntity>();
        }

        public CupomEntity(long id, DateTime date, string cliente, List<CupomItemEntity> items, bool isClosed, bool isCanceled)
        {
            Id = id;
            Date = date;
            Cliente = cliente;
            Items = items;
            IsClosed = isClosed;
            IsCanceled = isCanceled;
        }

        public static CupomEntity From(Cupom cupom)
        {
            return new CupomEntity(cupom.Id, cupom.Date, cupom.Cliente, cupom.Items.ConvertAll(i => CupomItemEntity.From(i)), cupom.IsClosed, cupom.IsCanceled);
        }

        public Cupom ToDomain()
        {
            return new Cupom(Id, Date, Cliente, Items.ConvertAll(i => i.ToDomain()), IsClosed, IsCanceled);
        }

    }
}
