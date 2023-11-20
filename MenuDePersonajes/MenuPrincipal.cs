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
using Excepciones;

namespace MenuDePersonajes
{
    public partial class MenuPrincipal : Form
    {
        static MazoDeCartas mazoPersonal;

        static string pathSerializaciones;
        static string pathSerializacionesCartas;
        static System.Text.Encoding miEncoding;

        static string tipoDePersonaje;
        static string tipoDePerfil;

        static List<string> datosUsuarios;
        private Usuario usuarioLogueado;

        static DateTime tiempoInicio;

        static string pathImagenes;
        static List<string> imagenesJedi;
        static List<string> imagenesSith;
        static List<string> imagenesMandalorianos;
        static List<string> imagenesCazarrecompensas;

        private CancellationToken cancelacion;
        private CancellationTokenSource cancelacionSource;

        static bool LuegoDeprimeraIteracion;
        static bool desactivarGuardado;

        private event DelegadoNotificarError MensajeError;
        private event DelegadoAbrirfrmCartaVacio CartaVacia;
        private event DelegadoAbrirFrmCartaEliminar CartaAEliminar;
        private event DelegadoAbrirFrmCartaModificar CartaAModificar;

        public MenuPrincipal()
        {
            InitializeComponent();
            miEncoding = System.Text.Encoding.UTF8;
            datosUsuarios = new List<string>();

            this.cancelacionSource = new CancellationTokenSource();
            this.cancelacion = this.cancelacionSource.Token;

            MensajeError += MostarMensajeDeError;
            CartaVacia += ElegirTipoDeCarta;
            CartaAEliminar = EliminarCarta;
            CartaAModificar = ModificarCarta;
        }
        static MenuPrincipal()
        {
            miEncoding = System.Text.Encoding.UTF8;
            tipoDePersonaje = "Jedi";
            pathSerializaciones = @"..\..\..\ArchivosSerializacion";
            pathImagenes = @"..\..\..\Imagenes";

            imagenesJedi = new List<string>();
            imagenesSith = new List<string>();
            imagenesMandalorianos = new List<string>();
            imagenesCazarrecompensas = new List<string>();

            LuegoDeprimeraIteracion = false;
            desactivarGuardado = false;
            tiempoInicio = DateTime.Now;
        }
        public MenuPrincipal(Usuario uLogueado) : this()
        {
            this.usuarioLogueado = uLogueado;
            ValidarPerfil(usuarioLogueado);
            pathSerializacionesCartas = pathSerializaciones + $@"\{usuarioLogueado.nombre}";
            mazoPersonal = new MazoDeCartas(pathSerializacionesCartas);
            this.lblInfoUsuario.Text = usuarioLogueado.Mostrar();
            InicializarListasImagenes();
            SerializarDatosUsuario();
        }


        /// <summary>
        /// Al cargarse el formulario se deserializan todas las listas del mazo personal
        /// y se inicializan los criterios de ordenamiento de listas
        /// </summary>
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            this.boxTipoDeGuardado.Text = "Tablas";
            this.bxOrdenarVidaPoder.Text = "Vida";
            this.bxOrdenarAscDesc.Text = "Ascendente";
            LuegoDeprimeraIteracion = true;

            ActualizarOrdenamiento();
            ActualizarPantalla();

            Task t = Task.Run(() => MostrarImagenes());
            Task t3 = Task.Run(() => MostrarTiempoEnAplicacion());

            if (tipoDePerfil != "administrador")
                this.btnEliminar.Enabled = false;

            if (tipoDePerfil == "vendedor")
            {
                this.btnModificar.Enabled = false;
                this.btnAgregar.Enabled = false;
            }
        }


        /// <summary>
        /// Abre un form para agregar una nueva carta a la lista, según el tipo de personaje que se haya elegio
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (CartaVacia is not null)
            {
                CartaVacia(tipoDePersonaje);
            }
        }

        /// <summary>
        /// Abre un form para cambiar los datos de una carta seleccionada
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indice = this.lstVisor.SelectedIndex;

            try
            {
                if (indice == -1)
                {
                    throw new IndiceNoSeleccionadoException("No se seleccionó una carta");
                }
                if (CartaAModificar is not null)
                {
                    CartaAModificar(indice);
                }
            }
            catch (IndiceNoSeleccionadoException ex)
            {
                if (this.MensajeError is not null)
                {
                    this.MensajeError(ex.Message);
                }
            }
        }

        /// <summary>
        /// Abre un form para eliiminar la carta seleccionada
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = this.lstVisor.SelectedIndex;

            try
            {
                if (indice == -1)
                {
                    throw new IndiceNoSeleccionadoException("No se seleccionó una carta");
                }
                if (CartaAEliminar is not null)
                {
                    CartaAEliminar(indice);
                }
            }
            catch (IndiceNoSeleccionadoException ex)
            {
                if (this.MensajeError is not null)
                {
                    this.MensajeError(ex.Message);
                }
            }
        }
        private void jediToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipoDePersonaje = "Jedi";
            ActualizarVisor();
            ActualizarPantalla();
            DesactivarItemMenu();
        }

        private void sithToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipoDePersonaje = "Sith";
            ActualizarVisor();
            ActualizarPantalla();
            DesactivarItemMenu();
        }

        private void mandalorianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipoDePersonaje = "Mandaloriano";
            ActualizarVisor();
            ActualizarPantalla();
            DesactivarItemMenu();
        }

        private void cazarrecompensasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tipoDePersonaje = "Cazarrecompensas";
            ActualizarVisor();
            ActualizarPantalla();
            DesactivarItemMenu();
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
                try
                {
                    if (this.boxTipoDeGuardado.Text == "Archivos")
                    {
                        if (!Directory.Exists(pathSerializacionesCartas))
                        {
                            Directory.CreateDirectory(pathSerializacionesCartas);
                        }
                        mazoPersonal.SerializarMazoCompleto();
                    }
                }
                catch (ErrorGuardandoDatosException ex)
                {
                    if (this.MensajeError is not null)
                    {
                        this.MensajeError(ex.Message);
                    }
                }

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
                    if (this.boxTipoDeGuardado.Text == "Tablas")
                    {
                        try
                        {
                            AccesoPersonajes acceso = new AccesoPersonajes();
                            switch (p)
                            {
                                case Jedi:
                                    acceso.AgregarJedi((Jedi)p);
                                    break;
                                case Sith:
                                    acceso.AgregarSith((Sith)p);
                                    break;
                                case Mandaloriano:
                                    acceso.AgregarMandaloriano((Mandaloriano)p);
                                    break;
                                case Cazarrecompensas:
                                    acceso.AgregarCazarrecompensas((Cazarrecompensas)p);
                                    break;
                            }
                        }
                        catch (CRUDException ex)
                        {
                            if (this.MensajeError is not null)
                            {
                                this.MensajeError(ex.Message);
                            }
                        }
                    }
                    ActualizarOrdenamiento();
                    if (!desactivarGuardado)
                    {
                        this.boxTipoDeGuardado.Enabled = false;
                        desactivarGuardado = true;
                    }
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
            AccesoPersonajes acceso = new AccesoPersonajes();
            try
            {
                switch (tipoDePersonaje)
                {
                    case "Jedi":
                        Jedi jModificar = mazoPersonal.CartasJedi[indice];

                        frmCarta frmJ = new frmCarta(jModificar, true);
                        frmJ.ShowDialog();

                        if (frmJ.DialogResult == DialogResult.OK)
                        {
                            if (this.boxTipoDeGuardado.Text == "Tablas")
                            {
                                acceso.ModificarJedi(mazoPersonal.CartasJedi[indice], (Jedi)frmJ.PersonajeDelFormulario);
                            }
                            mazoPersonal.CartasJedi[indice] = (Jedi)frmJ.PersonajeDelFormulario;
                            this.boxTipoDeGuardado.Enabled = false;
                            desactivarGuardado = true;
                        }
                        break;
                    case "Sith":
                        Sith sModificar = mazoPersonal.CartasSith[indice];

                        frmCarta frmS = new frmCarta(sModificar, true);
                        frmS.ShowDialog();

                        if (frmS.DialogResult == DialogResult.OK)
                        {
                            if (this.boxTipoDeGuardado.Text == "Tablas")
                            {
                                acceso.ModificarSith(mazoPersonal.CartasSith[indice], (Sith)frmS.PersonajeDelFormulario);
                            }
                            mazoPersonal.CartasSith[indice] = (Sith)frmS.PersonajeDelFormulario;
                            this.boxTipoDeGuardado.Enabled = false;
                            desactivarGuardado = true;
                        }
                        break;
                    case "Mandaloriano":
                        Mandaloriano mModificar = mazoPersonal.CartasMandalorianos[indice];

                        frmCarta frmM = new frmCarta(mModificar, true);
                        frmM.ShowDialog();

                        if (frmM.DialogResult == DialogResult.OK)
                        {
                            if (this.boxTipoDeGuardado.Text == "Tablas")
                            {
                                acceso.ModificarMandaloriano(mazoPersonal.CartasMandalorianos[indice], (Mandaloriano)frmM.PersonajeDelFormulario);
                            }
                            mazoPersonal.CartasMandalorianos[indice] = (Mandaloriano)frmM.PersonajeDelFormulario;
                            this.boxTipoDeGuardado.Enabled = false;
                            desactivarGuardado = true;
                        }
                        break;
                    case "Cazarrecompensas":
                        Cazarrecompensas cModificar = mazoPersonal.CartasCazarrecompensas[indice];

                        frmCarta frmC = new frmCarta(cModificar, true);
                        frmC.ShowDialog();

                        if (frmC.DialogResult == DialogResult.OK)
                        {
                            if (this.boxTipoDeGuardado.Text == "Tablas")
                            {
                                acceso.ModificarCazarrecompensas(mazoPersonal.CartasCazarrecompensas[indice], (Cazarrecompensas)frmC.PersonajeDelFormulario);
                            }
                            mazoPersonal.CartasCazarrecompensas[indice] = (Cazarrecompensas)frmC.PersonajeDelFormulario;
                            this.boxTipoDeGuardado.Enabled = false;
                            desactivarGuardado = true;
                        }
                        break;
                }
            }
            catch (CRUDException ex)
            {
                if (this.MensajeError is not null)
                {
                    this.MensajeError(ex.Message);
                }
            }
            ActualizarOrdenamiento();
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
                if (this.boxTipoDeGuardado.Text == "Tablas")
                {
                    AccesoPersonajes acceso = new AccesoPersonajes();
                    try
                    {
                        acceso.EliminarPersonaje(p);
                    }
                    catch (CRUDException ex)
                    {
                        MostarMensajeDeError(ex.Message);
                    }
                }
                this.boxTipoDeGuardado.Enabled = false;
                desactivarGuardado = true;
                ActualizarOrdenamiento();
                MessageBox.Show("Carta Eliminada", "Se eliminó correctamente la carta de la lista", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        /// <summary>
        /// Limpia todos los datos del ListBox para luego reincorporarlos (por si se haya producido un cambio)
        /// </summary>
        private void ActualizarVisor()
        {
            cancelacionSource = new CancellationTokenSource();
            this.lstVisor.Items.Clear();
            Task t2 = Task.Run(() => MostrarCartas());
        }

        /// <summary>
        /// Imprime los datos de los personajes en un listbox
        /// </summary>
        private void MostrarCartas()
        {
            try
            {
                int numeroCarta = 0;
                int cantidadCartas = 0;
                do
                {
                    switch (tipoDePersonaje)
                    {
                        case "Jedi":
                            cantidadCartas = MenuPrincipal.mazoPersonal.CartasJedi.Count;
                            if (cantidadCartas > 0)
                            {
                                this.ActualizarCartas(MenuPrincipal.mazoPersonal.CartasJedi[numeroCarta]);
                            }
                            else
                                numeroCarta--;
                            break;
                        case "Sith":
                            cantidadCartas = MenuPrincipal.mazoPersonal.CartasSith.Count;
                            if (cantidadCartas > 0)
                            {
                                this.ActualizarCartas(MenuPrincipal.mazoPersonal.CartasSith[numeroCarta]);
                            }
                            else numeroCarta--;
                            break;
                        case "Mandaloriano":
                            cantidadCartas = MenuPrincipal.mazoPersonal.CartasMandalorianos.Count;
                            if (cantidadCartas > 0)
                            {
                                this.ActualizarCartas(MenuPrincipal.mazoPersonal.CartasMandalorianos[numeroCarta]);
                            }
                            else cantidadCartas--;
                            break;
                        case "Cazarrecompensas":
                            cantidadCartas = MenuPrincipal.mazoPersonal.CartasCazarrecompensas.Count;
                            if (cantidadCartas > 0)
                            {
                                this.ActualizarCartas(MenuPrincipal.mazoPersonal.CartasCazarrecompensas[numeroCarta]);
                            }
                            else cantidadCartas--;
                             break;
                    }
                    if (numeroCarta == cantidadCartas - 1)
                    {
                        this.cancelacionSource.Cancel();
                        break;
                    }
                    else
                        numeroCarta++;


                    Thread.Sleep(500);
                } while (true);
            }
            catch (Exception ex)
            { 
            }
        }


        /// <summary>
        /// Agrega un nuevo personaje a la listbox
        /// </summary>
        private void ActualizarCartas(Personaje p)
        {
            if (this.lstVisor.InvokeRequired)
            {
                DelegadoVisorPersonajes delegado = new DelegadoVisorPersonajes(ActualizarCartas);
                object[] parametros = { p };

                this.lstVisor.Invoke(delegado, parametros);
            }
            else
            {
                if (this.cancelacion.IsCancellationRequested)
                {
                    return;
                }
                this.lstVisor.Items.Add(p.ToString());
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
            if (LuegoDeprimeraIteracion)
            {
                ActualizarVisor();
            }
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
            try
            {
                using (StreamReader sr = new StreamReader(pathUsuariosSerializados))
                {
                    string jsonString = sr.ReadToEnd();

                    datosUsuarios = (List<string>)JsonSerializer.Deserialize(jsonString, typeof(List<string>));
                }
            }
            catch (Exception ex)
            {
                throw new ErrorRecuperandoDatosException("Hubo un error recuperando los datos del usuario", ex);
            }
        }


        /// <summary>
        /// Inicializa las listas de imagenes con los paths de cada una
        /// </summary>
        private void InicializarListasImagenes()
        {
            MenuPrincipal.imagenesJedi.Add(pathImagenes + @"\ImagenJedi.png");
            MenuPrincipal.imagenesJedi.Add(pathImagenes + @"\ImagenJedi2.jpg");
            MenuPrincipal.imagenesJedi.Add(pathImagenes + @"\ImagenJedi3.jpg");

            MenuPrincipal.imagenesSith.Add(pathImagenes + @"\ImagenSith.jpg");
            MenuPrincipal.imagenesSith.Add(pathImagenes + @"\ImagenSith2.jpg");
            MenuPrincipal.imagenesSith.Add(pathImagenes + @"\ImagenSith3.jpg");

            MenuPrincipal.imagenesMandalorianos.Add(pathImagenes + @"\ImagenMandalorianos.jpg");
            MenuPrincipal.imagenesMandalorianos.Add(pathImagenes + @"\ImagenMandalorianos2.jpg");
            MenuPrincipal.imagenesMandalorianos.Add(pathImagenes + @"\ImagenMandalorianos3.jpg");

            MenuPrincipal.imagenesCazarrecompensas.Add(pathImagenes + @"\ImagenCazarrecompensas.png");
            MenuPrincipal.imagenesCazarrecompensas.Add(pathImagenes + @"\ImagenCazarrecompensas2.jpg");
            MenuPrincipal.imagenesCazarrecompensas.Add(pathImagenes + @"\ImagenCazarrecompensas3.jpg");
        }

        /// <summary>
        /// Imprime una imagen distinta cada 5 segundos según el personaje en pantalla y su lista de imagenes
        /// </summary>
        private void MostrarImagenes()
        {
            int numeroImagen = 0;
            do
            {
                switch (tipoDePersonaje)
                {
                    case "Jedi":
                        this.ActualizarImagen(imagenesJedi[numeroImagen]);
                        break;
                    case "Sith":
                        this.ActualizarImagen(imagenesSith[numeroImagen]);
                        break;
                    case "Mandaloriano":
                        this.ActualizarImagen(imagenesMandalorianos[numeroImagen]);
                        break;
                    case "Cazarrecompensas":
                        this.ActualizarImagen(imagenesCazarrecompensas[numeroImagen]);
                        break;
                }
                numeroImagen++;
                if (numeroImagen > 2)
                    numeroImagen = 0;
                Thread.Sleep(5000);
            } while (true);
        }

        /// <summary>
        /// Cambia la imagen en pantalla por la que le asigna el path
        /// </summary>
        private void ActualizarImagen(string pathImagen)
        {
            if (this.pcBxPersonaje.InvokeRequired)
            {
                DelegadoImagenes delegado = new DelegadoImagenes(ActualizarImagen);
                object[] parametros = { pathImagen };

                this.pcBxPersonaje.Invoke(delegado, parametros);
            }
            else
            {
                this.pcBxPersonaje.ImageLocation = pathImagen;
            }
        }


        /// <summary>
        /// Muestra el tiempo en pantalla que lleva el usuario
        /// </summary>
        private void MostrarTiempoEnAplicacion()
        {
            do
            {
                this.ActualizarTiempoEnAplicacion(DateTime.Now);
                Thread.Sleep(1000);
            }while (true);
        }

        /// <summary>
        /// Imprime el tiempo en pantalla en un label
        /// </summary>
        private void ActualizarTiempoEnAplicacion(DateTime tiempoActual)
        {
            if (this.lblTiempoConectado.InvokeRequired)
            {
                DelegadoActualizarTiempo d = new DelegadoActualizarTiempo(ActualizarTiempoEnAplicacion);
                object[] arrayParametro = { tiempoActual };

                this.lblTiempoConectado.Invoke(d, arrayParametro);
            }
            else
            {
                Func<DateTime, DateTime, TimeSpan> restarTiempos = (a, b) => a - b;
                this.lblTiempoConectado.Text = $"Tiempo conectado: {restarTiempos(tiempoInicio, tiempoActual).ToString(@"hh\:mm\:ss")}"; 
            }
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
            try
            {
                DeserealizarDatosUsuario();
                frmUsuarios frmUsuarios = new frmUsuarios(datosUsuarios);
                frmUsuarios.ShowDialog();
            }
            catch (ErrorRecuperandoDatosException ex)
            {
                MessageBox.Show(ex.Message, "Error",  MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Determina el tipo de perfil que tiene usuario
        /// </summary>
        private void ValidarPerfil(Usuario usuario)
        {
            switch (usuario.perfil)
            {
                case "administrador":
                    tipoDePerfil = "administrador";
                    break;
                case "supervisor":
                    tipoDePerfil = "supervisor";
                    break;
                case "vendedor":
                    tipoDePerfil = "vendedor";
                    break;
            }
        }

        /// <summary>
        /// Determina que tipo de guardado ha seleccionado el usuario antes modificar sus cartas
        /// </summary>
        private void ObtenerTipoDeGuardado()
        {
            try
            {
                switch (this.boxTipoDeGuardado.Text)
                {
                    case "Archivos":
                        mazoPersonal.DeserealizarMazoCompleto();
                        break;
                    case "Tablas":
                        mazoPersonal.ObtenerPersonajesDeTablas();
                        break;
                }
            }
            catch (ErrorRecuperandoDatosException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void boxTipoDeGuardado_SelectedIndexChanged(object sender, EventArgs e)
        {
            DesactivarItemMenu();
            ObtenerTipoDeGuardado();
            if (LuegoDeprimeraIteracion)
            {
                ActualizarVisor();
            }

        }

        /// <summary>
        /// Muestra un MessageBox con el mensaje ingresado y el título "Error"
        /// </summary>
        /// <param name="mensaje"></param>
        private void MostarMensajeDeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Desactiva todos los ToolStripMenuItems durante 2 segundos para evitar el choque de hilos
        /// </summary>
        private async void DesactivarItemMenu()
        {
            this.jediToolStripMenuItem.Enabled = false;
            this.sithToolStripMenuItem.Enabled = false;
            this.mandalorianoToolStripMenuItem.Enabled = false;
            this.cazarrecompensasToolStripMenuItem.Enabled = false;
            this.boxTipoDeGuardado.Enabled = false;
            await Task.Delay(2000);
            this.jediToolStripMenuItem.Enabled = true;
            this.sithToolStripMenuItem.Enabled = true;
            this.mandalorianoToolStripMenuItem.Enabled = true;
            this.cazarrecompensasToolStripMenuItem.Enabled = true;
            if (!desactivarGuardado) this.boxTipoDeGuardado.Enabled = true; 
        }
    }
}
