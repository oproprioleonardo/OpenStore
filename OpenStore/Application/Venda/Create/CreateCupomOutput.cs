using OpenStore.Domain.Contexts.Venda;

namespace OpenStore.Application.Venda.Create
{
    public record CreateCupomOutput(long Id)
    {

        public static CreateCupomOutput From(Cupom cupom)
        {
            return new CreateCupomOutput(cupom.Id);
        }
    }
}
