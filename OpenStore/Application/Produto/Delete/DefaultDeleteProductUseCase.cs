using OpenStore.Domain.Contexts.Produto;
using OpenStore.Domain.Shared.Exceptions;

namespace OpenStore.Application.Produto.Delete
{
    public class DefaultDeleteProductUseCase : DeleteProductUseCase
    {

        public readonly IProductGateway productGateway;

        public DefaultDeleteProductUseCase(IProductGateway productGateway)
        {
            this.productGateway = productGateway;
        }

        public override void Execute(long anIn)
        {
            _ = productGateway.FindById(anIn) ?? throw new NotFoundException(typeof(Product), anIn.ToString());

            productGateway.Delete(anIn);
        }
    }
}
