namespace Sistema.UI.Formularios
{
    partial class MDIMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolCaja = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.kStyleManager1 = new Klik.Windows.Forms.v1.Common.KStyleManager(this.components);
            this.menuTitulo = new System.Windows.Forms.MenuStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTituloSuperior = new System.Windows.Forms.Label();
            this.toolMenu = new System.Windows.Forms.ToolStrip();
            this.iconVentas = new FontAwesome.Sharp.IconDropDownButton();
            this.aperturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cerrarCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cierreDeCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconCatalogo = new FontAwesome.Sharp.IconDropDownButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.listadoDeCategoríasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.listadoDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconInventario = new FontAwesome.Sharp.IconDropDownButton();
            this.ingresosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.egresosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.kardexDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconReportes = new FontAwesome.Sharp.IconDropDownButton();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.iconSeguridad = new FontAwesome.Sharp.IconDropDownButton();
            this.administradorDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.editarDatosDeLaEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.conexiónALaBaseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupDeLaBaseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconSalir = new FontAwesome.Sharp.IconToolStripButton();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCaja,
            this.toolUsuario});
            this.statusStrip.Location = new System.Drawing.Point(0, 565);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(998, 29);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolCaja
            // 
            this.toolCaja.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolCaja.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.toolCaja.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolCaja.Name = "toolCaja";
            this.toolCaja.Size = new System.Drawing.Size(46, 24);
            this.toolCaja.Text = "Caja:";
            // 
            // toolUsuario
            // 
            this.toolUsuario.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolUsuario.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.toolUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolUsuario.Name = "toolUsuario";
            this.toolUsuario.Size = new System.Drawing.Size(70, 24);
            this.toolUsuario.Text = "Usuario:";
            // 
            // menuTitulo
            // 
            this.menuTitulo.AutoSize = false;
            this.menuTitulo.BackColor = System.Drawing.Color.DarkSlateGray;
            this.menuTitulo.Location = new System.Drawing.Point(0, 0);
            this.menuTitulo.Name = "menuTitulo";
            this.menuTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuTitulo.Size = new System.Drawing.Size(998, 74);
            this.menuTitulo.TabIndex = 4;
            this.menuTitulo.Text = "menuStrip1";
            this.menuTitulo.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuTitulo_ItemClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pictureBox1.Image = global::Sistema.UI.Properties.Resources.store;
            this.pictureBox1.Location = new System.Drawing.Point(31, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblTituloSuperior
            // 
            this.lblTituloSuperior.AutoSize = true;
            this.lblTituloSuperior.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lblTituloSuperior.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSuperior.ForeColor = System.Drawing.Color.White;
            this.lblTituloSuperior.Location = new System.Drawing.Point(113, 18);
            this.lblTituloSuperior.Name = "lblTituloSuperior";
            this.lblTituloSuperior.Size = new System.Drawing.Size(313, 45);
            this.lblTituloSuperior.TabIndex = 6;
            this.lblTituloSuperior.Text = "POS - TECNOLOGÍA";
            // 
            // toolMenu
            // 
            this.toolMenu.BackColor = System.Drawing.SystemColors.Control;
            this.toolMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconVentas,
            this.iconCatalogo,
            this.iconInventario,
            this.iconReportes,
            this.iconSeguridad,
            this.iconSalir});
            this.toolMenu.Location = new System.Drawing.Point(0, 74);
            this.toolMenu.Name = "toolMenu";
            this.toolMenu.Size = new System.Drawing.Size(998, 38);
            this.toolMenu.TabIndex = 7;
            this.toolMenu.Text = "toolStrip1";
            // 
            // iconVentas
            // 
            this.iconVentas.AutoSize = false;
            this.iconVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aperturaToolStripMenuItem,
            this.toolStripSeparator1,
            this.cerrarCajaToolStripMenuItem,
            this.ventasToolStripMenuItem,
            this.historialDeVentasToolStripMenuItem,
            this.toolStripSeparator2,
            this.cierreDeCajaToolStripMenuItem});
            this.iconVentas.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconVentas.IconChar = FontAwesome.Sharp.IconChar.DollyFlatbed;
            this.iconVentas.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconVentas.IconSize = 30;
            this.iconVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iconVentas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.iconVentas.Name = "iconVentas";
            this.iconVentas.Size = new System.Drawing.Size(130, 35);
            this.iconVentas.Text = "Ventas";
            // 
            // aperturaToolStripMenuItem
            // 
            this.aperturaToolStripMenuItem.Name = "aperturaToolStripMenuItem";
            this.aperturaToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.aperturaToolStripMenuItem.Text = "Apertura de caja";
            this.aperturaToolStripMenuItem.Click += new System.EventHandler(this.aperturaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // cerrarCajaToolStripMenuItem
            // 
            this.cerrarCajaToolStripMenuItem.Name = "cerrarCajaToolStripMenuItem";
            this.cerrarCajaToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.cerrarCajaToolStripMenuItem.Text = "Cerrar caja";
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.ventasToolStripMenuItem.Text = "Ventas";
            this.ventasToolStripMenuItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);
            // 
            // historialDeVentasToolStripMenuItem
            // 
            this.historialDeVentasToolStripMenuItem.Name = "historialDeVentasToolStripMenuItem";
            this.historialDeVentasToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.historialDeVentasToolStripMenuItem.Text = "Historial de ventas";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(201, 6);
            // 
            // cierreDeCajaToolStripMenuItem
            // 
            this.cierreDeCajaToolStripMenuItem.Name = "cierreDeCajaToolStripMenuItem";
            this.cierreDeCajaToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.cierreDeCajaToolStripMenuItem.Text = "Cierre de caja";
            // 
            // iconCatalogo
            // 
            this.iconCatalogo.AutoSize = false;
            this.iconCatalogo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.listadoDeCategoríasToolStripMenuItem,
            this.toolStripSeparator6,
            this.listadoDeProductosToolStripMenuItem});
            this.iconCatalogo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconCatalogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconCatalogo.IconChar = FontAwesome.Sharp.IconChar.Folder;
            this.iconCatalogo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconCatalogo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCatalogo.IconSize = 30;
            this.iconCatalogo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iconCatalogo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.iconCatalogo.Name = "iconCatalogo";
            this.iconCatalogo.Size = new System.Drawing.Size(130, 35);
            this.iconCatalogo.Text = "Catálogo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(218, 6);
            // 
            // listadoDeCategoríasToolStripMenuItem
            // 
            this.listadoDeCategoríasToolStripMenuItem.Name = "listadoDeCategoríasToolStripMenuItem";
            this.listadoDeCategoríasToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.listadoDeCategoríasToolStripMenuItem.Text = "Listado de categorías";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(218, 6);
            // 
            // listadoDeProductosToolStripMenuItem
            // 
            this.listadoDeProductosToolStripMenuItem.Name = "listadoDeProductosToolStripMenuItem";
            this.listadoDeProductosToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.listadoDeProductosToolStripMenuItem.Text = "Listado de productos";
            // 
            // iconInventario
            // 
            this.iconInventario.AutoSize = false;
            this.iconInventario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresosToolStripMenuItem,
            this.egresosToolStripMenuItem,
            this.toolStripSeparator4,
            this.kardexDeProductosToolStripMenuItem});
            this.iconInventario.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconInventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconInventario.IconChar = FontAwesome.Sharp.IconChar.TruckRampBox;
            this.iconInventario.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconInventario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconInventario.IconSize = 30;
            this.iconInventario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iconInventario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.iconInventario.Name = "iconInventario";
            this.iconInventario.Size = new System.Drawing.Size(160, 35);
            this.iconInventario.Text = "Movimientos";
            // 
            // ingresosToolStripMenuItem
            // 
            this.ingresosToolStripMenuItem.Name = "ingresosToolStripMenuItem";
            this.ingresosToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.ingresosToolStripMenuItem.Text = "Ingresos";
            // 
            // egresosToolStripMenuItem
            // 
            this.egresosToolStripMenuItem.Name = "egresosToolStripMenuItem";
            this.egresosToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.egresosToolStripMenuItem.Text = "Egresos";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(217, 6);
            // 
            // kardexDeProductosToolStripMenuItem
            // 
            this.kardexDeProductosToolStripMenuItem.Name = "kardexDeProductosToolStripMenuItem";
            this.kardexDeProductosToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.kardexDeProductosToolStripMenuItem.Text = "Kardex de productos";
            // 
            // iconReportes
            // 
            this.iconReportes.AutoSize = false;
            this.iconReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.iconReportes.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconReportes.IconChar = FontAwesome.Sharp.IconChar.Newspaper;
            this.iconReportes.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconReportes.IconSize = 30;
            this.iconReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iconReportes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.iconReportes.Name = "iconReportes";
            this.iconReportes.Size = new System.Drawing.Size(130, 35);
            this.iconReportes.Text = "Reportes";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(122, 24);
            this.toolStripMenuItem2.Text = "Gastos";
            // 
            // iconSeguridad
            // 
            this.iconSeguridad.AutoSize = false;
            this.iconSeguridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administradorDeUsuariosToolStripMenuItem,
            this.toolStripSeparator8,
            this.editarDatosDeLaEmpresaToolStripMenuItem,
            this.toolStripSeparator9,
            this.conexiónALaBaseDeDatosToolStripMenuItem,
            this.backupDeLaBaseDeDatosToolStripMenuItem});
            this.iconSeguridad.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconSeguridad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconSeguridad.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.iconSeguridad.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconSeguridad.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSeguridad.IconSize = 30;
            this.iconSeguridad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iconSeguridad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.iconSeguridad.Name = "iconSeguridad";
            this.iconSeguridad.Size = new System.Drawing.Size(130, 35);
            this.iconSeguridad.Text = "Seguridad";
            // 
            // administradorDeUsuariosToolStripMenuItem
            // 
            this.administradorDeUsuariosToolStripMenuItem.Name = "administradorDeUsuariosToolStripMenuItem";
            this.administradorDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(268, 24);
            this.administradorDeUsuariosToolStripMenuItem.Text = "Administrador de usuarios";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(265, 6);
            // 
            // editarDatosDeLaEmpresaToolStripMenuItem
            // 
            this.editarDatosDeLaEmpresaToolStripMenuItem.Name = "editarDatosDeLaEmpresaToolStripMenuItem";
            this.editarDatosDeLaEmpresaToolStripMenuItem.Size = new System.Drawing.Size(268, 24);
            this.editarDatosDeLaEmpresaToolStripMenuItem.Text = "Editar datos de la empresa";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(265, 6);
            // 
            // conexiónALaBaseDeDatosToolStripMenuItem
            // 
            this.conexiónALaBaseDeDatosToolStripMenuItem.Name = "conexiónALaBaseDeDatosToolStripMenuItem";
            this.conexiónALaBaseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(268, 24);
            this.conexiónALaBaseDeDatosToolStripMenuItem.Text = "Conexión a la base de datos";
            // 
            // backupDeLaBaseDeDatosToolStripMenuItem
            // 
            this.backupDeLaBaseDeDatosToolStripMenuItem.Name = "backupDeLaBaseDeDatosToolStripMenuItem";
            this.backupDeLaBaseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(268, 24);
            this.backupDeLaBaseDeDatosToolStripMenuItem.Text = "Backup de la base de datos";
            // 
            // iconSalir
            // 
            this.iconSalir.AutoSize = false;
            this.iconSalir.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconSalir.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.iconSalir.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSalir.IconSize = 30;
            this.iconSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iconSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.iconSalir.Name = "iconSalir";
            this.iconSalir.Size = new System.Drawing.Size(130, 35);
            this.iconSalir.Text = "Cerrar sesión";
            this.iconSalir.Click += new System.EventHandler(this.iconSalir_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 112);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(998, 453);
            this.panelContenedor.TabIndex = 9;
            // 
            // MDIMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 594);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.toolMenu);
            this.Controls.Add(this.lblTituloSuperior);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuTitulo);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuTitulo;
            this.Name = "MDIMenu";
            this.Text = "MDIMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIMenu_FormClosing);
            this.Load += new System.EventHandler(this.MDIMenu_Load);
            this.Resize += new System.EventHandler(this.MDIMenu_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolMenu.ResumeLayout(false);
            this.toolMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolCaja;
        private System.Windows.Forms.ToolTip toolTip;
        private Klik.Windows.Forms.v1.Common.KStyleManager kStyleManager1;
        private System.Windows.Forms.MenuStrip menuTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTituloSuperior;
        private System.Windows.Forms.ToolStrip toolMenu;
        private FontAwesome.Sharp.IconDropDownButton iconVentas;
        private FontAwesome.Sharp.IconDropDownButton iconInventario;
        private FontAwesome.Sharp.IconDropDownButton iconSeguridad;
        private FontAwesome.Sharp.IconToolStripButton iconSalir;
        private System.Windows.Forms.ToolStripMenuItem aperturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cerrarCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialDeVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cierreDeCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kardexDeProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administradorDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem editarDatosDeLaEmpresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem conexiónALaBaseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupDeLaBaseDeDatosToolStripMenuItem;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.ToolStripStatusLabel toolUsuario;
        private FontAwesome.Sharp.IconDropDownButton iconCatalogo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem listadoDeCategoríasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem listadoDeProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem egresosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private FontAwesome.Sharp.IconDropDownButton iconReportes;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}



