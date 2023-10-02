namespace OpenStore.Application.Venda.Create
{
    public record CreateCupomItemCommand(
        string Code,
        string Description,
        decimal Price,
        float Quantity)
    {

        public static CreateCupomItemCommand With(string code, string description, decimal price, float quantity)
        {
            return new CreateCupomItemCommand(code, description, price, quantity);
        }

    }
}
