using OpenStore.Domain.Shared.Validation;

namespace OpenStore.Domain.Contexts.Venda
{
    public class CupomValidator
    {
        public Cupom Venda { get; set; }

        public CupomValidator(Cupom venda)
        {
            Venda = venda;
        }

        public void Validate(Notification notification)
        {
            ValidateCliente(notification);
            ValidateItems(notification);
        }

        public void ValidateCliente(Notification notification)
        {
            if (Venda.Cliente == null) notification.Append("Cliente não pode ser nulo");
            if (Venda.Cliente == "") notification.Append("Cliente não pode ser vazio");
        }

        public void ValidateItems(Notification notification)
        {
            if (Venda.Items == null) notification.Append("Items não pode ser nulo");
            if (Venda.Items != null && Venda.Items.Count == 0) notification.Append("Items não pode ser vazio");
        }


    }
}
