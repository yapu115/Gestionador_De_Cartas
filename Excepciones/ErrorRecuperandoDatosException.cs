using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ErrorRecuperandoDatosException: Exception
    {
        public ErrorRecuperandoDatosException(string mensage) : base(mensage) 
        {
        }
        public ErrorRecuperandoDatosException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }
    }
}
