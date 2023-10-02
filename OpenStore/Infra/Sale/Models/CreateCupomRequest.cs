using OpenStore.Application.Venda.Create;
using OpenStore.Infra.Sale.Item.Models;

namespace OpenStore.Infra.Sale.Models
{
    public record CreateCupomRequest(
        DateTime Date,
        string Cliente,
        List<CreateCupomItemRequest> Items)
    {
    }
}
