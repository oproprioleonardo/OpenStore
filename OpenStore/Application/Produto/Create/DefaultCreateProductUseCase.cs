using OpenStore.Domain.Contexts.Produto;
using OpenStore.Domain.Shared.Exceptions;
using OpenStore.Domain.Shared.Validation;

namespace OpenStore.Application.Produto.Create
{
    public class DefaultCreateProductUseCase : CreateProductUseCase
    {

        public readonly IProductGateway productGateway;

        public DefaultCreateProductUseCase(IProductGateway productGateway)
        {
            this.productGateway = productGateway;
        }

        public override CreateProductOutput Execute(CreateProductCommand command)
        {
            Product p = Product.NewProduct(
                command.Code,
                command.InternCode,
                command.Description,
                ProductUnitExtensions.Parse(command.Unit),
                command.Stock,
                command.CostPrice,
                command.RetailPrice,
                command.WholesalePrice,
                command.WholesaleQuantity
                );

            Notification n = Notification.Create();

            p.Validate(n);

            if (n.HasError())
            {
                throw NotificationException.With(n);
            }

            productGateway.Create(p);

            return new CreateProductOutput(p.Id);
        }
    }
}
