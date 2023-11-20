using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personajes
{
    /// <summary>
    /// Procesos que permiten obtener la lista de cartas de personajes
    /// </summary>
    public interface IListasDePersonajes
    {
        List<Jedi> ObtenerListaJedis();

        List<Sith> ObtenerListaSiths();

        List<Mandaloriano> ObtenerListaMandalorianos();

        List<Cazarrecompensas> ObtenerListaCazarrecompensas();
    }
}
