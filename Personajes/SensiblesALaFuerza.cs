using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Personajes
{
    /// <summary>
    /// Representarán las cartas de personajes que tienen poderes asociados a la fuerza.
    /// </summary>
    public abstract class SensiblesALaFuerza : Personaje
    {
        /// <summary>
        /// Atributos de la clase
        /// </summary>
        protected string rango;
        protected string faccion;

        /// <summary>
        /// Es el rango que posee el personaje
        /// </summary>
        public string Rango
        {
            get { return this.rango; }
            set { this.rango = value; }
        }

        /// <summary>
        /// Es la facción a la que posee el personaje
        /// </summary>
        public string Faccion
        {
            get { return this.faccion; }
            set { this.faccion = value;}
        }

        /// <summary>
        /// Constructor y sus sobrecargas que inicializan los atributos segun lo ingresado,
        /// En caso de no recibir parametros se inicializará con lo más básico de los atributos
        /// </summary>
        public SensiblesALaFuerza(string nombre, int vida, int poder, ERarezas rareza) : base(nombre, vida, poder, rareza)
        {
            this.rango = "Padawan";
            this.faccion = "Sin facción";
        }
        public SensiblesALaFuerza(string nombre, int vida, int poder, ERarezas rareza, string rango) : this(nombre, vida, poder, rareza)
        {
            this.rango = rango;
        }
        public SensiblesALaFuerza(string nombre, int vida, int poder, ERarezas rareza, string rango, string faccion) : this(nombre, vida, poder, rareza, rango)
        {
            this.faccion = faccion;
        }

        /// <summary>
        /// Sobrescritura del método Mostrar que le agrega los atributos de esta clase
        /// </summary>
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"RANGO: {this.Rango} - FACCION: {this.Faccion} - ");

            return sb.ToString();
        }

    }
}
