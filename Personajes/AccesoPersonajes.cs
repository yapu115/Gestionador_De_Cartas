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

        public List<Cazarrecompensas> ObtenerListaCazarrecompensas()
        {
            List<Cazarrecompensas> cazarrecompensas = new List<Cazarrecompensas>();
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"SELECT Nombre, Vida, Poder, Rareza, Nivel_Prestigio, Arma, Clan Cazados FROM Personajes WHERE Tipo_De_Personaje = 'Cazarrecompensas'";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();
                while (this.lector.Read())
                {
                    string nombre = this.lector["Nombre"].ToString();
                    int vida = (int)this.lector["Vida"];
                    int poder = (int)this.lector["Poder"];
                    string rareza = this.lector["Rareza"].ToString();
                    string nivel = this.lector["Nivel_Prestigio"].ToString();
                    string arma = this.lector["Arma"].ToString();
                    int cazados = (int)this.lector["Cazados"];
                    string clan = this.lector["Clan"].ToString();

                    Cazarrecompensas c = new Cazarrecompensas(nombre, vida, poder, TextoARareza(rareza), TextoAPrestigio(nivel), arma, cazados, clan);
                    cazarrecompensas.Add(c);

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
            return cazarrecompensas;
        }

        public List<Mandaloriano> ObtenerListaMandalorianos()
        {
            List<Mandaloriano> mandalorianos = new List<Mandaloriano>();
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"SELECT Nombre, Vida, Poder, Rareza, Clan, Sable_Oscuro, Forajido, Arma FROM Personajes WHERE Tipo_De_Personaje = 'Mandaloriano'";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();
                while (this.lector.Read())
                {
                    string nombre = this.lector["Nombre"].ToString();
                    int vida = (int)this.lector["Vida"];
                    int poder = (int)this.lector["Poder"];
                    string rareza = this.lector["Rareza"].ToString();
                    string clan = this.lector["Clan"].ToString();
                    string sableOscuro = this.lector["Sable_Oscuro"].ToString();
                    string forajido = this.lector["Forajido"].ToString();
                    string arma = this.lector["Arma"].ToString();

                    Mandaloriano m = new Mandaloriano(nombre, vida, poder, TextoARareza(rareza), clan, TextoABool(forajido), TextoABool(sableOscuro));
                    mandalorianos.Add(m);

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
            return mandalorianos;
        }

        public List<Jedi> ObtenerListaJedis()
        {
            List<Jedi> jedis = new List<Jedi>();
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"SELECT Nombre, Vida, Poder, Rareza, Rango, Faccion, Color_Sable FROM Personajes WHERE Tipo_De_Personaje = 'Jedi'";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();
                while (this.lector.Read())
                {
                    string nombre = this.lector["Nombre"].ToString();
                    int vida = (int)this.lector["Vida"];
                    int poder = (int)this.lector["Poder"];
                    string rareza = this.lector["Rareza"].ToString();
                    string rango = this.lector["Rango"].ToString();
                    string faccion = this.lector["Faccion"].ToString();
                    string colorSable = this.lector["Color_Sable"].ToString();

                    Jedi j = new Jedi(nombre, vida, poder, TextoARareza(rareza), rango, faccion, TextoASablesJedi(colorSable));
                    jedis.Add(j);

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
            return jedis;
        }

        public List<Sith> ObtenerListaSiths()
        {
            List<Sith> siths = new List<Sith>();
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"SELECT Nombre, Vida, Poder, Rareza, Rango, Faccion, Color_Sable FROM Personajes WHERE Tipo_De_Personaje = 'Sith'";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = this.comando.ExecuteReader();
                while (this.lector.Read())
                {
                    string nombre = this.lector["Nombre"].ToString();
                    int vida = (int)this.lector["Vida"];
                    int poder = (int)this.lector["Poder"];
                    string rareza = this.lector["Rareza"].ToString();
                    string rango = this.lector["Rango"].ToString();
                    string faccion = this.lector["Faccion"].ToString();
                    string colorSable = this.lector["Color_Sable"].ToString();

                    Sith s = new Sith(nombre, vida, poder, TextoARareza(rareza), rango, faccion, TextoASablesSith(colorSable));
                    siths.Add(s);

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
            return siths;
        }

        public bool AgregarCazarrecompensas(Cazarrecompensas c)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@Nombre", c.Nombre);
                this.comando.Parameters.AddWithValue("@Vida", c.Vida);
                this.comando.Parameters.AddWithValue("@Poder", c.Poder);
                this.comando.Parameters.AddWithValue("@Rareza", RarezaATexto(c.Rareza));
                this.comando.Parameters.AddWithValue("@Nivel", NivelATexto(c.Nivel));
                this.comando.Parameters.AddWithValue("@Arma", c.Arma);
                this.comando.Parameters.AddWithValue("@Cazados", c.Cazados);
                this.comando.Parameters.AddWithValue("@Clan", c.Clan);
                this.comando.Parameters.AddWithValue("@Cazarrecompensas", "Cazarrecompensas");



                this.comando.CommandType = System.Data.CommandType.Text;

                //this.comando.CommandText = "UPDATE Cartas_Personajes SET Nombre = @Nombre, Vida = @Vida, Poder = @Poder, Rareza = @Rareza, Nivel = @Nivel, Arma = @PArma, Cazados = @Cazados WHERE Tipo_De_Personaje = Cazarrecompensas";
                this.comando.CommandText = "INSERT INTO Personajes (Nombre, Vida, Poder, Rareza, Nivel_Prestigio, Arma, Cazados, Clan, Tipo_De_Personaje) VALUES (@Nombre, @Vida, @Poder, @Rareza, @Nivel, @Arma, @Cazados, @Clan, @Cazarrecompensas)";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
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

        public bool AgregarMandaloriano(Mandaloriano m)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@Nombre", m.Nombre);
                this.comando.Parameters.AddWithValue("@Vida", m.Vida);
                this.comando.Parameters.AddWithValue("@Poder", m.Poder);
                this.comando.Parameters.AddWithValue("@Rareza", RarezaATexto(m.Rareza));
                this.comando.Parameters.AddWithValue("@Clan", m.Clan);
                this.comando.Parameters.AddWithValue("@Sable_Oscuro", m.SableOscuro);
                this.comando.Parameters.AddWithValue("@Forajido", m.Forajido);
                this.comando.Parameters.AddWithValue("@Arma", m.Arma);
                this.comando.Parameters.AddWithValue("@Mandaloriano", "Mandaloriano");



                this.comando.CommandType = System.Data.CommandType.Text;

                //this.comando.CommandText = "UPDATE Cartas_Personajes SET Nombre = @Nombre, Vida = @Vida, Poder = @Poder, Rareza = @Rareza, Nivel = @Nivel, Arma = @PArma, Cazados = @Cazados WHERE Tipo_De_Personaje = Cazarrecompensas";
                this.comando.CommandText = "INSERT INTO Personajes (Nombre, Vida, Poder, Rareza, Clan, Sable_Oscuro, Forajido, Arma, Tipo_De_Personaje) VALUES (@Nombre, @Vida, @Poder, @Rareza, @Clan, @Sable_Oscuro, @Forajido, @Arma, @Mandaloriano)";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
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


        public bool AgregarJedi(Jedi j)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@Nombre", j.Nombre);
                this.comando.Parameters.AddWithValue("@Vida", j.Vida);
                this.comando.Parameters.AddWithValue("@Poder", j.Poder);
                this.comando.Parameters.AddWithValue("@Rareza", RarezaATexto(j.Rareza));
                this.comando.Parameters.AddWithValue("@Rango", j.Rango);
                this.comando.Parameters.AddWithValue("@Faccion", j.Faccion);
                this.comando.Parameters.AddWithValue("@Color_Sable", j.ColorDeSable);
                this.comando.Parameters.AddWithValue("@Jedi", "Jedi");



                this.comando.CommandType = System.Data.CommandType.Text;

                //this.comando.CommandText = "UPDATE Cartas_Personajes SET Nombre = @Nombre, Vida = @Vida, Poder = @Poder, Rareza = @Rareza, Nivel = @Nivel, Arma = @PArma, Cazados = @Cazados WHERE Tipo_De_Personaje = Cazarrecompensas";
                this.comando.CommandText = "INSERT INTO Personajes (Nombre, Vida, Poder, Rareza, Rango, Faccion, Color_Sable, Tipo_De_Personaje) VALUES (@Nombre, @Vida, @Poder, @Rareza, @Rango, @Faccion, @Color_Sable, @Jedi)";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
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


        public bool AgregarSith(Sith s)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@Nombre", s.Nombre);
                this.comando.Parameters.AddWithValue("@Vida", s.Vida);
                this.comando.Parameters.AddWithValue("@Poder", s.Poder);
                this.comando.Parameters.AddWithValue("@Rareza", RarezaATexto(s.Rareza));
                this.comando.Parameters.AddWithValue("@Rango", s.Rango);
                this.comando.Parameters.AddWithValue("@Faccion", s.Faccion);
                this.comando.Parameters.AddWithValue("@Color_Sable", s.ColorDeSable);
                this.comando.Parameters.AddWithValue("@Sith", "Sith");



                this.comando.CommandType = System.Data.CommandType.Text;

                //this.comando.CommandText = "UPDATE Cartas_Personajes SET Nombre = @Nombre, Vida = @Vida, Poder = @Poder, Rareza = @Rareza, Nivel = @Nivel, Arma = @PArma, Cazados = @Cazados WHERE Tipo_De_Personaje = Cazarrecompensas";
                this.comando.CommandText = "INSERT INTO Personajes (Nombre, Vida, Poder, Rareza, Rango, Faccion, Color_Sable, Tipo_De_Personaje) VALUES (@Nombre, @Vida, @Poder, @Rareza, @Rango, @Faccion, @Color_Sable, @Sith)";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    retorno = true;
                }
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

        /*
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

                    AgregarPersonaje(tipoDePersonaje, nombre, vida, poder, rareza);
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
        */
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

        private bool TextoABool(string respuesta)
        {
            bool retorno = false;
            if (respuesta == "Si")
            {
                retorno = true;
            }
            return retorno;
        }




        /// <summary>
        /// Cambia el formato del texto ingresado en las boxes de datos a un formato de EJediColoresSables
        /// </summary>
        private EJediColoresSables TextoASablesJedi(string colorSable)
        {
            EJediColoresSables color = new EJediColoresSables();

            switch (colorSable)
            {
                case "Azul":
                    color = EJediColoresSables.Azul;
                    break;
                case "Verde":
                    color = EJediColoresSables.Verde;
                    break;
                case "Purpura":
                    color = EJediColoresSables.Purpura;
                    break;
                case "Blanco":
                    color = EJediColoresSables.Blanco;
                    break;
                case "Amarillo":
                    color = EJediColoresSables.Amarillo;
                    break;
            }
            return color;
        }


        /// <summary>
        /// Cambia el formato del texto ingresado en las boxes de datos a un formato de ESithColoresSables
        /// </summary>
        private ESithColoresSables TextoASablesSith(string colorSable)
        {
            ESithColoresSables color = new ESithColoresSables();

            switch (colorSable)
            {
                case "Rojo":
                    color = ESithColoresSables.Rojo;
                    break;
                case "Purpura":
                    color = ESithColoresSables.Purpura;
                    break;
                case "Naranja":
                    color = ESithColoresSables.Naranja;
                    break;
            }
            return color;

        }

        private string RarezaATexto(ERarezas rareza)
        {
            string texto = "";
            switch (rareza)
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

        private string NivelATexto(ECazarrecompensasNivel nivel)
        {
            string texto = "";
            switch (nivel)
            {
                case ECazarrecompensasNivel.Bajo:
                    texto = "Bajo";
                    break;
                case ECazarrecompensasNivel.Mediano:
                    texto = "Mediano";
                    break;
                case ECazarrecompensasNivel.Alto:
                    texto = "Alto";
                    break;
                case ECazarrecompensasNivel.Leyenda:
                    texto = "Leyenda";
                    break;
            }
            return texto;
        }
    }
}
