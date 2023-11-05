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
    /// Representa a las cartas cuyos personajes pertenece al gremio de cazarrecompensas
    /// </summary>
    public class Cazarrecompensas: Personaje
    {
        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private ECazarrecompensasNivel nivel;
        private string arma;
        private int cazados;
        
        /// <summary>
        /// Representa el prestigio que posee el Cazarrecompensas
        /// </summary>
        public ECazarrecompensasNivel Nivel
        {
            get { return this.nivel; }
            set { this.nivel = value;}
        }

        /// <summary>
        /// Representa el arma principal del Cazarrecompensas
        /// </summary>
        public string Arma
        {
            get { return this.arma; }
            set { this.arma = value; }
        }

        /// <summary>
        /// Representa la cantidad de presas del Cazarrecompensas
        /// </summary>
        public int Cazados
        {
            get { return this.cazados; }
            set { this.cazados = value; }
        }

        /// <summary>
        /// Constructor y sus sobrecargas que inicializan los atributos segun lo ingresado,
        /// En caso de no recibir parametros se inicializará con lo más básico de los atributos
        /// Se le agrega [JsonConstructor] para la Serealizacion posterior
        /// </summary>
        [JsonConstructor]
        public Cazarrecompensas(string nombre, int vida, int poder, ERarezas rareza): base(nombre, vida, poder, rareza) 
        {
            this.nivel = ECazarrecompensasNivel.Bajo;
            this.arma = "No tiene armas";
            this.cazados = 0;
        }
        public Cazarrecompensas(string nombre, int vida, int poder, ERarezas rareza, ECazarrecompensasNivel nivel) : this(nombre, vida, poder, rareza)
        {
            this.nivel = nivel;
        }
        public Cazarrecompensas(string nombre, int vida, int poder, ERarezas rareza, ECazarrecompensasNivel nivel, string arma) : this(nombre, vida, poder, rareza, nivel)
        {
            this.arma = arma;
        }
        public Cazarrecompensas(string nombre, int vida, int poder, ERarezas rareza, ECazarrecompensasNivel nivel, string arma, int cazados) : this(nombre, vida, poder, rareza, nivel, arma)
        {
            this.cazados = cazados;
        }

        /// <summary>
        /// Sobrescritura del método Mostrar que le agrega los atributos de esta clase
        /// </summary>
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"ARMA: {this.Arma} - N° DE PRESAS: {this.Cazados} - NIVEL DE PRESTIGIO: {this.Nivel}");

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
        ///  Retorne si es verdad que el objeto que se pasa por parámetro es Cazarrecompensas
        /// </summary>
        public override bool Equals(object? obj)
        {
            return obj is Cazarrecompensas;
        }
    }
}
