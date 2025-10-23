namespace Sistema.UI.Formularios
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
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Location = new System.Drawing.Point(77, 32);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTitulo.Size = new System.Drawing.Size(317, 46);
            this.lblTitulo.Text = "Listado de usuarios";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtBuscar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.DisabledState.Parent = this.txtBuscar;
            this.txtBuscar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.FocusedState.Parent = this.txtBuscar;
            this.txtBuscar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.HoverState.Parent = this.txtBuscar;
            this.txtBuscar.Location = new System.Drawing.Point(433, 30);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBuscar.ShadowDecoration.Parent = this.txtBuscar;
            this.txtBuscar.Size = new System.Drawing.Size(341, 49);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.Location = new System.Drawing.Point(16, 37);
            this.iconPictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.iconPictureBox1.Click += new System.EventHandler(this.iconPictureBox1_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.Location = new System.Drawing.Point(1413, 26);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Click += new System.EventHandler(this.iconCerrar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(83)))), ((int)(((byte)(80)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnEliminar.Location = new System.Drawing.Point(1211, 26);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Click += new System.EventHandler(this.iconEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnActualizar.Location = new System.Drawing.Point(1009, 26);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizar.Click += new System.EventHandler(this.iconEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnAgregar.Location = new System.Drawing.Point(808, 26);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Click += new System.EventHandler(this.iconAgregar_Click);
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1585, 727);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmUsuarios";
            this.Text = "frmUsuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}