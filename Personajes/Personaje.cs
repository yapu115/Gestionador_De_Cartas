using System.Data.Common;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Personajes
{
    /// <summary>
    /// Representar al tipo de personaje que se va a usaren la carta del usuario.
    /// Tendrá 4 atributos, El nombre, la vida y el poder (representados en numeros) y
    /// la rareza (Que tan rara de encontrar es esa carta) la cual será un enumerado.
    /// </summary>
    public abstract class Personaje
    {
        
        /// <summary>
        /// Atributos de la clase
        /// (La rareza representa el nivel de importancia de la carta)
        /// </summary>
        protected string nombre;
        protected int vida;
        protected int poder;
        protected ERarezas rareza;

        /// <summary>
        /// Propiedades de la clase
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public int Vida
        {
            get { return this.vida; }
            set { this.vida = value; }
        }
        public int Poder
        {
            get { return this.poder; }
            set { this.poder = value; }
        }
        public string Rareza
        {
            get 
            {
                string texto = "";
                switch (this.rareza)
                {
                    case ERarezas.Normal:
                        texto = "Normal";
                        break;
                    case ERarezas.Rara:
                        texto = "Rara";
                        break;
                    case ERarezas.Epica:
                        texto = "Epica";
                        break;
                    case ERarezas.Legendaria:
                        texto = "Legendaria";
                        break;
                }
                return texto; 
            }
            set 
            {
                ERarezas r = new ERarezas();
                switch (value)
                {
                    case "Normal":
                        r = ERarezas.Normal;
                        break;
                    case "Rara":
                        r = ERarezas.Rara;
                        break;
                    case "Epica":
                        r = ERarezas.Epica;
                        break;
                    case "Legendaria":
                        r = ERarezas.Legendaria;
                        break;
                }
                this.rareza = r; 
            }
        }

        /// <summary>
        /// Constructor y sus sobrecargas que inicializan los atributos segun lo ingresado,
        /// En caso de no recibir parametros se inicializará con lo más básico de los atributos
        /// </summary>
        public Personaje()
        {
            this.nombre = "Desconocido";
            this.vida = 0;
            this.poder = 0;
            this.rareza = ERarezas.Normal;
        }
        public Personaje(string nombre) : this()
        {
            this.Nombre = nombre;
        }
        public Personaje(string nombre, int vida) : this(nombre)
        {
            this.Vida = vida;
        }
        public Personaje(string nombre, int vida, int poder) : this(nombre, vida)
        {
            this.Poder = poder;
        }
        public Personaje(string nombre, int vida, int poder, ERarezas rareza) : this(nombre, vida, poder)
        {
            this.rareza = rareza;
        }

        /// <summary>
        /// Muestra los atributos en una línea como string
        /// </summary>
        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"NOMBRE: {this.Nombre} - VIDA: {this.Vida} - PODER: {this.Poder} - RAREZA: {this.Rareza} - ");
            return sb.ToString();
        }

        /// <summary>
        /// Metodos abstractos: ToString e Equals
        /// Son los métodos que se implementarán en las clases concretas
        /// </summary>
        public abstract override string ToString();
        public abstract override bool Equals(object? obj);


        /// <summary>
        /// determina si una carta es igual a otra a partir del Equals sobrescrito 
        /// y los 4 criterios de sus atributos
        /// </summary>
        public static bool operator ==(Personaje p1, Personaje p2)
        {
            return p1.Equals(p2) && p1.Nombre == p2.Nombre && p1.Poder == p2.poder && p1.Vida == p2.Vida && p1.Rareza == p2.Rareza;
        }

        /// <summary>
        /// determina si una carta es diferente a otra a partir del Equals sobrescrito 
        /// y los 4 criterios de sus atributos
        /// </summary>
        public static bool operator !=(Personaje p1, Personaje p2)
        {
            return !(p1 == p2);
        }
    }
}

