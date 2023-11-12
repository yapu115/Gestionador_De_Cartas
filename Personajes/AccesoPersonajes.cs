using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Personajes
{
    public class AccesoPersonajes
    {
        private SqlConnection conexion;
        private static string cadena_conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        List<Personaje> personajes;

        static AccesoPersonajes()
        {
            AccesoPersonajes.cadena_conexion = Properties.Resources.miConexion;
        }

        public AccesoPersonajes()
        {
            personajes = new List<Personaje>();
            this.conexion = new SqlConnection(AccesoPersonajes.cadena_conexion);
        }

        public bool PruebaConexion()
        {
            bool retorno = false;

            try
            {
                this.conexion.Open();
                retorno = true;
            }
            catch (Exception ex) 
            {

            }
            finally 
            {
                if (this.conexion.State == System.Data.ConnectionState.Open) 
                {
                    this.conexion.Close(); 
                }
            }
            return retorno;
        }

        public List<Personaje> ObtenerListaPersonaje()
        {
            string tipoDePersonaje = ObtenerTipoDePersonaje(this.personajes);
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"SELECT Nombre, Vida, Poder, Rareza, {OtrosParametros(tipoDePersonaje)}";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();
                while (this.lector.Read())
                {
                    string nombre = this.lector["Nombre"].ToString();
                    int vida = (int)this.lector["Vida"];
                    int poder = (int)this.lector["Poder"];
                    string rareza = this.lector["Rareza"].ToString();

                    AgregarPersonaje(tipoDePersonaje ,nombre, vida, poder, rareza);
                }
                this.lector.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return this.personajes;
        }

        private string OtrosParametros(string tipoDePersonaje) // ACA sacarle "a" y hacer un try catch para ver si hay un NullException, tal vez también sirva para test unitarios
        {
            string retorno = "a";
            switch (tipoDePersonaje)
            {
                case "Cazarrecompensas":
                    retorno = "Nivel, Arma, Cazados FROM Cazarrecompensas";
                    break;
            }
            return retorno;
        }

        private string ObtenerTipoDePersonaje(List<Personaje> listaDePersonajes)
        {
            string retorno = "a";
            Personaje p = listaDePersonajes[0];

            switch (p)
            {
                case Cazarrecompensas:
                    retorno = "Cazarrecompensas";
                    break;
            }
            return retorno;
        }

        private void AgregarPersonaje(string tipoDePersonaje ,string nombre, int vida, int poder, string rareza)
        {
            Personaje personaje;

            switch (tipoDePersonaje)
            {
                case "Cazarrecompensas":
                    string nivel = this.lector["Nivel"].ToString();
                    string arma = this.lector["Arma"].ToString();
                    int cazados = (int)this.lector["Cazados"];

                    personaje = new Cazarrecompensas(nombre, vida, poder, TextoARareza(rareza), TextoAPrestigio(nivel), arma, cazados);
                    this.personajes.Add(personaje);
                    break;
            }
        }

        private ERarezas TextoARareza(string rarezaString)
        {
            ERarezas rareza = new ERarezas();

            switch (rarezaString)
            {
                case "Normal":
                    rareza = ERarezas.Normal;
                    break;
                case "Rara":
                    rareza = ERarezas.Rara;
                    break;
                case "Epica":
                    rareza = ERarezas.Epica;
                    break;
                case "Legendaria":
                    rareza = ERarezas.Legendaria;
                    break;
            }
            return rareza;
        }

        private ECazarrecompensasNivel TextoAPrestigio(string prestigio)
        {
            ECazarrecompensasNivel nivel = new ECazarrecompensasNivel();

            switch (prestigio)
            {
                case "Bajo":
                    nivel = ECazarrecompensasNivel.Bajo;
                    break;
                case "Mediano":
                    nivel = ECazarrecompensasNivel.Mediano;
                    break;
                case "Alto":
                    nivel = ECazarrecompensasNivel.Alto;
                    break;
                case "Leyenda":
                    nivel = ECazarrecompensasNivel.Leyenda;
                    break;
            }
            return nivel;
        }

    }
}
