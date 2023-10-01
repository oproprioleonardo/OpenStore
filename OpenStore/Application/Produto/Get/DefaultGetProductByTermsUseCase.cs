using OpenStore.Domain.Contexts.Produto;
using OpenStore.Domain.Shared.Exceptions;

namespace OpenStore.Application.Produto.Get
{
    public class DefaultGetProductByTermsUseCase : GetProductByTermsUseCase
    {

        public readonly IProductGateway productGateway;

        public DefaultGetProductByTermsUseCase(IProductGateway productGateway)
        {
            this.productGateway = productGateway;
        }

        public override ProductOutput Execute(string anIn)
        {
            Product? p = null;
            foreach (string term in anIn.Split(';'))
            {
                p ??= productGateway.FindByTerm(anIn);
            }
            return p == null ? throw new NotFoundException(typeof(Product), anIn) : ProductOutput.From(p);
        }
    }
}
