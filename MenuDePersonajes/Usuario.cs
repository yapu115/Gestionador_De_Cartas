using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuDePersonajes
{
    /// <summary>
    /// Clase Usuario
    /// </summary>
    /// Representa a los usuarios que se loguean en el form
    public class Usuario
    {
        /// <summary>
        /// Atributos y propiedades
        /// </summary>
        /// Representan los datos personales del usuario y la fecha en la que se loguea
        private DateTime fecha;
        public Usuario() 
        {
            this.fecha = DateTime.Now;
        }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int legajo { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public string perfil { get; set; }
        public DateTime Fecha 
        {  
            get { return fecha; } 
            set {  fecha = value; } 
        } 

        /// <summary>
        /// Mostrar datos
        /// </summary>
        /// Muestra el nombre y la fecha en que se logueo el usuario
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.nombre} - {this.Fecha.ToString("dd/MM/yyyy")}");
            return sb.ToString();
        }

        /// <summary>
        /// Datos para Serializar
        /// </summary>
        /// Muestra todos los datos del usuario, excepto la contraseña. Estos datos están pensados para una serializacion
        public string DatosParaSerializar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.nombre} - {this.apellido} - {this.legajo} - {this.correo} - ");
            sb.Append($"{this.perfil} - {this.Fecha}");
            return sb.ToString();
        }
    }
}
