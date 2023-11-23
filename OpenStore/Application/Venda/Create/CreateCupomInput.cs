using OpenStore.Domain.Contexts.Venda.Item;

namespace OpenStore.Application.Venda.Create
{
    public record CreateCupomInput(
        DateTime Date,
        string Cliente,
        List<CreateCupomItemInput> Items)
    {

        public static CreateCupomInput With(DateTime date, string cliente, List<CreateCupomItemInput> items)
        {
            return new CreateCupomInput(date, cliente, items);
        }

    }


}
