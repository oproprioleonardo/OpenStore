using OpenStore.Domain.Shared.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStore.Domain.Contexts.Venda.Item
{
    public class CupomItemValidator
    {

        public CupomItem Item { get; set; }

        public CupomItemValidator(CupomItem item)
        {
            Item = item;
        }

        public void Validate(Notification notification)
        {
            ValidateQuantity(notification);
            ValidateCode(notification);
            ValidateDescription(notification);
            ValidateCostPrice(notification);
        }

        public void ValidateCode(Notification notification)
        {
            if (Item.Code == null) notification.Append("Code não pode ser nulo");
            if (Item.Code == "") notification.Append("Code não pode ser vazio");
        }

        public void ValidateDescription(Notification notification)
        {
            if (Item.Description == null) notification.Append("Description não pode ser nulo");
            if (Item.Description == "") notification.Append("Description não pode ser vazio");
        }


        public void ValidateCostPrice(Notification notification)
        {
            if (Item.Price <= 0) notification.Append("Price não pode ser nulo");
        }

        public void ValidateQuantity(Notification notification)
        {
            if (Item.Quantity == 0) notification.Append("Quantidade não pode ser nulo");
        }
    }
}
