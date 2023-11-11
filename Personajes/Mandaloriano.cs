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
    /// Representa a las cartas cuyos personajes pertenecen a la raza mandaloriana.
    /// </summary>
    public class Mandaloriano: Personaje, IHabilidadDestacable
    {
        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private string clan;
        private bool sableOscuro;
        private bool forajido;

        /// <summary>
        /// Representa el clan al que pertenece el mandaloriano.
        /// </summary>
        public string Clan
        {
            get { return this.clan; }
            set { this.clan = value; }
        }

        /// <summary>
        /// Representa si el personaje posee el sable oscuro
        ///  Si es falso se devuelve un string "No"
        /// Si es verdadero se devuelve un string "Si"
        /// </summary>
        public string SableOscuro
        {
            get 
            {
                string retorno = "No";
                if (this.sableOscuro)
                {
                    retorno = "Si";
                }
                return retorno; 
            }
            set 
            {
                this.sableOscuro = false;
                if (value == "Si")
                {
                    this.sableOscuro = true;
                }
            }
        }
        /// <summary>
        /// Representa si el personaje se separó del grupo al que pertenecía.
        ///  Si es falso se devuelve un string "No"
        /// Si es verdadero se devuelve un string "Si"
        /// </summary>
        public string Forajido
        {
            get
            {
                string retorno = "No";
                if (this.forajido)
                {
                    retorno = "Si";
                }
                return retorno;
            }
            set
            {
                this.forajido = false;
                if (value == "Si")
                {
                    this.forajido = true;
                }
            }
        }

        /// <summary>
        /// Constructor y sus sobrecargas que inicializan los atributos segun lo ingresado,
        /// En caso de no recibir parametros se inicializará con lo más básico de los atributos
        /// Se le agrega [JsonConstructor] para la Serealizacion posterior
        /// </summary>
        [JsonConstructor]
        public Mandaloriano(string nombre, int vida, int poder, ERarezas rareza) : base(nombre, vida, poder, rareza)
        {
            this.clan = "No es parte de ningun clan";
            this.sableOscuro = false;
            this.forajido = true;
        }
        
        public Mandaloriano(string nombre, int vida, int poder, ERarezas rareza, string clan) : this(nombre, vida, poder, rareza)
        {
            this.clan = clan;
        }
        public Mandaloriano(string nombre, int vida, int poder, ERarezas rareza, string clan, bool forajido) : this(nombre, vida, poder, rareza, clan)
        {
            this.forajido = forajido;
        }

        public Mandaloriano(string nombre, int vida, int poder, ERarezas rareza, string clan, bool forajido, bool sableOscuro) : this(nombre, vida, poder, rareza, clan, forajido)
        {
            this.sableOscuro = sableOscuro;
        }

        public bool AgregarEspecialidad()
        {
            bool retorno = false;
            if (this.Forajido == "Si" && this.SableOscuro == "No")
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Sobrescritura del método Mostrar que le agrega los atributos de esta clase
        /// </summary>
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"CLAN: {this.Clan} - SABLE OSCURO: {this.SableOscuro} - FORAJIDO: {this.Forajido}");

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
        /// Retorna si es verdad que el objeto que se pasa por parámetro es Mandaloriano
        /// </summary>
        public override bool Equals(object? obj)
        {
            return obj is Mandaloriano;
        }

    }
}
