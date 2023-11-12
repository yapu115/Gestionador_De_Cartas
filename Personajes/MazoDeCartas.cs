using Personajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Personajes
{
    /// <summary>
    /// Representará un mazo de cartas que tiene una persona, con una lista de cada uno de los tipos de personajes
    /// </summary>
    public class MazoDeCartas
    {
        private List<Jedi> cartasJedi;
        private List<Sith> cartasSith;
        private List<Mandaloriano> cartasMandalorianos;
        private List<Cazarrecompensas> cartasCazarrecompensas;

        /// <summary>
        /// Inicializará cada lista de cartas como su tipo
        /// </summary>
        public MazoDeCartas()
        {
            this.cartasJedi = new List<Jedi>(); 
            this.cartasSith = new List<Sith>();
            this.cartasMandalorianos = new List<Mandaloriano>();
            this.cartasCazarrecompensas = new List<Cazarrecompensas>();
        }

        /// <summary>
        /// Representa el mazo de cartas Jedis
        /// </summary>
        public List<Jedi> CartasJedi
        {
            get { return this.cartasJedi; }
            set { this.cartasJedi = value; }
        }

        /// <summary>
        /// Representa el mazo de cartas siths
        /// </summary>
        public List<Sith> CartasSith
        {
            get { return this.cartasSith; }
            set { this.cartasSith = value; }
        }

        /// <summary>
        /// Representa el mazo de cartas Mandalorianas.
        /// </summary>
        public List<Mandaloriano> CartasMandalorianos
        {
            get { return this.cartasMandalorianos; }
            set { this.cartasMandalorianos = value; }
        }

        /// <summary>
        /// Representa el mazo de cartas Cazarrecompensas.
        /// </summary>
        public List<Cazarrecompensas> CartasCazarrecompensas
        {
            get { return this.cartasCazarrecompensas; }
            set { this.cartasCazarrecompensas = value; }
        }


        /// <summary>
        /// Serializa cada cada Jedi de su lista de cartas
        /// </summary>
        public void SerializarJedis(string path)
        {
            path += @"\CartasJedi";
            JsonSerializerOptions serializador = new JsonSerializerOptions();
            serializador.WriteIndented = true;  

            string objJson = JsonSerializer.Serialize(this.cartasJedi, serializador);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(objJson);
            }
        }
        /// <summary>
        /// Serializa cada cada Sith de su lista de cartas
        /// </summary>
        public void SerializarSiths(string path)
        {
            path += @"\CartasSith";
            JsonSerializerOptions serializador = new JsonSerializerOptions();
            serializador.WriteIndented = true;  

            string objJson = JsonSerializer.Serialize(this.cartasSith, serializador);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(objJson);
            }
        }

        /// <summary>
        /// Serializa cada cada Mandaloriano de su lista de cartas
        /// </summary>
        public void SerializarMandalorianos(string path)
        {
            path += @"\CartasMandalorianos";
            JsonSerializerOptions serializador = new JsonSerializerOptions();
            serializador.WriteIndented = true;  

            string objJson = JsonSerializer.Serialize(this.cartasMandalorianos, serializador);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(objJson);
            }
        }
        /// <summary>
        /// Serializa cada cada Cazarrecompensas de su lista de cartas
        /// </summary>
        public void SerializarCazarrecompensas(string path)
        {
            path += @"\CartasCazarrecompensas";
            JsonSerializerOptions serializador = new JsonSerializerOptions();
            serializador.WriteIndented = true; 

            string objJson = JsonSerializer.Serialize(this.cartasCazarrecompensas, serializador);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(objJson);
            }
        }


        /// <summary>
        /// Deserializa cada cada Jedi de su lista de cartas
        /// </summary>
        public void DeserealizarJedis(string path)
        {/*
            path += @"\CartasJedi";
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string jsonString = sr.ReadToEnd();

                    this.cartasJedi = (List<Jedi>)JsonSerializer.Deserialize(jsonString, typeof(List<Jedi>));
                }
            }*/
            AccesoPersonajes a = new AccesoPersonajes();
            this.cartasJedi = a.ObtenerListaJedis();
        }
        /// <summary>
        /// Deserializa cada cada Sith de su lista de cartas
        /// </summary>
        public void DeserealizarSiths(string path)
        {/*
            path += @"\CartasSith";
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string jsonString = sr.ReadToEnd();

                    this.cartasSith = (List<Sith>)JsonSerializer.Deserialize(jsonString, typeof(List<Sith>));
                }
            }*/

            AccesoPersonajes a = new AccesoPersonajes();
            this.cartasSith = a.ObtenerListaSiths();
        }
        /// <summary>
        /// Deserializa cada cada Mandaloriano de su lista de cartas
        /// </summary>
        public void DeserealizarMandalorianos(string path)
        {/*
            path += @"\CartasMandalorianos";
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string jsonString = sr.ReadToEnd();

                    this.cartasMandalorianos = (List<Mandaloriano>)JsonSerializer.Deserialize(jsonString, typeof(List<Mandaloriano>));
                }

            }*/

            AccesoPersonajes a = new AccesoPersonajes();
            this.cartasMandalorianos = a.ObtenerListaMandalorianos();
        }
        /// <summary>
        /// Deserializa cada cada Cazarrecompensas de su lista de cartas
        /// </summary>
        public void DeserealizarCazarrecompensas(string path)
        {
            /*
            path += @"\CartasCazarrecompensas";
            if (File.Exists(path))
            {
            using (StreamReader sr = new StreamReader(path))
            {
                string jsonString = sr.ReadToEnd();

                this.cartasCazarrecompensas = (List<Cazarrecompensas>)JsonSerializer.Deserialize(jsonString, typeof(List<Cazarrecompensas>));
            }
            }*/
            AccesoPersonajes a = new AccesoPersonajes();
            this.cartasCazarrecompensas = a.ObtenerListaCazarrecompensas();
        }


        /// <summary>
        /// Ordena las cartas de cada lista de manera ascendente por su poder
        /// </summary>
        public void OrdenarPorPoderAscendente()
        {
            this.cartasJedi.Sort(OrdenamientoPoderAscendente);
            this.cartasSith.Sort(OrdenamientoPoderAscendente);
            this.cartasMandalorianos.Sort(OrdenamientoPoderAscendente);
            this.cartasCazarrecompensas.Sort(OrdenamientoPoderAscendente);
        }

        /// <summary>
        /// Ordena las cartas de cada lista de manera descendente por su poder
        /// </summary>
        public void OrdenarPorPoderDescendente()
        {
            this.cartasJedi.Sort(OrdenamientoPoderDescendente);
            this.cartasSith.Sort(OrdenamientoPoderDescendente);
            this.cartasMandalorianos.Sort(OrdenamientoPoderDescendente);
            this.cartasCazarrecompensas.Sort(OrdenamientoPoderDescendente);
        }

        /// <summary>
        /// Ordena las cartas de cada lista de manera ascendente por su Vida
        /// </summary>
        public void OrdenarPorVidaAscendente()
        {
            this.cartasJedi.Sort(OrdenamientoVidaAscendente);
            this.cartasSith.Sort(OrdenamientoVidaAscendente);
            this.cartasMandalorianos.Sort(OrdenamientoVidaAscendente);
            this.cartasCazarrecompensas.Sort(OrdenamientoVidaAscendente);
        }

        /// <summary>
        /// Ordena las cartas de cada lista de manera descendente por su vida
        /// </summary>
        public void OrdenarPorVidaDescendente()
        {
            this.cartasJedi.Sort(OrdenamientoVidaDescendente);
            this.cartasSith.Sort(OrdenamientoVidaDescendente);
            this.cartasMandalorianos.Sort(OrdenamientoVidaDescendente);
            this.cartasCazarrecompensas.Sort(OrdenamientoVidaDescendente);
        }


        /// <summary>
        /// Indica si el personaje ya está en el mazo de cartas
        /// </summary>
        public static bool operator ==(MazoDeCartas m, Personaje p)
        {
            bool retorno = false;
            switch (p)
            {
                case Jedi:
                    foreach (Jedi j in m.cartasJedi)
                    {
                        if (j == p)
                        {
                            retorno = true;
                            break;
                        }
                    }
                    break;

                case Sith:
                    foreach (Sith s in m.cartasSith)
                    {
                        if (s == p)
                        {
                            retorno = true;
                            break;
                        }
                    }
                    break;

                case Mandaloriano:
                    foreach (Mandaloriano man in m.cartasMandalorianos)
                    {
                        if (man == p)
                        {
                            retorno = true;
                            break;
                        }
                    }
                    break;

                case Cazarrecompensas:
                    foreach (Cazarrecompensas c in m.cartasCazarrecompensas)
                    {
                        if (c == p)
                        {
                            retorno = true;
                            break;
                        }
                    }
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// !=: Indica, negando la sobrecarga de ==, si el personaje no está en el mazo 
        /// </summary>
        public static bool operator !=(MazoDeCartas m, Personaje p)
        {
            return !(m == p);
        }

        /// <summary>
        /// +: Primero verifica si la carta no está en el mazo, si es así, la agrega y devuelve true
        /// </summary>
        public static bool operator +(MazoDeCartas m, Personaje p)
        {
            bool retorno = false;   
            if (m != p)
            {
                if (p is Jedi)
                {
                    m.CartasJedi.Add((Jedi)p);
                    retorno = true;
                }
                else if (p is Sith)
                {
                    m.CartasSith.Add((Sith)p);
                    retorno = true;
                }
                else if (p is Mandaloriano)
                {
                    m.CartasMandalorianos.Add((Mandaloriano)p);
                    retorno = true;
                }
                else if (p is Cazarrecompensas)
                {
                    m.CartasCazarrecompensas.Add((Cazarrecompensas)p);
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// -: Primero verifica si la carta está en el mazo, si es así la elimina y devuelve el mazo de cartas
        /// </summary>
        public static MazoDeCartas operator -(MazoDeCartas m, Personaje p)
        {
            if (m == p)
            {
                if (p is Jedi)
                {
                    m.CartasJedi.Remove((Jedi)p);
                }
                else if (p is Sith)
                {
                    m.CartasSith.Remove((Sith)p);
                }
                else if (p is Mandaloriano)
                {
                    m.CartasMandalorianos.Remove((Mandaloriano)p);
                }
                else if (p is Cazarrecompensas)
                {
                    m.CartasCazarrecompensas.Remove((Cazarrecompensas)p);
                }
            }
            return m;
        }



        /// <summary>
        /// Compara a dos personajes a partir de su poder y ordena su indice de manera descendente
        /// </summary>
        private int OrdenamientoPoderDescendente(Personaje p1, Personaje p2)
        {
            if (p1.Poder > p2.Poder)
                return -1;
            else if (p1.Poder < p2.Poder)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// Compara a dos personajes a partir de su poder y ordena su indice de manera ascendente
        /// </summary>
        private static int OrdenamientoPoderAscendente(Personaje p1, Personaje p2)
        {
            if (p1.Poder < p2.Poder)
                return -1;
            else if (p1.Poder > p2.Poder)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// Compara a dos personajes a partir de su vida y ordena su indice de manera descendente
        /// </summary>
        private static int OrdenamientoVidaDescendente(Personaje p1, Personaje p2)
        {
            if (p1.Vida > p2.Vida)
                return -1;
            else if (p1.Vida < p2.Vida)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// Compara a dos personajes a partir de su vida y ordena su indice de manera ascendente
        /// </summary>
        private static int OrdenamientoVidaAscendente(Personaje p1, Personaje p2)
        {
            if (p1.Vida < p2.Vida)
                return -1;
            else if (p1.Vida > p2.Vida)
                return 1;
            else
                return 0;
        }
    }
}
