using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DatosIncompletosException: Exception
    {
        public DatosIncompletosException(string mensaje) : base(mensaje)
        {

        }
        public DatosIncompletosException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}
