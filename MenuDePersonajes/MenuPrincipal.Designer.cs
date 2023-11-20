namespace MenuDePersonajes
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            lstVisor = new ListBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            StripTipoDeCarta = new MenuStrip();
            jediToolStripMenuItem = new ToolStripMenuItem();
            sithToolStripMenuItem = new ToolStripMenuItem();
            mandalorianoToolStripMenuItem = new ToolStripMenuItem();
            cazarrecompensasToolStripMenuItem = new ToolStripMenuItem();
            lblInfoUsuario = new Label();
            lblCartas = new Label();
            bxOrdenarVidaPoder = new ComboBox();
            bxOrdenarAscDesc = new ComboBox();
            btnLogueos = new Button();
            pcBxPersonaje = new PictureBox();
            lblOrdenamiento = new Label();
            boxTipoDeGuardado = new ComboBox();
            lblTipoDeGuardado = new Label();
            lblTiempoConectado = new Label();
            StripTipoDeCarta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pcBxPersonaje).BeginInit();
            SuspendLayout();
            // 
            // lstVisor
            // 
            lstVisor.BackColor = Color.DimGray;
            lstVisor.ForeColor = Color.White;
            lstVisor.FormattingEnabled = true;
            lstVisor.ItemHeight = 19;
            lstVisor.Location = new Point(251, 93);
            lstVisor.Name = "lstVisor";
            lstVisor.Size = new Size(1212, 422);
            lstVisor.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = SystemColors.ButtonFace;
            btnAgregar.FlatStyle = FlatStyle.Popup;
            btnAgregar.Font = new Font("Bahnschrift SemiBold", 11.8956518F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.ForeColor = SystemColors.ControlText;
            btnAgregar.Location = new Point(968, 557);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(132, 40);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = SystemColors.ButtonFace;
            btnModificar.FlatStyle = FlatStyle.Popup;
            btnModificar.Font = new Font("Bahnschrift SemiBold", 11.8956518F, FontStyle.Bold, GraphicsUnit.Point);
            btnModificar.ForeColor = SystemColors.ControlText;
            btnModificar.Location = new Point(1157, 557);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(132, 40);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = SystemColors.ButtonFace;
            btnEliminar.FlatStyle = FlatStyle.Popup;
            btnEliminar.Font = new Font("Bahnschrift SemiBold", 11.8956518F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.ForeColor = SystemColors.ControlText;
            btnEliminar.Location = new Point(1328, 557);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(133, 40);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // StripTipoDeCarta
            // 
            StripTipoDeCarta.ImageScalingSize = new Size(19, 19);
            StripTipoDeCarta.Items.AddRange(new ToolStripItem[] { jediToolStripMenuItem, sithToolStripMenuItem, mandalorianoToolStripMenuItem, cazarrecompensasToolStripMenuItem });
            StripTipoDeCarta.Location = new Point(0, 0);
            StripTipoDeCarta.Name = "StripTipoDeCarta";
            StripTipoDeCarta.Size = new Size(1475, 28);
            StripTipoDeCarta.TabIndex = 6;
            StripTipoDeCarta.Text = "Tipo De carta";
            // 
            // jediToolStripMenuItem
            // 
            jediToolStripMenuItem.Name = "jediToolStripMenuItem";
            jediToolStripMenuItem.Size = new Size(49, 24);
            jediToolStripMenuItem.Text = "Jedi";
            jediToolStripMenuItem.Click += jediToolStripMenuItem_Click;
            // 
            // sithToolStripMenuItem
            // 
            sithToolStripMenuItem.Name = "sithToolStripMenuItem";
            sithToolStripMenuItem.Size = new Size(48, 24);
            sithToolStripMenuItem.Text = "Sith";
            sithToolStripMenuItem.Click += sithToolStripMenuItem_Click;
            // 
            // mandalorianoToolStripMenuItem
            // 
            mandalorianoToolStripMenuItem.Name = "mandalorianoToolStripMenuItem";
            mandalorianoToolStripMenuItem.Size = new Size(116, 24);
            mandalorianoToolStripMenuItem.Text = "Mandaloriano";
            mandalorianoToolStripMenuItem.Click += mandalorianoToolStripMenuItem_Click;
            // 
            // cazarrecompensasToolStripMenuItem
            // 
            cazarrecompensasToolStripMenuItem.Name = "cazarrecompensasToolStripMenuItem";
            cazarrecompensasToolStripMenuItem.Size = new Size(147, 24);
            cazarrecompensasToolStripMenuItem.Text = "Cazarrecompensas";
            cazarrecompensasToolStripMenuItem.Click += cazarrecompensasToolStripMenuItem_Click;
            // 
            // lblInfoUsuario
            // 
            lblInfoUsuario.AutoSize = true;
            lblInfoUsuario.BackColor = Color.Transparent;
            lblInfoUsuario.ForeColor = Color.White;
            lblInfoUsuario.Location = new Point(12, 536);
            lblInfoUsuario.Name = "lblInfoUsuario";
            lblInfoUsuario.Size = new Size(21, 20);
            lblInfoUsuario.TabIndex = 8;
            lblInfoUsuario.Text = "\"\"";
            // 
            // lblCartas
            // 
            lblCartas.AutoSize = true;
            lblCartas.BackColor = Color.Transparent;
            lblCartas.Font = new Font("Segoe UI Semibold", 11.8956518F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblCartas.ForeColor = Color.White;
            lblCartas.Location = new Point(12, 41);
            lblCartas.Name = "lblCartas";
            lblCartas.Size = new Size(78, 25);
            lblCartas.TabIndex = 10;
            lblCartas.Text = "Cartas: ";
            // 
            // bxOrdenarVidaPoder
            // 
            bxOrdenarVidaPoder.BackColor = Color.Gainsboro;
            bxOrdenarVidaPoder.DropDownStyle = ComboBoxStyle.DropDownList;
            bxOrdenarVidaPoder.FlatStyle = FlatStyle.Popup;
            bxOrdenarVidaPoder.Font = new Font("Times New Roman", 10.0173912F, FontStyle.Regular, GraphicsUnit.Point);
            bxOrdenarVidaPoder.ForeColor = Color.Black;
            bxOrdenarVidaPoder.FormattingEnabled = true;
            bxOrdenarVidaPoder.Items.AddRange(new object[] { "Vida", "Poder" });
            bxOrdenarVidaPoder.Location = new Point(1157, 43);
            bxOrdenarVidaPoder.Name = "bxOrdenarVidaPoder";
            bxOrdenarVidaPoder.Size = new Size(145, 27);
            bxOrdenarVidaPoder.TabIndex = 11;
            bxOrdenarVidaPoder.SelectedIndexChanged += bxOrdenarVidaPoder_SelectedIndexChanged;
            // 
            // bxOrdenarAscDesc
            // 
            bxOrdenarAscDesc.BackColor = Color.Gainsboro;
            bxOrdenarAscDesc.DropDownStyle = ComboBoxStyle.DropDownList;
            bxOrdenarAscDesc.FlatStyle = FlatStyle.Popup;
            bxOrdenarAscDesc.Font = new Font("Times New Roman", 10.0173912F, FontStyle.Regular, GraphicsUnit.Point);
            bxOrdenarAscDesc.ForeColor = Color.Black;
            bxOrdenarAscDesc.FormattingEnabled = true;
            bxOrdenarAscDesc.Items.AddRange(new object[] { "Ascendente", "Descendente" });
            bxOrdenarAscDesc.Location = new Point(1316, 43);
            bxOrdenarAscDesc.Name = "bxOrdenarAscDesc";
            bxOrdenarAscDesc.Size = new Size(145, 27);
            bxOrdenarAscDesc.TabIndex = 12;
            bxOrdenarAscDesc.SelectedIndexChanged += bcOrdenarAscDesc_SelectedIndexChanged;
            // 
            // btnLogueos
            // 
            btnLogueos.BackColor = Color.Black;
            btnLogueos.FlatStyle = FlatStyle.Popup;
            btnLogueos.ForeColor = Color.White;
            btnLogueos.Location = new Point(12, 569);
            btnLogueos.Name = "btnLogueos";
            btnLogueos.Size = new Size(199, 28);
            btnLogueos.TabIndex = 14;
            btnLogueos.Text = "Registro de Logueos";
            btnLogueos.UseVisualStyleBackColor = false;
            btnLogueos.Click += btnLogueos_Click;
            // 
            // pcBxPersonaje
            // 
            pcBxPersonaje.InitialImage = null;
            pcBxPersonaje.Location = new Point(12, 93);
            pcBxPersonaje.Name = "pcBxPersonaje";
            pcBxPersonaje.Size = new Size(233, 422);
            pcBxPersonaje.SizeMode = PictureBoxSizeMode.StretchImage;
            pcBxPersonaje.TabIndex = 15;
            pcBxPersonaje.TabStop = false;
            // 
            // lblOrdenamiento
            // 
            lblOrdenamiento.AutoSize = true;
            lblOrdenamiento.Font = new Font("Segoe UI Semibold", 10.0173912F, FontStyle.Bold, GraphicsUnit.Point);
            lblOrdenamiento.ForeColor = Color.White;
            lblOrdenamiento.Location = new Point(1042, 45);
            lblOrdenamiento.Name = "lblOrdenamiento";
            lblOrdenamiento.Size = new Size(109, 21);
            lblOrdenamiento.TabIndex = 16;
            lblOrdenamiento.Text = "Ordenar por: ";
            // 
            // boxTipoDeGuardado
            // 
            boxTipoDeGuardado.BackColor = Color.Gainsboro;
            boxTipoDeGuardado.DropDownStyle = ComboBoxStyle.DropDownList;
            boxTipoDeGuardado.FlatStyle = FlatStyle.Popup;
            boxTipoDeGuardado.Font = new Font("Times New Roman", 10.0173912F, FontStyle.Regular, GraphicsUnit.Point);
            boxTipoDeGuardado.ForeColor = Color.Black;
            boxTipoDeGuardado.FormattingEnabled = true;
            boxTipoDeGuardado.Items.AddRange(new object[] { "Personal", "Compartido" });
            boxTipoDeGuardado.Location = new Point(132, 614);
            boxTipoDeGuardado.Name = "boxTipoDeGuardado";
            boxTipoDeGuardado.Size = new Size(145, 27);
            boxTipoDeGuardado.TabIndex = 17;
            boxTipoDeGuardado.SelectedIndexChanged += boxTipoDeGuardado_SelectedIndexChanged;
            // 
            // lblTipoDeGuardado
            // 
            lblTipoDeGuardado.AutoSize = true;
            lblTipoDeGuardado.BackColor = Color.Transparent;
            lblTipoDeGuardado.ForeColor = Color.White;
            lblTipoDeGuardado.Location = new Point(13, 617);
            lblTipoDeGuardado.Name = "lblTipoDeGuardado";
            lblTipoDeGuardado.Size = new Size(104, 20);
            lblTipoDeGuardado.TabIndex = 18;
            lblTipoDeGuardado.Text = "Tipo de Mazo:";
            // 
            // lblTiempoConectado
            // 
            lblTiempoConectado.AutoSize = true;
            lblTiempoConectado.Font = new Font("Segoe UI Semibold", 10.0173912F, FontStyle.Bold, GraphicsUnit.Point);
            lblTiempoConectado.ForeColor = Color.White;
            lblTiempoConectado.Location = new Point(1243, 620);
            lblTiempoConectado.Name = "lblTiempoConectado";
            lblTiempoConectado.Size = new Size(154, 21);
            lblTiempoConectado.TabIndex = 19;
            lblTiempoConectado.Text = "TiempoConectado: ";
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(1475, 665);
            Controls.Add(lblTiempoConectado);
            Controls.Add(lblTipoDeGuardado);
            Controls.Add(boxTipoDeGuardado);
            Controls.Add(lblOrdenamiento);
            Controls.Add(pcBxPersonaje);
            Controls.Add(btnLogueos);
            Controls.Add(bxOrdenarAscDesc);
            Controls.Add(bxOrdenarVidaPoder);
            Controls.Add(lblCartas);
            Controls.Add(lblInfoUsuario);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(lstVisor);
            Controls.Add(StripTipoDeCarta);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = StripTipoDeCarta;
            Name = "MenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuPrincipal";
            FormClosing += MenuPrincipal_FormClosing;
            Load += MenuPrincipal_Load;
            StripTipoDeCarta.ResumeLayout(false);
            StripTipoDeCarta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pcBxPersonaje).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private ListBox lstVisor;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private MenuStrip StripTipoDeCarta;
        private ToolStripMenuItem jediToolStripMenuItem;
        private ToolStripMenuItem sithToolStripMenuItem;
        private ToolStripMenuItem mandalorianoToolStripMenuItem;
        private ToolStripMenuItem cazarrecompensasToolStripMenuItem;
        private Label lblInfoUsuario;
        private Label lblCartas;
        private ComboBox bxOrdenarVidaPoder;
        private ComboBox bxOrdenarAscDesc;
        private Button btnLogueos;
        private PictureBox pcBxPersonaje;
        private Label lblOrdenamiento;
        private ComboBox boxTipoDeGuardado;
        private Label lblTipoDeGuardado;
        private Label lblTiempoConectado;
    }
}