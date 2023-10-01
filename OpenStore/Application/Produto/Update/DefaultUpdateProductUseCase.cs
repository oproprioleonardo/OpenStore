using OpenStore.Application.Produto.Get;
using OpenStore.Domain.Contexts.Produto;
using OpenStore.Domain.Shared.Exceptions;
using OpenStore.Domain.Shared.Validation;

namespace OpenStore.Application.Produto.Update
{
    public class DefaultUpdateProductUseCase : UpdateProductUseCase
    {

        public readonly IProductGateway productGateway;

        public DefaultUpdateProductUseCase(IProductGateway productGateway)
        {
            this.productGateway = productGateway;
        }

        public override ProductOutput Execute(UpdateProductCommand command)
        {
            Product? p = productGateway.FindById(command.Id) ?? throw new NotFoundException(typeof(Product), command.Id.ToString());
            p.UpdateProduct(
                command.InternCode,
                command.Description,
                ProductUnitExtensions.Parse(command.Unit),
                command.Stock,
                command.CostPrice,
                command.RetailPrice,
                command.WholesalePrice,
                command.WholesaleQuantity
            );

            Notification notification = Notification.Create();
            p.Validate(notification);
            if (notification.HasError()) throw NotificationException.With(notification);
           
            productGateway.Update(p);
            return ProductOutput.From(p);
        }
    }
    
}
