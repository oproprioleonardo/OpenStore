using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStore.Application
{
    public abstract class NullaryUseCase<OUT>
    {
        public abstract OUT Execute();

    }
}
