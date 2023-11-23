using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OpenStore.Application.Produto.Create
{

    public record CreateProductInput(
        string Code,
        string InternCode,
        string Description,
        string Unit,
        double Stock,
        decimal CostPrice,
        decimal RetailPrice,
        decimal WholesalePrice,
        double WholesaleQuantity
        )
    {

        public static CreateProductInput With(string code, string internCode, string description, string unit, double stock,
                       decimal costPrice, decimal retailPrice, decimal wholesalePrice, double wholesaleQuantity)
        {
            return new CreateProductInput(code, internCode, description, unit, stock, costPrice, retailPrice, wholesalePrice, wholesaleQuantity);
        }
    }
   

}
