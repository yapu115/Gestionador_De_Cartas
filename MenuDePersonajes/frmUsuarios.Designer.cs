﻿namespace MenuDePersonajes
{
    partial class frmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarios));
            lstVisorUsuarios = new ListBox();
            SuspendLayout();
            // 
            // lstVisorUsuarios
            // 
            lstVisorUsuarios.FormattingEnabled = true;
            lstVisorUsuarios.ItemHeight = 19;
            lstVisorUsuarios.Location = new Point(12, 12);
            lstVisorUsuarios.Name = "lstVisorUsuarios";
            lstVisorUsuarios.Size = new Size(776, 422);
            lstVisorUsuarios.TabIndex = 0;
            // 
            // frmUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(lstVisorUsuarios);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmUsuarios";
            Text = "frmUsuarios";
            Load += frmUsuarios_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstVisorUsuarios;
    }
}