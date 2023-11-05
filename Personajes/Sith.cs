using Personajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Personajes
{
    /// <summary>
    /// Representa a las cartas cuyos personajes pertenecen al lado oscuro de la fuerza
    /// </summary>
    public class Sith: SensiblesALaFuerza
    {
        private ESithColoresSables colorDeSable;
        
        /// <summary>
        /// Representa el color del sable del sith
        /// </summary>
        public ESithColoresSables ColorDeSable
        {
            get { return this.colorDeSable; }
            set { this.colorDeSable = value;}
        }

        /// <summary>
        /// Constructor y sus sobrecargas que inicializan los atributos segun lo ingresado,
        /// En caso de no recibir parametros se inicializará con lo más básico de los atributos
        /// Se le agrega [JsonConstructor] para la Serealizacion posterior
        /// </summary>
        [JsonConstructor]
        public Sith(string nombre, int vida, int poder, ERarezas rareza, string rango, string faccion): base(nombre, vida, poder, rareza, rango, faccion)
        {
            this.colorDeSable = ESithColoresSables.Rojo;
        }
        public Sith(string nombre, int vida, int poder, ERarezas rareza, string rango, string faccion, ESithColoresSables colorDeSable) : this(nombre, vida, poder, rareza, rango, faccion)
        {
            this.colorDeSable = colorDeSable;
        }

        /// <summary>
        /// Sobrescritura del método Mostrar que le agrega los atributos de esta clase
        /// </summary>
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"COLOR DE SABLE: {this.ColorDeSable}");

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve el método Mostrar con todos los datos completos
        /// </summary>
        public override string ToString()
        {
            return this.Mostrar();
        }

        /// <summary>
        /// Retorna si es verdad que el objeto que se pasa por parámetro es Sith
        /// </summary>
        public override bool Equals(object? obj)
        {
            return obj is Sith;
        }
    }
}
