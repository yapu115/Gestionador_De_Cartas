namespace MenuDePersonajes
{
    partial class frmCarta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCarta));
            txtNombre = new TextBox();
            txtVida = new TextBox();
            txtPoder = new TextBox();
            lblNombre = new Label();
            lblVida = new Label();
            lblPoder = new Label();
            lblRareza = new Label();
            lblAtributo1 = new Label();
            lblAtributo2 = new Label();
            lblAtributo3 = new Label();
            txtAtributo1 = new TextBox();
            txtAtributo2 = new TextBox();
            btnCancelar = new Button();
            btnAceptar = new Button();
            BxRareza = new ComboBox();
            BxAtributo1 = new ComboBox();
            BxAtributo2 = new ComboBox();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.Gainsboro;
            txtNombre.ForeColor = Color.Black;
            txtNombre.Location = new Point(137, 53);
            txtNombre.MaxLength = 25;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(120, 26);
            txtNombre.TabIndex = 0;
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // txtVida
            // 
            txtVida.BackColor = Color.Gainsboro;
            txtVida.ForeColor = Color.Black;
            txtVida.Location = new Point(137, 114);
            txtVida.MaxLength = 4;
            txtVida.Name = "txtVida";
            txtVida.Size = new Size(120, 26);
            txtVida.TabIndex = 1;
            txtVida.KeyPress += txtVida_KeyPress;
            // 
            // txtPoder
            // 
            txtPoder.BackColor = Color.Gainsboro;
            txtPoder.ForeColor = Color.Black;
            txtPoder.Location = new Point(137, 170);
            txtPoder.MaxLength = 4;
            txtPoder.Name = "txtPoder";
            txtPoder.Size = new Size(120, 26);
            txtPoder.TabIndex = 2;
            txtPoder.KeyPress += txtPoder_KeyPress;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.White;
            lblNombre.ForeColor = Color.Black;
            lblNombre.Location = new Point(21, 56);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 20);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre: ";
            // 
            // lblVida
            // 
            lblVida.AutoSize = true;
            lblVida.BackColor = Color.White;
            lblVida.ForeColor = Color.Black;
            lblVida.Location = new Point(50, 117);
            lblVida.Name = "lblVida";
            lblVida.Size = new Size(42, 20);
            lblVida.TabIndex = 5;
            lblVida.Text = "Vida:";
            // 
            // lblPoder
            // 
            lblPoder.AutoSize = true;
            lblPoder.BackColor = Color.White;
            lblPoder.ForeColor = Color.Black;
            lblPoder.Location = new Point(38, 176);
            lblPoder.Name = "lblPoder";
            lblPoder.Size = new Size(54, 20);
            lblPoder.TabIndex = 6;
            lblPoder.Text = "Poder: ";
            // 
            // lblRareza
            // 
            lblRareza.AutoSize = true;
            lblRareza.BackColor = Color.White;
            lblRareza.ForeColor = Color.Black;
            lblRareza.Location = new Point(31, 235);
            lblRareza.Name = "lblRareza";
            lblRareza.Size = new Size(61, 20);
            lblRareza.TabIndex = 7;
            lblRareza.Text = "Rareza: ";
            // 
            // lblAtributo1
            // 
            lblAtributo1.AutoSize = true;
            lblAtributo1.BackColor = Color.White;
            lblAtributo1.ForeColor = Color.Black;
            lblAtributo1.Location = new Point(378, 59);
            lblAtributo1.Name = "lblAtributo1";
            lblAtributo1.Size = new Size(21, 20);
            lblAtributo1.TabIndex = 8;
            lblAtributo1.Text = "\"\"";
            // 
            // lblAtributo2
            // 
            lblAtributo2.AutoSize = true;
            lblAtributo2.BackColor = Color.White;
            lblAtributo2.ForeColor = Color.Black;
            lblAtributo2.Location = new Point(378, 124);
            lblAtributo2.Name = "lblAtributo2";
            lblAtributo2.Size = new Size(21, 20);
            lblAtributo2.TabIndex = 9;
            lblAtributo2.Text = "\"\"";
            // 
            // lblAtributo3
            // 
            lblAtributo3.AutoSize = true;
            lblAtributo3.BackColor = Color.White;
            lblAtributo3.ForeColor = Color.Black;
            lblAtributo3.Location = new Point(353, 173);
            lblAtributo3.Name = "lblAtributo3";
            lblAtributo3.Size = new Size(21, 20);
            lblAtributo3.TabIndex = 10;
            lblAtributo3.Text = "\"\"";
            // 
            // txtAtributo1
            // 
            txtAtributo1.BackColor = Color.Gainsboro;
            txtAtributo1.ForeColor = Color.Black;
            txtAtributo1.Location = new Point(471, 53);
            txtAtributo1.MaxLength = 15;
            txtAtributo1.Name = "txtAtributo1";
            txtAtributo1.Size = new Size(120, 26);
            txtAtributo1.TabIndex = 11;
            txtAtributo1.KeyPress += txtAtributo1_KeyPress;
            // 
            // txtAtributo2
            // 
            txtAtributo2.BackColor = Color.Gainsboro;
            txtAtributo2.ForeColor = Color.Black;
            txtAtributo2.Location = new Point(471, 118);
            txtAtributo2.MaxLength = 15;
            txtAtributo2.Name = "txtAtributo2";
            txtAtributo2.Size = new Size(120, 26);
            txtAtributo2.TabIndex = 12;
            txtAtributo2.TextChanged += txtAtributo2_TextChanged;
            txtAtributo2.KeyPress += txtAtributo2_KeyPress;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(222, 322);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(109, 34);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(402, 322);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(109, 34);
            btnAceptar.TabIndex = 17;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // BxRareza
            // 
            BxRareza.BackColor = Color.Gainsboro;
            BxRareza.DropDownStyle = ComboBoxStyle.DropDownList;
            BxRareza.ForeColor = Color.Black;
            BxRareza.FormattingEnabled = true;
            BxRareza.Items.AddRange(new object[] { "Normal", "Rara", "Epica", "Legendaria" });
            BxRareza.Location = new Point(137, 232);
            BxRareza.Name = "BxRareza";
            BxRareza.Size = new Size(145, 27);
            BxRareza.TabIndex = 18;
            // 
            // BxAtributo1
            // 
            BxAtributo1.BackColor = Color.Gainsboro;
            BxAtributo1.DropDownStyle = ComboBoxStyle.DropDownList;
            BxAtributo1.ForeColor = Color.Black;
            BxAtributo1.FormattingEnabled = true;
            BxAtributo1.Location = new Point(471, 117);
            BxAtributo1.Name = "BxAtributo1";
            BxAtributo1.Size = new Size(145, 27);
            BxAtributo1.TabIndex = 19;
            // 
            // BxAtributo2
            // 
            BxAtributo2.BackColor = Color.Gainsboro;
            BxAtributo2.DropDownStyle = ComboBoxStyle.DropDownList;
            BxAtributo2.ForeColor = Color.Black;
            BxAtributo2.FormattingEnabled = true;
            BxAtributo2.Location = new Point(471, 169);
            BxAtributo2.Name = "BxAtributo2";
            BxAtributo2.Size = new Size(145, 27);
            BxAtributo2.TabIndex = 20;
            // 
            // frmCarta
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(704, 368);
            Controls.Add(BxAtributo2);
            Controls.Add(BxAtributo1);
            Controls.Add(BxRareza);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txtAtributo2);
            Controls.Add(txtAtributo1);
            Controls.Add(lblAtributo3);
            Controls.Add(lblAtributo2);
            Controls.Add(lblAtributo1);
            Controls.Add(lblRareza);
            Controls.Add(lblPoder);
            Controls.Add(lblVida);
            Controls.Add(lblNombre);
            Controls.Add(txtPoder);
            Controls.Add(txtVida);
            Controls.Add(txtNombre);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmCarta";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmCarta";
            FormClosing += frmCarta_FormClosing;
            Load += frmCarta_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtVida;
        private TextBox txtPoder;
        private Label lblNombre;
        private Label lblVida;
        private Label lblPoder;
        private Label lblRareza;
        private Label lblAtributo1;
        private Label lblAtributo2;
        private Label lblAtributo3;
        private TextBox txtAtributo1;
        private TextBox txtAtributo2;
        private Button btnCancelar;
        private Button btnAceptar;
        private ComboBox BxRareza;
        private ComboBox BxAtributo1;
        private ComboBox BxAtributo2;
    }
}