using OpenStore.Domain.Contexts.Produto;
using OpenStore.Domain.Shared.Exceptions;

namespace OpenStore.Application.Produto.Get
{
    public class DefaultGetProductByCodeUseCase : GetProductByCodeUseCase
    {

        public readonly IProductGateway productGateway;

        public DefaultGetProductByCodeUseCase(IProductGateway productGateway)
        {
            this.productGateway = productGateway;
        }

        public override ProductOutput Execute(string anIn)
        {
            Product? p = productGateway.FindByCode(anIn);
            return p == null ? throw new NotFoundException(typeof(Product), anIn) : ProductOutput.From(p);
        }
    }
}
