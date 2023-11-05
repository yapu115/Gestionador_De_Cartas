using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuDePersonajes
{
    public partial class frmUsuarios : Form
    {
        private List<string> datosUsuarios;
        public frmUsuarios()
        {
            InitializeComponent();
        }
        public frmUsuarios(List<string> usuarios) : this()
        {
            this.datosUsuarios = usuarios;
        }

        /// <summary>
        /// Al iniciarse el form la lista de usuarios se mostrará a través de una listbox
        /// </summary>
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            this.datosUsuarios.Reverse();
            foreach (string dato in this.datosUsuarios)
            {
                lstVisorUsuarios.Items.Add(dato);
            }
        }
    }
}
