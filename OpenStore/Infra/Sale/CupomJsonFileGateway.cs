using OpenStore.Domain.Contexts.Venda;

namespace OpenStore.Infra.Sale
{
    public class CupomJsonFileGateway : ICupomGateway
    {

        private CupomRepository _cupomRepository { get; set; }

        public CupomJsonFileGateway(CupomRepository cupomRepository)
        {
            _cupomRepository = cupomRepository;
        }

        public void Create(Cupom cupom)
        {
            cupom.Id = _cupomRepository.Save(CupomEntity.From(cupom)).Id;
        }

        public List<Cupom> FindAll()
        {
            return _cupomRepository.FindAll().ConvertAll(c => c.ToDomain());
        }

        public Cupom? FindById(long id)
        {
            return _cupomRepository.FindById(id)?.ToDomain();
        }

        public void Update(Cupom cupom)
        {
            _cupomRepository.Save(CupomEntity.From(cupom));
        }
    }
}
