using OpenStore.Application.Produto.Get;
using OpenStore.Application.Produto.List;
using OpenStore.Infra.Produto.Models;

namespace OpenStore.Infra.Produto.Presenters
{
    public interface IProductApiPresenter
    {

        static ProductResponse Present(ProductOutput output)
        {
            return new ProductResponse(
                output.Id,
                output.Code,
                output.InternCode,
                output.Description,
                output.Unit,
                output.Stock,
                output.CostPrice,
                output.RetailPrice,
                output.WholesalePrice,
                output.WholesaleQuantity,
                output.IsActive);
        }

        static ListProductResponse Present(ListProductOutput output)
        {
            return new ListProductResponse(
                output.Id,
                output.Code,
                output.InternCode,
                output.Description,
                output.Unit,
                output.Stock,
                output.RetailPrice
                );
        }

    }
}
