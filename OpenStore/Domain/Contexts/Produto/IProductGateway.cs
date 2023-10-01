namespace OpenStore.Domain.Contexts.Produto
{
    public interface IProductGateway
    {

        void Create(Product produto);

        Product? FindByCode(string code);

        Product? FindByInternCode(string internCode);

        Product? FindById(long id);

        Product? FindByTerm(string term);

        List<Product> FindAllByDescription(string description);

        List<Product> FindAll();

        void Delete(long id);

        void Update(Product produto);
    }
}
