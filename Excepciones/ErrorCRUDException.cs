using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class CRUDException: Exception
    {
        public CRUDException(string mensaje): base(mensaje)
        { 
        }

        public CRUDException(string mensaje, Exception inner) : base(mensaje, inner)
        {
        }

    }
}
