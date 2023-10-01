using OpenStore.Domain.Contexts.Produto;
using OpenStore.Infra.Produto.Persistence;

namespace OpenStore.Infra.Produto
{
    public class ProductJsonFileGateway : IProductGateway
    {

        private readonly ProductRepository _productRepository;

        public ProductJsonFileGateway(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Delete(long id)
        {
            _productRepository.Delete(id);
        }

        public List<Product> FindAll()
        {
            return _productRepository.FindAll().ConvertAll(p => p.ToDomain());
        }

        public List<Product> FindAllByDescription(string description)
        {
            return _productRepository.FindAllByDescription(description).ConvertAll(p => p.ToDomain());
        }

        public Product? FindByTerm(string term)
        {
            ProductEntity? p = _productRepository.FindByTerm(term);
            return p?.ToDomain();
        }

        public Product? FindByCode(string code)
        {
            ProductEntity? p = _productRepository.FindByCode(code);
            return p?.ToDomain();
        }

        public Product? FindById(long id)
        {
            ProductEntity? p = _productRepository.FindById(id);
            return p?.ToDomain();
        }

        public Product? FindByInternCode(string internCode)
        {

            ProductEntity? p = _productRepository.FindByInternCode(internCode);
            return p?.ToDomain();
        }

        public void Create(Product produto)
        {
            produto.Id =  _productRepository.Save(ProductEntity.From(produto)).Id;
        }

        public void Update(Product produto)
        {
            _productRepository.Save(ProductEntity.From(produto));
        }
    }
}
