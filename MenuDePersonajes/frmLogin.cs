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
        static bool mostarContraseña;

        public frmLogin()
        {
            InitializeComponent();
        }
        static frmLogin()
        {
            pathUsuarios = "./MOCK_DATA.json";
            usuarios = new List<Usuario>();
            intentosLog = 0;
            mostarContraseña = false;
        }

        /// <summary>
        /// Si los datos del correo y contraseña coinciden se ingresará al menú principal
        /// Si los datos están incorrectos 5 veces seguidas se cerrará la aplicación y se llamará a la policía
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtMail.Text))
            {
                MostrarMensaje("ingrese un correo", "correo vacío", MessageBoxIcon.Information);
            }
            else if (string.IsNullOrEmpty(this.txtContraseña.Text))
            {
                MostrarMensaje("ingrese una contraseña", "contraseña vacía", MessageBoxIcon.Information);
            }
            else
            {

                DeserealizarUsuarios();
                foreach (Usuario u in usuarios)
                {
                    if (u.correo == this.txtMail.Text && u.clave == this.txtContraseña.Text)
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
        /// Si los intentos de logueo llegan a 5 intentos se cerrará la aplicación
        /// </summary>
        private void BloquearAcceso()
        {
            if (intentosLog > 4)
            {
                MostrarMensaje("Se supero la cantidad de intentos de Logueo, se cerrará la aplicación. La policía ya tiene su ubicación", "Bloqueo", MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
            {
                MostrarMensaje("Intente nuevamente", "Usuario no encontrado", MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Asigna la lista de usuarios a la serializacion del Json, estos usuarios son los que posteriormente se podrán loguear
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
        /// Si el usuario pulsa el boton de la contraseña está se podrá ver o no
        /// </summary>
        private void btnMostrarContraseña_Click(object sender, EventArgs e)
        {
            if (mostarContraseña)
            {
                mostarContraseña = false;
                this.txtContraseña.PasswordChar = '*';
                this.btnMostrarContraseña.BackgroundImage = Resources.PasswordMostrar;

            }
            else
            {
                mostarContraseña = true;
                this.txtContraseña.PasswordChar = '\0';
                this.btnMostrarContraseña.BackgroundImage = Resources.PasswordOcultar;
            }
        }


        /// <summary>
        /// Si se presiona enter funcionará como si se presiona el botón
        /// </summary>
        private void txtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnAceptar_Click(sender, e);
            }
        }

        /// <summary>
        /// Si se presiona enter funcionará como si se presiona el botón
        /// </summary>
        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
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