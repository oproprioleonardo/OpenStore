namespace OpenStore.Domain.Shared.Search
{
    public record SearchQuery(
        int Page,
        int PerPage,
        string Terms
    )
    {
    }
}
