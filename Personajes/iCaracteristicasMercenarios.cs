using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personajes
{
    public interface iCaracteristicasMercenarios
    {
        public string Arma { get; set;}
        public string Clan { get; set;}
        bool AgregarEspecialidad();
    }
}
