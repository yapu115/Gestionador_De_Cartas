using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ErrorGuardandoDatosException: Exception
    {
        public ErrorGuardandoDatosException(string mensaje) : base(mensaje)
        {

        }

        public ErrorGuardandoDatosException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
