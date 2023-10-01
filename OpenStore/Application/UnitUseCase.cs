using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStore.Application
{
    public abstract class UnitUseCase<IN>
    {

        public abstract void Execute(IN anIn);

    }
}
