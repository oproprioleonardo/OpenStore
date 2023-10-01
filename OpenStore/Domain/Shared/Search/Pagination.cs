namespace OpenStore.Domain.Shared.Search
{
    public record Pagination<T>(
        int CurrentPage,
        int PerPage,
        long Total,
        List<T> Items
)
    {

        public Pagination<R> Map<R>(Converter<T, R> mapper)
        {
            List<R> aNewList = this.Items.ConvertAll(mapper);
            return new Pagination<R>(CurrentPage, PerPage, Total, aNewList);
        }
    }
}
