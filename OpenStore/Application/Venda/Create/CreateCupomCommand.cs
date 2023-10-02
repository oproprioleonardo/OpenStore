using OpenStore.Domain.Contexts.Venda.Item;

namespace OpenStore.Application.Venda.Create
{
    public record CreateCupomCommand(
        DateTime Date,
        string Cliente,
        List<CreateCupomItemCommand> Items)
    {

        public static CreateCupomCommand With(DateTime date, string cliente, List<CreateCupomItemCommand> items)
        {
            return new CreateCupomCommand(date, cliente, items);
        }

    }


}
