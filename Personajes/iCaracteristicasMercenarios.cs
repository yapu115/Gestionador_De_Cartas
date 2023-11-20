using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personajes
{
    /// <summary>
    /// Caracteristicas que poseen todos los Personajes considerados mercenarios
    /// </summary>
    public interface ICaracteristicasMercenarios
    {
        public string Arma { get; set;}
        public string Clan { get; set;}
        bool AgregarEspecialidad();
    }
}
