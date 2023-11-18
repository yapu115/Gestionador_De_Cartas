using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Microsoft.Data.SqlClient;

namespace Personajes
{
    public class AccesoPersonajes: IListasDePersonajes
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

        /// <summary>
        /// Recupera la lista de Jedis de la tabla de personajes de la base de datos
        /// </summary>
        public List<Jedi> ObtenerListaJedis()
        {
            bool error = false;
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
                error = true;
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            if (error)
            {
                throw new Exception();
            }
            return jedis;
        }

        /// <summary>
        /// Recupera la lista de Siths de la tabla de personajes de la base de datos
        /// </summary>
        public List<Sith> ObtenerListaSiths()
        {
            bool error = false;
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
                error = true;

            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            if (error)
            {
                throw new Exception();
            }
            return siths;
        }

        /// <summary>
        /// Recupera la lista de Mandalorianos de la tabla de personajes de la base de datos
        /// </summary>
        public List<Mandaloriano> ObtenerListaMandalorianos()
        {
            bool error = false;
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

                    Mandaloriano m = new Mandaloriano(nombre, vida, poder, TextoARareza(rareza), clan, TextoABool(forajido), TextoABool(sableOscuro), arma);
                    mandalorianos.Add(m);

                }
                this.lector.Close();
            }
            catch (Exception ex)
            {
                error = true;
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            if (error)
            {
                throw new Exception();
            }
            return mandalorianos;
        }

        /// <summary>
        /// Recupera la lista de Cazarrecompensas de la tabla de personajes de la base de datos
        /// </summary>
        public List<Cazarrecompensas> ObtenerListaCazarrecompensas()
        {
            bool error = false;
            List<Cazarrecompensas> cazarrecompensas = new List<Cazarrecompensas>();
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = $"SELECT Nombre, Vida, Poder, Rareza, Nivel_Prestigio, Arma, Clan, Cazados FROM Personajes WHERE Tipo_De_Personaje = 'Cazarrecompensas'";
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
                error = true;
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            if (error)
            {
                throw new Exception();
            }
            return cazarrecompensas;
        }



        /// <summary>
        /// Agrega el Cazarrecompensas a la tabla de personajes de base de datos
        /// </summary>
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
                throw new CRUDException("Error al intentar agregar el personaje");
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

        /// <summary>
        /// Agrega el Mandaloriano a la tabla de personajes de base de datos
        /// </summary>
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
                throw new CRUDException("Error al intentar agregar el personaje");
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

        /// <summary>
        /// Agrega el jedi a la tabla de personajes de base de datos
        /// </summary>
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

        /// <summary>
        /// Agrega el Sith a la tabla de personajes de base de datos
        /// </summary>
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
                throw new CRUDException("Error al intentar agregar el personaje");
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


        /// <summary>
        /// Elimina el Personaje de la tabla de personajes de base de datos
        /// </summary>
        public bool EliminarPersonaje(Personaje p)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@Nombre", p.Nombre);
                this.comando.Parameters.AddWithValue("@Vida", p.Vida);
                this.comando.Parameters.AddWithValue("@Poder", p.Poder);
                this.comando.Parameters.AddWithValue("@Rareza", RarezaATexto(p.Rareza));



                this.comando.CommandType = System.Data.CommandType.Text;

                //this.comando.CommandText = "UPDATE Cartas_Personajes SET Nombre = @Nombre, Vida = @Vida, Poder = @Poder, Rareza = @Rareza, Nivel = @Nivel, Arma = @PArma, Cazados = @Cazados WHERE Tipo_De_Personaje = Cazarrecompensas";
                this.comando.CommandText = "DELETE FROM Personajes WHERE Nombre = @Nombre AND Vida = @Vida AND Poder = @Poder AND Rareza = @Rareza";
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
                throw new CRUDException("Error al intentar eliminar el personaje");
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


        /// <summary>
        /// Modifica el cazarrecompensas de la tabla de base de datos
        /// </summary>
        public bool ModificarCazarrecompensas(Cazarrecompensas c1, Cazarrecompensas c2)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@Nombre1", c1.Nombre);
                this.comando.Parameters.AddWithValue("@Vida1", c1.Vida);
                this.comando.Parameters.AddWithValue("@Poder1", c1.Poder);
                this.comando.Parameters.AddWithValue("@Rareza1", RarezaATexto(c1.Rareza));

                this.comando.Parameters.AddWithValue("@Nombre2", c2.Nombre);
                this.comando.Parameters.AddWithValue("@Vida2", c2.Vida);
                this.comando.Parameters.AddWithValue("@Poder2", c2.Poder);
                this.comando.Parameters.AddWithValue("@Rareza2", RarezaATexto(c2.Rareza));
                this.comando.Parameters.AddWithValue("@Nivel2", NivelATexto(c2.Nivel));
                this.comando.Parameters.AddWithValue("@Arma2", c2.Arma);
                this.comando.Parameters.AddWithValue("@Cazados2", c2.Cazados);
                this.comando.Parameters.AddWithValue("@Clan2", c2.Clan);

                this.comando.CommandType = System.Data.CommandType.Text;

                this.comando.CommandText = "UPDATE Personajes SET Nombre = @Nombre2, Vida = @Vida2, Poder = @Poder2, Rareza = @Rareza2, Nivel_Prestigio = @Nivel2, Arma = @Arma2, Cazados = @Cazados2, Clan = @Clan2 WHERE Nombre = @Nombre1 AND Vida = @Vida1 AND Poder = @Poder1 AND Rareza = @Rareza1";
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
                throw new CRUDException("Error al intentar modificar el personaje");
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

        /// <summary>
        /// Modifica el Jedi de la tabla de base de datos
        /// </summary>
        public bool ModificarJedi(Jedi j1, Jedi j2)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@Nombre1", j1.Nombre);
                this.comando.Parameters.AddWithValue("@Vida1", j1.Vida);
                this.comando.Parameters.AddWithValue("@Poder1", j1.Poder);
                this.comando.Parameters.AddWithValue("@Rareza1", RarezaATexto(j1.Rareza));

                this.comando.Parameters.AddWithValue("@Nombre2", j2.Nombre);
                this.comando.Parameters.AddWithValue("@Vida2", j2.Vida);
                this.comando.Parameters.AddWithValue("@Poder2", j2.Poder);
                this.comando.Parameters.AddWithValue("@Rareza2", RarezaATexto(j2.Rareza));
                this.comando.Parameters.AddWithValue("@Rango2", j2.Rango);
                this.comando.Parameters.AddWithValue("@Faccion2", j2.Faccion);
                this.comando.Parameters.AddWithValue("@Color_Sable2", j2.ColorDeSable);

                this.comando.CommandType = System.Data.CommandType.Text;

                this.comando.CommandText = "UPDATE Personajes SET Nombre = @Nombre2, Vida = @Vida2, Poder = @Poder2, Rareza = @Rareza2, Rango = @Rango2, Faccion = @Faccion2, Color_Sable = @Color_Sable2 WHERE Nombre = @Nombre1 AND Vida = @Vida1 AND Poder = @Poder1 AND Rareza = @Rareza1";
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
                throw new CRUDException("Error al intentar modificar el personaje");
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

        /// <summary>
        /// Modifica el Sith de la tabla de base de datos
        /// </summary>
        public bool ModificarSith(Sith s1, Sith s2)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@Nombre1", s1.Nombre);
                this.comando.Parameters.AddWithValue("@Vida1", s1.Vida);
                this.comando.Parameters.AddWithValue("@Poder1", s1.Poder);
                this.comando.Parameters.AddWithValue("@Rareza1", RarezaATexto(s1.Rareza));

                this.comando.Parameters.AddWithValue("@Nombre2", s2.Nombre);
                this.comando.Parameters.AddWithValue("@Vida2", s2.Vida);
                this.comando.Parameters.AddWithValue("@Poder2", s2.Poder);
                this.comando.Parameters.AddWithValue("@Rareza2", RarezaATexto(s2.Rareza));
                this.comando.Parameters.AddWithValue("@Rango2", s2.Rango);
                this.comando.Parameters.AddWithValue("@Faccion2", s2.Faccion);
                this.comando.Parameters.AddWithValue("@Color_Sable2", s2.ColorDeSable);

                this.comando.CommandType = System.Data.CommandType.Text;

                this.comando.CommandText = "UPDATE Personajes SET Nombre = @Nombre2, Vida = @Vida2, Poder = @Poder2, Rareza = @Rareza2, Rango = @Rango2, Faccion = @Faccion2, Color_Sable = @Color_Sable2 WHERE Nombre = @Nombre1 AND Vida = @Vida1 AND Poder = @Poder1 AND Rareza = @Rareza1";
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
                throw new CRUDException("Error al intentar modificar el personaje");
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

        /// <summary>
        /// Modifica mandaloriano de la tabla de base de datos
        /// </summary>
        public bool ModificarMandaloriano(Mandaloriano m1, Mandaloriano m2)
        {
            bool retorno = false;

            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@Nombre1", m1.Nombre);
                this.comando.Parameters.AddWithValue("@Vida1", m1.Vida);
                this.comando.Parameters.AddWithValue("@Poder1", m1.Poder);
                this.comando.Parameters.AddWithValue("@Rareza1", RarezaATexto(m1.Rareza));

                this.comando.Parameters.AddWithValue("@Nombre2", m2.Nombre);
                this.comando.Parameters.AddWithValue("@Vida2", m2.Vida);
                this.comando.Parameters.AddWithValue("@Poder2", m2.Poder);
                this.comando.Parameters.AddWithValue("@Rareza2", RarezaATexto(m2.Rareza));
                this.comando.Parameters.AddWithValue("@Clan2", m2.Clan);
                this.comando.Parameters.AddWithValue("@Sable_Oscuro2", (m2.SableOscuro));
                this.comando.Parameters.AddWithValue("@Forajido2", m2.Forajido);
                this.comando.Parameters.AddWithValue("@Arma2", m2.Arma);

                this.comando.CommandType = System.Data.CommandType.Text;

                this.comando.CommandText = "UPDATE Personajes SET Nombre = @Nombre2, Vida = @Vida2, Poder = @Poder2, Rareza = @Rareza2, Clan = @Clan2, Arma = @Arma2, Sable_Oscuro = @Sable_Oscuro2, Forajido = @Forajido2 WHERE Nombre = @Nombre1 AND Vida = @Vida1 AND Poder = @Poder1 AND Rareza = @Rareza1";
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
                throw new CRUDException("Error al intentar modificar el personaje");
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
