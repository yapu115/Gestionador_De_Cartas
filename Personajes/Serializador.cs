using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Personajes
{
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

        /// <summary>
        /// Corrobora si un personaje está en la lista que se le pasa
        /// </summary>
        public  bool CorroborarPersonajeEnMazo(List<T> cartasPersonajes, T personaje)
        {
            bool retorno = false;

            foreach (T p in cartasPersonaje)
            {
                if (personaje == p)
                {
                    retorno = true;
                    break;
                }
            }  
            return retorno;
        }


    }
}
