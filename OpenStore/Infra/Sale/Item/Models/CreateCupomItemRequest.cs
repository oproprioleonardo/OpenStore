namespace OpenStore.Infra.Sale.Item.Models
{
    public record CreateCupomItemRequest(
        string Code,
        string Description,
        decimal Price,
        float Quantity)
    {
    }
}
