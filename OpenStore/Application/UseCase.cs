using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenStore.Application
{
    public abstract class UseCase<IN, OUT>
    {

        public abstract OUT Execute(IN anIn);

    }
}
