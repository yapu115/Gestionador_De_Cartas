using MenuDePersonajes.Properties;
using Personajes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuDePersonajes
{
    public partial class frmCarta : Form
    {
        private Personaje personaje;
        static string form;
        static bool enModificacion;


        /// <summary>
        /// Retorna el personaje de la carta con todos sus datos
        /// </summary>
        public Personaje PersonajeDelFormulario
        {
            get { return personaje; }
        }


        public frmCarta()
        {
            InitializeComponent();
            enModificacion = false;
        }
        public frmCarta(string formPersonaje) : this()
        {
            form = formPersonaje;
        }
        /// <summary>
        /// Las sobrecarga de constructores con las distintas clases de personajes indicarán que se está modificando o
        /// eliminando una carta y por ende se inicializarán los datos del form con los del personaje previamente creado.
        /// </summary>
        public frmCarta(Personaje pers, string form, bool modificar) : this(form)
        {
            this.txtNombre.Text = pers.Nombre;
            this.txtVida.Text = pers.Vida.ToString();
            this.txtPoder.Text = pers.Poder.ToString();
            this.BxRareza.Text = pers.Rareza.ToString();
            InicializarDatos();

            enModificacion = modificar;
            if (enModificacion == false)
            {
                this.txtNombre.Enabled = false;
                this.txtVida.Enabled = false;
                this.txtPoder.Enabled = false;
                this.BxRareza.Enabled = false;
                this.txtAtributo1.Enabled = false;
                this.txtAtributo2.Enabled = false;
                this.BxAtributo1.Enabled = false;
                this.BxAtributo2.Enabled = false;
            }
        }
        public frmCarta(Jedi jedi, bool modificar) : this((Personaje)jedi, "Jedi", modificar)
        {
            this.txtAtributo1.Text = jedi.Rango;
            this.txtAtributo2.Text = jedi.Faccion;
            this.BxAtributo2.Text = jedi.ColorDeSable.ToString();
        }
        public frmCarta(Sith sith, bool modificar) : this((Personaje)sith, "Sith", modificar)
        {
            this.txtAtributo1.Text = sith.ColorDeSable.ToString();
            this.txtAtributo2.Text = sith.Faccion;
            this.BxAtributo2.Text = sith.ColorDeSable.ToString();
        }
        public frmCarta(Mandaloriano mandaloriano, bool modificar) : this((Personaje)mandaloriano, "Mandaloriano", modificar)
        {
            this.txtAtributo1.Text = mandaloriano.Clan;
            this.BxAtributo1.Text = mandaloriano.SableOscuro;
            this.BxAtributo2.Text = mandaloriano.Forajido;
            this.txtAtributo4.Text = mandaloriano.Arma;
        }
        public frmCarta(Cazarrecompensas cazarrecompensas, bool modificar) : this((Personaje)cazarrecompensas, "Cazarrecompensas", modificar)
        {
            this.txtAtributo1.Text = cazarrecompensas.Clan;
            this.txtAtributo2.Text = cazarrecompensas.Cazados.ToString();
            this.BxAtributo2.Text = cazarrecompensas.Nivel.ToString();
            this.txtAtributo4.Text = cazarrecompensas.Arma;
        }


        /// <summary>
        /// Inicia el form con todos los datos según sea el tipo de carta
        /// </summary>
        private void frmCarta_Load(object sender, EventArgs e)
        {
            InicializarDatos();
        }

        /// <summary>
        /// Agrega la carta a la lista con todos los datos ingresados, en caso de que los datos estén incompletos se pide que se completen
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (VerificacionDatosIncompletos())
            {
                MessageBox.Show("Datos Insuficientes: Revise los parámetros y vuelva a intentar", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string nombre = this.txtNombre.Text;
                int vida = int.Parse(this.txtVida.Text);
                int poder = int.Parse(this.txtPoder.Text);
                ERarezas rareza = TextoARareza(this.BxRareza.Text);

                switch (form)
                {
                    case "Jedi":
                        CrearJedi(nombre, vida, poder, rareza);
                        break;
                    case "Sith":
                        CrearSith(nombre, vida, poder, rareza);
                        break;
                    case "Mandaloriano":
                        CrearMandaloriano(nombre, vida, poder, rareza);
                        break;
                    case "Cazarrecompensas":
                        CrearCazarrecompensas(nombre, vida, poder, rareza);
                        break;
                }
            }
        }

        /// <summary>
        /// Cancela la creación, modificacion o eliminación de la carta
        /// Si estaba en modificacion pregunta con un mensaje si quiere cancelar la accion y no guardar los datos
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (enModificacion)
            {
                DialogResult confirmacion = MessageBox.Show("Si cancela la acción no se guardarán los cambios", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void frmCarta_FormClosing(object sender, FormClosingEventArgs e)
        {
        }


        /// <summary>
        /// Asigna los lables, textboxs, comboboxes e imágenes según el tipo de carta que se haya seleccionado 
        /// </summary>
        private void InicializarDatos()
        {
            switch (form)
            {
                case "Jedi":
                    this.BackgroundImage = Resources.JediCarta;
                    DefinirLables("Rango:", "Facción", "Color de sable");
                    this.BxAtributo1.Visible = false;
                    this.txtAtributo4.Visible = false;
                    this.lblAtributo4.Visible = false;
                    this.BxAtributo2.Items.Add("Azul");
                    this.BxAtributo2.Items.Add("Verde");
                    this.BxAtributo2.Items.Add("Purpura");
                    this.BxAtributo2.Items.Add("Blanco");
                    this.BxAtributo2.Items.Add("Amarillo");
                    break;
                case "Sith":
                    this.BackgroundImage = Resources.SithCarta;
                    DefinirLables("Rango:", "Facción", "Color de sable");
                    this.BxAtributo1.Visible = false;
                    this.txtAtributo4.Visible = false;
                    this.lblAtributo4.Visible = false;
                    this.BxAtributo2.Items.Add("Rojo");
                    this.BxAtributo2.Items.Add("Purpura");
                    this.BxAtributo2.Items.Add("Naranja");
                    break;
                case "Mandaloriano":
                    this.BackgroundImage = Resources.MandalorianoCarta;
                    DefinirLables("Clan:", "Es forajido:", "Posee sable oscuro:");
                    this.lblAtributo1.Location = new Point(402, 53);
                    this.lblAtributo2.Location = new Point(357, 117);
                    this.lblAtributo3.Location = new Point(306, 173);
                    this.txtAtributo1.Location = new Point(471, 53);
                    this.BxAtributo1.Location = new Point(471, 113);
                    this.BxAtributo2.Location = new Point(471, 170);
                    this.txtAtributo2.Visible = false;
                    this.BxAtributo1.Items.Add("Si");
                    this.BxAtributo1.Items.Add("No");
                    this.BxAtributo2.Items.Add("Si");
                    this.BxAtributo2.Items.Add("No");
                    break;
                case "Cazarrecompensas":
                    this.BackgroundImage = Resources.CazarrecompensasCarta;
                    DefinirLables("Clan:", "N° de cazas:", "Nivel de prestigio:");
                    this.txtAtributo2.MaxLength = 4;
                    this.lblAtributo1.Location = new Point(378, 59);
                    this.lblAtributo2.Location = new Point(336, 124);
                    this.lblAtributo3.Location = new Point(301, 173);
                    this.txtAtributo1.Location = new Point(471, 53);
                    this.txtAtributo2.Location = new Point(471, 118);
                    this.BxAtributo2.Location = new Point(471, 169);
                    this.BxAtributo1.Visible = false;
                    this.BxAtributo2.Items.Add("Bajo");
                    this.BxAtributo2.Items.Add("Mediano");
                    this.BxAtributo2.Items.Add("Alto");
                    this.BxAtributo2.Items.Add("Leyenda");
                    break;
            }

        }

        /// <summary>
        /// Asigna el valor de los textos recibidos a los lables y además modifica la manera de mostrar la imagen 
        /// para que se acople con el form
        /// </summary>
        private void DefinirLables(string txt1, string txt2, string txt3)
        {
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.lblAtributo1.Text = txt1;
            this.lblAtributo2.Text = txt2;
            this.lblAtributo3.Text = txt3;
        }

        /// <summary>
        /// Utiliza IsNullOrWhiteSpace para para verificar si los boxes de los datos ingresados por el usuario están vacíos
        /// Si es así retorna true
        /// </summary>
        private bool VerificacionDatosIncompletos()
        {
            bool incompleto = false;
            if (string.IsNullOrWhiteSpace(this.txtNombre.Text) || string.IsNullOrWhiteSpace(this.txtPoder.Text)
                || string.IsNullOrWhiteSpace(this.txtVida.Text) || string.IsNullOrWhiteSpace(this.BxRareza.Text))
            {
                incompleto = true;
            }

            switch (form)
            {
                case "Jedi":
                case "Sith":
                    if (string.IsNullOrWhiteSpace(this.txtAtributo1.Text) || string.IsNullOrWhiteSpace(this.txtAtributo2.Text)
                        || string.IsNullOrWhiteSpace(this.BxAtributo2.Text))
                    {
                        incompleto = true;
                    }
                    break;
                case "Cazarrecompensas":
                    if (string.IsNullOrWhiteSpace(this.txtAtributo1.Text) || string.IsNullOrWhiteSpace(this.txtAtributo2.Text)
                        || string.IsNullOrWhiteSpace(this.BxAtributo2.Text) || string.IsNullOrWhiteSpace(this.txtAtributo4.Text))
                    {
                        incompleto = true;
                    }
                    break;
                case "Mandaloriano":
                    if (string.IsNullOrWhiteSpace(this.txtAtributo1.Text) || string.IsNullOrWhiteSpace(this.BxAtributo1.Text)
                        || string.IsNullOrWhiteSpace(this.BxAtributo2.Text) || string.IsNullOrWhiteSpace(this.txtAtributo4.Text))
                    {
                        incompleto = true;
                    }
                    break;
            }
            return incompleto;
        }



        /// <summary>
        /// Utiliza los datos que ingreso el usuario para crear un nuevo personaje dependiendo el tipo de carta.
        /// Asigna el dialogResult a OK para terminar con el objeto del form
        /// </summary>
        private void CrearJedi(string nombre, int vida, int poder, ERarezas rareza)
        {
            string rangoJedi = this.txtAtributo1.Text;
            string faccionJedi = this.txtAtributo2.Text;
            EJediColoresSables colorSableJedi = TextoASablesJedi(this.BxAtributo2.Text);

            Jedi cartaJedi = new Jedi(nombre, vida, poder, rareza, rangoJedi, faccionJedi, colorSableJedi);
            this.personaje = cartaJedi;
            AccesoPersonajes a = new AccesoPersonajes();
            a.AgregarJedi(cartaJedi);
            this.DialogResult = DialogResult.OK;
        }
        private void CrearSith(string nombre, int vida, int poder, ERarezas rareza)
        {
            string rangoSith = this.txtAtributo1.Text;
            string faccionSith = this.txtAtributo2.Text;
            ESithColoresSables colorSableSith = TextoASablesSith(this.BxAtributo2.Text);

            Sith cartaSith = new Sith(nombre, vida, poder, rareza, rangoSith, faccionSith, colorSableSith);
            this.personaje = cartaSith;
            AccesoPersonajes a = new AccesoPersonajes();
            a.AgregarSith(cartaSith);
            this.DialogResult = DialogResult.OK;
        }
        private void CrearMandaloriano(string nombre, int vida, int poder, ERarezas rareza)
        {
            string clan = this.txtAtributo1.Text;
            bool forajido = TextoABool(this.txtAtributo2.Text);
            bool sableOscuro = TextoABool(this.BxAtributo2.Text);
            string arma = this.txtAtributo4.Text;

            Mandaloriano cartaMandaloriano = new Mandaloriano(nombre, vida, poder, rareza, clan, forajido, sableOscuro, arma);
            this.personaje = cartaMandaloriano;
            AccesoPersonajes a = new AccesoPersonajes();
            a.AgregarMandaloriano(cartaMandaloriano);
            this.DialogResult = DialogResult.OK;
        }
        private void CrearCazarrecompensas(string nombre, int vida, int poder, ERarezas rareza)
        {
            string arma = this.txtAtributo4.Text;
            int cazados = int.Parse(this.txtAtributo2.Text);
            ECazarrecompensasNivel nivel = TextoAPrestigio(this.BxAtributo2.Text);
            string clan = this.txtAtributo1.Text;

            Cazarrecompensas cartaCazarrecompensas = new Cazarrecompensas(nombre, vida, poder, rareza, nivel, arma, cazados, clan);
            this.personaje = cartaCazarrecompensas;
            AccesoPersonajes a = new AccesoPersonajes();
            a.AgregarCazarrecompensas(cartaCazarrecompensas);
            this.DialogResult = DialogResult.OK;
        }


        /// <summary>
        /// Cambia el formato del texto ingresado en las boxes de datos a un formato de Erarezas
        /// </summary>
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

        /// <summary>
        /// Cambia el formato del texto ingresado en las boxes de datos a un formato de ECazarrecompensasNivel
        /// </summary>
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

        /// <summary>
        /// Cambia el formato del texto ingresado en las boxes de datos a un formato de bool
        /// </summary>
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
        /// Si se ingresan datos incorrectos a la txtNombre se rechaza
        /// </summary>
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificacionDeTexto(e);
        }

        /// <summary>
        /// Si se ingresan datos incorrectos a la txtVida se rechaza
        /// </summary>
        private void txtVida_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificacionDeNumeros(e);
        }
        /// <summary>
        /// Si se ingresan datos incorrectos a la txtPoder se rechaza
        /// </summary>
        private void txtPoder_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificacionDeNumeros(e);
        }
        /// <summary>
        /// Si se ingresan datos incorrectos a la txtAtributo1 se rechaza
        /// </summary>
        private void txtAtributo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificacionDeTexto(e);
        }
        /// <summary>
        /// Si se ingresan datos incorrectos a la txxAtributo2 se rechaza
        /// </summary>
        private void txtAtributo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (form == "Cazarrecompensas")
            {
                VerificacionDeNumeros(e);
            }
            else
            {
                VerificacionDeTexto(e);
            }
        }
        private void txtAtributo2_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Si el formate del dato ingresado no es numérico entonces no se registrará en la box
        /// </summary>
        private void VerificacionDeNumeros(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Si el formate del dato ingresado no son letras entonces no se registrará en la box
        /// </summary>
        private void VerificacionDeTexto(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)32 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

    }
}
