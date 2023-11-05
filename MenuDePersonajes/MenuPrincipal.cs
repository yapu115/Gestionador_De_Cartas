using MenuDePersonajes.Properties;
using Personajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MenuDePersonajes
{
    public partial class MenuPrincipal : Form
    {
        static MazoDeCartas mazoPersonal;
        static string pathSerializaciones;
        static string pathSerializacionesCartas;
        static System.Text.Encoding miEncoding;
        static string tipoDePersonaje;
        static List<string> datosUsuarios;
        private Usuario usuarioLogueado;

        public MenuPrincipal()
        {
            InitializeComponent();
            miEncoding = System.Text.Encoding.UTF8;
            datosUsuarios = new List<string>();
            ActualizarVisor();
        }
        static MenuPrincipal()
        {
            mazoPersonal = new MazoDeCartas();
            miEncoding = System.Text.Encoding.UTF8;
            tipoDePersonaje = "Jedi";
            pathSerializaciones = @"..\..\..\ArchivosSerializacion";
        }
        public MenuPrincipal(Usuario uLogueado) : this()
        {
            this.usuarioLogueado = uLogueado;
            pathSerializacionesCartas = pathSerializaciones + $@"\{usuarioLogueado.nombre}";
            this.lblInfoUsuario.Text = usuarioLogueado.Mostrar();
            SerializarDatosUsuario();
        }


        /// <summary>
        /// Al cargarse el formulario se deserializan todas las listas del mazo personal
        /// y se inicializan los criterios de ordenamiento de listas
        /// </summary>
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            mazoPersonal.DeserealizarJedis(pathSerializacionesCartas);
            mazoPersonal.DeserealizarSiths(pathSerializacionesCartas);
            mazoPersonal.DeserealizarMandalorianos(pathSerializacionesCartas);
            mazoPersonal.DeserealizarCazarrecompensas(pathSerializacionesCartas);
            this.bxOrdenarVidaPoder.Text = "Vida";
            this.bxOrdenarAscDesc.Text = "Ascendente";
            ActualizarOrdenamiento();
            ActualizarPantalla();
        }


        /// <summary>
        /// Abre un form para agregar una nueva carta a la lista, según el tipo de personaje que se haya elegio
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            switch (tipoDePersonaje)
            {
                case "Jedi":
                    ElegirTipoDeCarta("Jedi");
                    break;
                case "Sith":
                    ElegirTipoDeCarta("Sith");
                    break;
                case "Mandaloriano":
                    ElegirTipoDeCarta("Mandaloriano");
                    break;
                case "Cazarrecompensas":
                    ElegirTipoDeCarta("Cazarrecompensas");
                    break;
            }
        }

        /// <summary>
        /// Abre un form para cambiar los datos de una carta seleccionada
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indice = this.lstVisor.SelectedIndex;

            if (indice == -1)
            {
                MessageBox.Show("Debe seleccionar una carta primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ModificarCarta(indice);
            }
        }

        /// <summary>
        /// Abre un form para eliiminar la carta seleccionada
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = this.lstVisor.SelectedIndex;

            if (indice == -1)
            {
                MessageBox.Show("Debe seleccionar una carta primero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                EliminarCarta(indice);
            }
        }
        private void jediToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipoDePersonaje = "Jedi";
            ActualizarPantalla();
            ActualizarVisor();
        }

        private void sithToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipoDePersonaje = "Sith";
            ActualizarPantalla();
            ActualizarVisor();
        }

        private void mandalorianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipoDePersonaje = "Mandaloriano";
            ActualizarPantalla();
            ActualizarVisor();
        }

        private void cazarrecompensasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipoDePersonaje = "Cazarrecompensas";
            ActualizarPantalla();
            ActualizarVisor();
        }

        /// <summary>
        /// Si el usuario cierra la aplicacion luego de un mensaje se serializan todas las listas que tenía
        /// </summary>
        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult salir = MessageBox.Show("Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (salir == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                if (!Directory.Exists(pathSerializacionesCartas))
                {
                    Directory.CreateDirectory(pathSerializacionesCartas);
                }
                mazoPersonal.SerializarJedis(pathSerializacionesCartas);
                mazoPersonal.SerializarSiths(pathSerializacionesCartas);
                mazoPersonal.SerializarCazarrecompensas(pathSerializacionesCartas);
                mazoPersonal.SerializarMandalorianos(pathSerializacionesCartas);

            }
        }


        /// <summary>
        /// A partir del dato ingresado crea un formulario Carta y si todos los datos son correctos 
        /// se agrega la carta a la lista, si es una carta repetida se avisará de ello y no se agregará
        /// </summary>
        private void ElegirTipoDeCarta(string carta)
        {
            frmCarta frmCarta = new frmCarta(carta);
            frmCarta.ShowDialog();

            if (frmCarta.DialogResult == DialogResult.OK)
            {
                Personaje p = frmCarta.PersonajeDelFormulario;
                if (mazoPersonal + p)
                {
                    ActualizarOrdenamiento();
                    MessageBox.Show("La carta ha sido creada", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("La carta ya había sido agregada", "Carta repetida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }


        /// <summary>
        /// Según el tipo de personaje actual y el indice ingresado se crea un frmCarta que nos permitirá modificar todos
        /// los dato que quiera el usuario.
        /// </summary>
        private void ModificarCarta(int indice)
        {
            switch (tipoDePersonaje)
            {
                case "Jedi":
                    Jedi jModificar = mazoPersonal.CartasJedi[indice];

                    frmCarta frmJ = new frmCarta(jModificar, true);
                    frmJ.ShowDialog();

                    if (frmJ.DialogResult == DialogResult.OK)
                    {
                        mazoPersonal.CartasJedi[indice] = (Jedi)frmJ.PersonajeDelFormulario;
                    }
                    break;
                case "Sith":
                    Sith sModificar = mazoPersonal.CartasSith[indice];

                    frmCarta frmS = new frmCarta(sModificar, true);
                    frmS.ShowDialog();

                    if (frmS.DialogResult == DialogResult.OK)
                    {
                        mazoPersonal.CartasSith[indice] = (Sith)frmS.PersonajeDelFormulario;
                    }
                    break;
                case "Mandaloriano":
                    Mandaloriano mModificar = mazoPersonal.CartasMandalorianos[indice];

                    frmCarta frmM = new frmCarta(mModificar, true);
                    frmM.ShowDialog();

                    if (frmM.DialogResult == DialogResult.OK)
                    {
                        mazoPersonal.CartasMandalorianos[indice] = (Mandaloriano)frmM.PersonajeDelFormulario;
                    }
                    break;
                case "Cazarrecompensas":
                    Cazarrecompensas cModificar = mazoPersonal.CartasCazarrecompensas[indice];

                    frmCarta frmC = new frmCarta(cModificar, true);
                    frmC.ShowDialog();

                    if (frmC.DialogResult == DialogResult.OK)
                    {
                        mazoPersonal.CartasCazarrecompensas[indice] = (Cazarrecompensas)frmC.PersonajeDelFormulario;
                    }
                    break;
            }
            ActualizarVisor();
        }


        /// <summary>
        /// Según el tipo de personaje actual y el indice ingresado se crea un frmCarta que nos permitirá eliminar la carta
        /// seleccionada 
        /// </summary>
        private void EliminarCarta(int indice)
        {
            switch (tipoDePersonaje)
            {
                case "Jedi":
                    Jedi jEliminar = mazoPersonal.CartasJedi[indice];

                    frmCarta frmJ = new frmCarta(jEliminar, false);
                    frmJ.ShowDialog();

                    ConfirmarEliminar(frmJ, jEliminar);
                    break;
                case "Sith":
                    Sith sEliminar = mazoPersonal.CartasSith[indice];

                    frmCarta frmS = new frmCarta(sEliminar, false);
                    frmS.ShowDialog();

                    ConfirmarEliminar(frmS, sEliminar);
                    break;
                case "Mandaloriano":
                    Mandaloriano mEliminar = mazoPersonal.CartasMandalorianos[indice];

                    frmCarta frmM = new frmCarta(mEliminar, false);
                    frmM.ShowDialog();

                    ConfirmarEliminar(frmM, mEliminar);
                    break;
                case "Cazarrecompensas":
                    Cazarrecompensas cEliminar = mazoPersonal.CartasCazarrecompensas[indice];

                    frmCarta frmC = new frmCarta(cEliminar, false);
                    frmC.ShowDialog();

                    ConfirmarEliminar(frmC, cEliminar);
                    break;
            }
        }

        /// <summary>
        /// Si el DialogResult de un form ingresado es OK se eliminará el personaje ingresado del mazo personal
        /// </summary>
        private void ConfirmarEliminar(frmCarta f, Personaje p)
        {
            if (f.DialogResult == DialogResult.OK)
            {
                mazoPersonal -= p;
                ActualizarOrdenamiento();
                MessageBox.Show("Carta Eliminada", "Se eliminó correctamente la carta de la lista", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// Limpia todos los datos del ListBox para luego reincorporarlos (por si se haya producido un cambio)
        /// </summary>
        private void ActualizarVisor()
        {
            this.lstVisor.Items.Clear();
            switch (tipoDePersonaje)
            {
                case "Jedi":
                    foreach (Jedi cartaJedi in mazoPersonal.CartasJedi)
                    {
                        this.lstVisor.Items.Add(cartaJedi.ToString());
                    }
                    break;
                case "Sith":
                    foreach (Sith cartaSith in mazoPersonal.CartasSith)
                    {
                        this.lstVisor.Items.Add(cartaSith.ToString());
                    }
                    break;
                case "Mandaloriano":
                    foreach (Mandaloriano cartaMandaloriano in mazoPersonal.CartasMandalorianos)
                    {
                        this.lstVisor.Items.Add(cartaMandaloriano.ToString());
                    }
                    break;
                case "Cazarrecompensas":
                    foreach (Cazarrecompensas cartaCazarrecompensa in mazoPersonal.CartasCazarrecompensas)
                    {
                        this.lstVisor.Items.Add(cartaCazarrecompensa.ToString());
                    }
                    break;
            }
        }

        /// <summary>
        /// Cambia la imágen, el fondo y el lable de carta según el tipo de personaje que es seleccionado
        /// </summary>
        private void ActualizarPantalla()
        {
            switch (tipoDePersonaje)
            {
                case "Jedi":
                    this.pcBxPersonaje.Image = Resources.ImagenJedi;
                    this.lblCartas.Text = "Cartas de Jedis: ";
                    this.BackColor = Color.FromArgb(0, 102, 51);
                    break;
                case "Sith":
                    this.pcBxPersonaje.Image = Resources.ImagenSith;
                    this.lblCartas.Text = "Cartas de Siths: ";
                    this.BackColor = Color.FromArgb(32, 32, 32);
                    break;
                case "Mandaloriano":
                    this.pcBxPersonaje.Image = Resources.imagenMandalorianos;
                    this.lblCartas.Text = "Cartas de Mandalorianos: ";
                    this.BackColor = Color.FromArgb(0, 153, 153);
                    break;
                case "Cazarrecompensas":
                    this.pcBxPersonaje.Image = Resources.ImagenCazarrecompensas;
                    this.lblCartas.Text = "Cartas de Cazarrecompensas: ";
                    this.BackColor = Color.FromArgb(153, 76, 0);
                    break;
            }
            this.pcBxPersonaje.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        /// <summary>
        /// Primero verifica si exite el directorio del path, si no es así lo crea
        /// Luego Serializa el string que devolverá el método DatosParaSerializar del usuario logueado
        /// </summary>
        public void SerializarDatosUsuario()
        {
            if (!Directory.Exists(pathSerializaciones))
                Directory.CreateDirectory(pathSerializaciones);
            else
                DeserealizarDatosUsuario();
            string pathSerializacionUsuarios = pathSerializaciones + @"\usuarios.Log";
            datosUsuarios.Add(this.usuarioLogueado.DatosParaSerializar());

            JsonSerializerOptions serializador = new JsonSerializerOptions();
            serializador.WriteIndented = true;

            string objJson = JsonSerializer.Serialize(datosUsuarios, serializador);

            using (StreamWriter sw = new StreamWriter(pathSerializacionUsuarios))
            {
                sw.WriteLine(objJson);
            }

        }

        /// <summary>
        /// Primero verifica si el archivo existe y si es así se Deserializa.
        /// </summary>
        public void DeserealizarDatosUsuario()
        {
            string pathUsuariosSerializados = pathSerializaciones + @"\usuarios.Log";
            if (File.Exists(pathUsuariosSerializados))
            {
                using (StreamReader sr = new StreamReader(pathUsuariosSerializados))
                {
                    string jsonString = sr.ReadToEnd();

                    datosUsuarios = (List<string>)JsonSerializer.Deserialize(jsonString, typeof(List<string>));
                }
            }
        }

        /// <summary>
        /// Recupera el texto de las opciones de ordenamiento y según esa información utiliza los 
        /// métodos del mazo personal para ordenar las cartas
        /// </summary>
        private void ActualizarOrdenamiento()
        {
            string ordenamiento1 = this.bxOrdenarVidaPoder.Text;
            string ordenamiento2 = this.bxOrdenarAscDesc.Text;

            if (ordenamiento1 == "Vida")
            {
                if (ordenamiento2 == "Ascendente")
                {
                    mazoPersonal.OrdenarPorVidaAscendente();
                }
                else if (ordenamiento2 == "Descendente")
                {
                    mazoPersonal.OrdenarPorVidaDescendente();
                }
            }
            else if (ordenamiento1 == "Poder")
            {
                if (ordenamiento2 == "Ascendente")
                {
                    mazoPersonal.OrdenarPorPoderAscendente();
                }
                else if (ordenamiento2 == "Descendente")
                {
                    mazoPersonal.OrdenarPorPoderDescendente();
                }
            }
            ActualizarVisor();

        }


        /// <summary>
        /// Si cambia la Combobox del criterio de ordenamiento de vida/Poder se llama 
        /// al método ActualizarOrdenamiento
        /// </summary>
        private void bxOrdenarVidaPoder_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarOrdenamiento();
        }

        /// <summary>
        /// Si cambia la Combobox del criterio de ordenamiento de Ascendente/Desendente se llama 
        /// al método ActualizarOrdenamiento
        /// </summary>
        private void bcOrdenarAscDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarOrdenamiento();
        }


        /// <summary>
        /// Si se presiona en el boton de logueos se deserializarán los datos de los usuarios y
        /// se creará un frmUsuarios
        /// </summary>
        private void btnLogueos_Click(object sender, EventArgs e)
        {
            DeserealizarDatosUsuario();
            frmUsuarios frmUsuarios = new frmUsuarios(datosUsuarios);
            frmUsuarios.ShowDialog();
        }


        private void lstVisor_DrawItem(object sender, DrawItemEventArgs e)
        {
        }

    }
}
