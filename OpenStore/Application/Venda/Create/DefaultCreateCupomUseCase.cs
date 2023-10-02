using OpenStore.Domain.Contexts.Venda;
using OpenStore.Domain.Contexts.Venda.Item;
using OpenStore.Infra.Sale;

namespace OpenStore.Application.Venda.Create
{
    public class DefaultCreateCupomUseCase : CreateCupomUseCase
    {

        public readonly ICupomGateway cupomGateway;

        public DefaultCreateCupomUseCase(ICupomGateway cupomGateway)
        {
            this.cupomGateway = cupomGateway;
        }

        public override CreateCupomOutput Execute(CreateCupomCommand command)
        {
            Cupom cupom = Cupom.NewCupom(command.Date, command.Cliente, new List<CupomItem>());
            cupomGateway.Create(cupom);
            cupom.Items = command.Items.ConvertAll(i => CupomItem.NewCupomItem(cupom.Id, i.Code, i.Description, i.Price, i.Quantity));
            cupomGateway.Update(cupom);
            return CreateCupomOutput.From(cupom);
        }
    }
}
