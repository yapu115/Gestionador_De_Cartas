using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personajes
{
    public interface IListasDePersonajes
    {
        List<Jedi> ObtenerListaJedis();

        List<Sith> ObtenerListaSiths();

        List<Mandaloriano> ObtenerListaMandalorianos();

        List<Cazarrecompensas> ObtenerListaCazarrecompensas();
    }
}
