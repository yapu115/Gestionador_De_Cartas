namespace MenuDePersonajes
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            lblIniciarSesion = new Label();
            btnMostrarContraseña = new Button();
            lblContraseña = new Label();
            lblMail = new Label();
            txtContraseña = new TextBox();
            txtMail = new TextBox();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // lblIniciarSesion
            // 
            lblIniciarSesion.AutoSize = true;
            lblIniciarSesion.BackColor = Color.Gainsboro;
            lblIniciarSesion.Font = new Font("Bahnschrift Condensed", 16.2782612F, FontStyle.Bold, GraphicsUnit.Point);
            lblIniciarSesion.ForeColor = Color.Black;
            lblIniciarSesion.Location = new Point(137, 90);
            lblIniciarSesion.Name = "lblIniciarSesion";
            lblIniciarSesion.Size = new Size(139, 31);
            lblIniciarSesion.TabIndex = 20;
            lblIniciarSesion.Text = "Iniciar Sesión: ";
            // 
            // btnMostrarContraseña
            // 
            btnMostrarContraseña.BackColor = SystemColors.ButtonHighlight;
            btnMostrarContraseña.BackgroundImage = Properties.Resources.PasswordMostrar;
            btnMostrarContraseña.BackgroundImageLayout = ImageLayout.Stretch;
            btnMostrarContraseña.FlatStyle = FlatStyle.Popup;
            btnMostrarContraseña.Location = new Point(370, 229);
            btnMostrarContraseña.Name = "btnMostrarContraseña";
            btnMostrarContraseña.Size = new Size(29, 26);
            btnMostrarContraseña.TabIndex = 19;
            btnMostrarContraseña.UseVisualStyleBackColor = false;
            btnMostrarContraseña.Click += btnMostrarContraseña_Click;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.BackColor = Color.White;
            lblContraseña.BorderStyle = BorderStyle.FixedSingle;
            lblContraseña.Font = new Font("Arial", 11.8956518F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblContraseña.ForeColor = SystemColors.InfoText;
            lblContraseña.Location = new Point(12, 228);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(131, 25);
            lblContraseña.TabIndex = 18;
            lblContraseña.Text = "Contraseña: ";
            // 
            // lblMail
            // 
            lblMail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMail.AutoSize = true;
            lblMail.BackColor = Color.White;
            lblMail.BorderStyle = BorderStyle.FixedSingle;
            lblMail.Font = new Font("Arial", 11.8956518F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblMail.ForeColor = Color.Black;
            lblMail.Location = new Point(55, 165);
            lblMail.Name = "lblMail";
            lblMail.Size = new Size(88, 25);
            lblMail.TabIndex = 17;
            lblMail.Text = "Correo: ";
            // 
            // txtContraseña
            // 
            txtContraseña.BackColor = SystemColors.ButtonHighlight;
            txtContraseña.BorderStyle = BorderStyle.FixedSingle;
            txtContraseña.Location = new Point(149, 229);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(250, 26);
            txtContraseña.TabIndex = 16;
            txtContraseña.KeyPress += txtContraseña_KeyPress;
            // 
            // txtMail
            // 
            txtMail.BackColor = SystemColors.ButtonHighlight;
            txtMail.BorderStyle = BorderStyle.FixedSingle;
            txtMail.Location = new Point(149, 164);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(250, 26);
            txtMail.TabIndex = 15;
            txtMail.KeyPress += txtMail_KeyPress;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = SystemColors.ButtonHighlight;
            btnAceptar.BackgroundImageLayout = ImageLayout.None;
            btnAceptar.FlatStyle = FlatStyle.Popup;
            btnAceptar.Font = new Font("Arial", 11.8956518F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnAceptar.Location = new Point(149, 295);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(107, 41);
            btnAceptar.TabIndex = 14;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Background_Image_2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(411, 427);
            Controls.Add(lblIniciarSesion);
            Controls.Add(btnMostrarContraseña);
            Controls.Add(lblContraseña);
            Controls.Add(lblMail);
            Controls.Add(txtContraseña);
            Controls.Add(txtMail);
            Controls.Add(btnAceptar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblIniciarSesion;
        private Button btnMostrarContraseña;
        private Label lblContraseña;
        private Label lblMail;
        private TextBox txtContraseña;
        private TextBox txtMail;
        private Button btnAceptar;
    }
}