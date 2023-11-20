using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Personajes
{
    /// <summary>
    /// Clase que permite la serializacion de cualquier tipo de personaje
    /// </summary>
    public class Serializador<T> 
        where T : Personaje
    {
        private List<T> cartasPersonaje;

        /// <summary>
        /// Inicializará la lista Generica
        /// </summary>
        public Serializador()
        {
            this.cartasPersonaje = new List<T>();
        }


        /// <summary>
        /// Serializa el personaje en el path, ambos pasados por parámetros
        /// </summary>
        public void SerializarPersonaje(string path, List<T> listaPersonajes)
        {
            JsonSerializerOptions serializador = new JsonSerializerOptions();
            serializador.WriteIndented = true;

            string objJson = JsonSerializer.Serialize(listaPersonajes, serializador);

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(objJson);
            }
        }



        /// <summary>
        /// Deserializa cada personaje del path pasado
        /// </summary>
        public List<T> DeserealizarPersonajes(string path)
        {
            if (File.Exists(path)) // Acá hacer un try catch con excepcion propia
            {
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string jsonString = sr.ReadToEnd();

                        this.cartasPersonaje = (List<T>)JsonSerializer.Deserialize(jsonString, typeof(List<T>));
                    }
                }
            }
            return this.cartasPersonaje;

        }

    }
}
