using MenuDePersonajes.Properties;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace MenuDePersonajes
{
    public partial class frmLogin : Form
    {
        static string pathUsuarios;
        static List<Usuario> usuarios;
        static int intentosLog;
        static bool mostarContrase�a;

        public frmLogin()
        {
            InitializeComponent();
        }
        static frmLogin()
        {
            pathUsuarios = "./MOCK_DATA.json";
            usuarios = new List<Usuario>();
            intentosLog = 0;
            mostarContrase�a = false;
        }

        /// <summary>
        /// Si los datos del correo y contrase�a coinciden se ingresar� al men� principal
        /// Si los datos est�n incorrectos 5 veces seguidas se cerrar� la aplicaci�n y se llamar� a la polic�a
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtMail.Text))
            {
                MostrarMensaje("ingrese un correo", "correo vac�o", MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(this.txtContrase�a.Text))
            {
                MostrarMensaje("ingrese una contrase�a", "contrase�a vac�a", MessageBoxIcon.Information);
            }
            else
            {

                DeserealizarUsuarios();
                foreach (Usuario u in usuarios)
                {
                    if (u.correo == this.txtMail.Text && u.clave == this.txtContrase�a.Text)
                    {
                        this.Hide();
                        MenuPrincipal menu = new MenuPrincipal(u);
                        menu.ShowDialog();
                        this.Close();
                        intentosLog = 0;
                    }
                }
                intentosLog++;
                BloquearAcceso();
            }

        }

        /// <summary>
        /// Si los intentos de logueo llegan a 5 intentos se cerrar� la aplicaci�n
        /// </summary>
        private void BloquearAcceso()
        {
            if (intentosLog > 4)
            {
                MostrarMensaje("Se supero la cantidad de intentos de Logueo, se cerrar� la aplicaci�n. La polic�a ya tiene su ubicaci�n", "Bloqueo", MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
            {
                MostrarMensaje("Intente nuevamente", "Usuario no encontrado", MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Asigna la lista de usuarios a la serializacion del Json, estos usuarios son los que posteriormente se podr�n loguear
        /// </summary>
        static void DeserealizarUsuarios()
        {
            using (StreamReader sr = new StreamReader(pathUsuarios))
            {
                string jsonString = sr.ReadToEnd();

                usuarios = (List<Usuario>)JsonSerializer.Deserialize(jsonString, typeof(List<Usuario>));
            }
        }

        /// <summary>
        /// Si el usuario pulsa el boton de la contrase�a est� se podr� ver o no
        /// </summary>
        private void btnMostrarContrase�a_Click(object sender, EventArgs e)
        {
            if (mostarContrase�a)
            {
                mostarContrase�a = false;
                this.txtContrase�a.PasswordChar = '*';
                this.btnMostrarContrase�a.BackgroundImage = Resources.PasswordMostrar;

            }
            else
            {
                mostarContrase�a = true;
                this.txtContrase�a.PasswordChar = '\0';
                this.btnMostrarContrase�a.BackgroundImage = Resources.PasswordOcultar;
            }
        }


        /// <summary>
        /// Si se presiona enter funcionar� como si se presiona el bot�n
        /// </summary>
        private void txtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnAceptar_Click(sender, e);
            }
        }

        /// <summary>
        /// Si se presiona enter funcionar� como si se presiona el bot�n
        /// </summary>
        private void txtContrase�a_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnAceptar_Click(sender, e);
            }
        }

        /// <summary>
        /// Muestra un mensaje personalizado con el titulo, mensaje e icono proporcionados
        /// </summary>
        private void MostrarMensaje(string mensaje, string titulo, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        }

    }
}