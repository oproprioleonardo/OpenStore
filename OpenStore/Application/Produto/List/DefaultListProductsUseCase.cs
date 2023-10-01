using OpenStore.Domain.Contexts.Produto;

namespace OpenStore.Application.Produto.List
{
    public class DefaultListProductsUseCase : ListProductsUseCase
    {

        public readonly IProductGateway productGateway;

        public DefaultListProductsUseCase(IProductGateway productGateway)
        {
            this.productGateway = productGateway;
        }

        public override List<ListProductOutput> Execute()
        {
            return productGateway.FindAll().ConvertAll(p => ListProductOutput.From(p));
        }
    }
}
