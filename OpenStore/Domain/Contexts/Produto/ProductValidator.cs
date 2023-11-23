using OpenStore.Domain.Shared.Validation;
using System.Text.RegularExpressions;

namespace OpenStore.Domain.Contexts.Produto
{
    public class ProductValidator
    {
        private Product _produto;

        public ProductValidator(Product produto)
        {
            _produto = produto;
        }

        public void Validate(Notification notification)
        {
            ValidateCode(notification);
            ValidateDescription(notification);
            ValidateStock(notification);
            ValidateCostPrice(notification);
            ValidateRetailPrice(notification);
            ValidateProductUnit(notification);
        }

        private void ValidateCode(Notification notification)
        {
            var pattern = new Regex(@"^(?!000|111|222|333|444|555|666|777|888|999)[0-9]{13}$");
            if (_produto.Code.Length == 0) notification.Append("Código do produto não pode ser vazio");
            else if (_produto.Code.Length != 13) notification.Append("Código do produto deve ter 13 dígitos");
            else if (!pattern.IsMatch(_produto.Code)) notification.Append("Código do produto deve conter apenas números e ser no padrão EAN13");
        }

        private void ValidateDescription(Notification notification)
        {
            if (_produto.Description.Length == 0)
                notification.Append("Descrição do produto não pode ser vazia");
        }

        private void ValidateStock(Notification notification)
        {
            if (_produto.Stock < 0)
                notification.Append("Quantidade de estoque do produto deve ser maior que zero");
        }

        private void ValidateProductUnit(Notification notification)
        {
            if (_produto.ProductUnit == ProductUnit.INDETERMINADO) notification.Append("Unidade do produto deve ser válida");
        }

        private void ValidateCostPrice(Notification notification)
        {
            if (_produto.CostPrice <= 0)
                notification.Append("Preço de custo do produto deve ser maior que zero");
        }

        private void ValidateRetailPrice(Notification notification)
        {
            if (_produto.RetailPrice <= 0)
                notification.Append("Preço de varejo do produto deve ser maior que zero");
        }


    }

}
