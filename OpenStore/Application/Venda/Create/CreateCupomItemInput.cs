namespace OpenStore.Application.Venda.Create
{
    public record CreateCupomItemInput(
        string Code,
        string Description,
        decimal Price,
        float Quantity)
    {

        public static CreateCupomItemInput With(string code, string description, decimal price, float quantity)
        {
            return new CreateCupomItemInput(code, description, price, quantity);
        }

    }
}
