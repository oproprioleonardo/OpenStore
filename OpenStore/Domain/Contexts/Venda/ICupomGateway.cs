using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStore.Domain.Contexts.Venda
{
    public interface ICupomGateway
    {
        void Create(Cupom cupom);
        void Update(Cupom cupom);
        Cupom? FindById(long id);
        List<Cupom> FindAll();
    }
}
