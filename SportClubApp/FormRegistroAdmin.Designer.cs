namespace SportClubApp
{
    partial class FormRegistroAdmin
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
            lblRegistroAdmin = new Label();
            lblUserAdmin = new Label();
            txtUserAdmin = new TextBox();
            lblPasswordAdmin = new Label();
            txtPasswordAdmin = new TextBox();
            lblConfPasswordAdmin = new Label();
            txtConfPassAdmin = new TextBox();
            btnRegistrarAdmin = new Button();
            btnCancelarAdmin = new Button();
            SuspendLayout();
            // 
            // lblRegistroAdmin
            // 
            lblRegistroAdmin.AutoSize = true;
            lblRegistroAdmin.Font = new Font("Candara", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRegistroAdmin.Location = new Point(326, 103);
            lblRegistroAdmin.Name = "lblRegistroAdmin";
            lblRegistroAdmin.Size = new Size(226, 26);
            lblRegistroAdmin.TabIndex = 0;
            lblRegistroAdmin.Text = "Registro Administrador";
            // 
            // lblUserAdmin
            // 
            lblUserAdmin.AutoSize = true;
            lblUserAdmin.Font = new Font("Candara", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserAdmin.Location = new Point(271, 176);
            lblUserAdmin.Name = "lblUserAdmin";
            lblUserAdmin.Size = new Size(49, 15);
            lblUserAdmin.TabIndex = 1;
            lblUserAdmin.Text = "Usuario";
            // 
            // txtUserAdmin
            // 
            txtUserAdmin.Font = new Font("Candara", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUserAdmin.Location = new Point(424, 176);
            txtUserAdmin.Margin = new Padding(3, 4, 3, 4);
            txtUserAdmin.Name = "txtUserAdmin";
            txtUserAdmin.Size = new Size(193, 23);
            txtUserAdmin.TabIndex = 2;
            // 
            // lblPasswordAdmin
            // 
            lblPasswordAdmin.AutoSize = true;
            lblPasswordAdmin.Font = new Font("Candara", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPasswordAdmin.Location = new Point(270, 233);
            lblPasswordAdmin.Name = "lblPasswordAdmin";
            lblPasswordAdmin.Size = new Size(69, 15);
            lblPasswordAdmin.TabIndex = 3;
            lblPasswordAdmin.Text = "Contraseña";
            // 
            // txtPasswordAdmin
            // 
            txtPasswordAdmin.Font = new Font("Candara", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPasswordAdmin.Location = new Point(424, 233);
            txtPasswordAdmin.Margin = new Padding(3, 4, 3, 4);
            txtPasswordAdmin.Name = "txtPasswordAdmin";
            txtPasswordAdmin.Size = new Size(191, 23);
            txtPasswordAdmin.TabIndex = 3;
            // 
            // lblConfPasswordAdmin
            // 
            lblConfPasswordAdmin.AutoSize = true;
            lblConfPasswordAdmin.Font = new Font("Candara", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConfPasswordAdmin.Location = new Point(266, 290);
            lblConfPasswordAdmin.Name = "lblConfPasswordAdmin";
            lblConfPasswordAdmin.Size = new Size(128, 15);
            lblConfPasswordAdmin.TabIndex = 5;
            lblConfPasswordAdmin.Text = "Confirmar Contraseña";
            // 
            // txtConfPassAdmin
            // 
            txtConfPassAdmin.Location = new Point(424, 286);
            txtConfPassAdmin.Margin = new Padding(3, 4, 3, 4);
            txtConfPassAdmin.Name = "txtConfPassAdmin";
            txtConfPassAdmin.Size = new Size(193, 26);
            txtConfPassAdmin.TabIndex = 4;
            // 
            // btnRegistrarAdmin
            // 
            btnRegistrarAdmin.BackColor = Color.FromArgb(0, 192, 0);
            btnRegistrarAdmin.Font = new Font("Candara", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrarAdmin.ForeColor = Color.White;
            btnRegistrarAdmin.Location = new Point(278, 353);
            btnRegistrarAdmin.Margin = new Padding(3, 4, 3, 4);
            btnRegistrarAdmin.Name = "btnRegistrarAdmin";
            btnRegistrarAdmin.Size = new Size(126, 53);
            btnRegistrarAdmin.TabIndex = 5;
            btnRegistrarAdmin.Text = "Registrar Administrador";
            btnRegistrarAdmin.UseVisualStyleBackColor = false;
            btnRegistrarAdmin.Click += btnRegistrar_ClickAdmin;
            // 
            // btnCancelarAdmin
            // 
            btnCancelarAdmin.BackColor = Color.FromArgb(0, 192, 0);
            btnCancelarAdmin.Font = new Font("Candara", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelarAdmin.ForeColor = Color.White;
            btnCancelarAdmin.Location = new Point(491, 355);
            btnCancelarAdmin.Margin = new Padding(3, 4, 3, 4);
            btnCancelarAdmin.Name = "btnCancelarAdmin";
            btnCancelarAdmin.Size = new Size(126, 52);
            btnCancelarAdmin.TabIndex = 6;
            btnCancelarAdmin.Text = "Cancelar";
            btnCancelarAdmin.UseVisualStyleBackColor = false;
            btnCancelarAdmin.Click += btnCancelar_Click;
            // 
            // FormRegistroAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 570);
            Controls.Add(btnCancelarAdmin);
            Controls.Add(btnRegistrarAdmin);
            Controls.Add(txtConfPassAdmin);
            Controls.Add(lblConfPasswordAdmin);
            Controls.Add(txtPasswordAdmin);
            Controls.Add(lblPasswordAdmin);
            Controls.Add(txtUserAdmin);
            Controls.Add(lblUserAdmin);
            Controls.Add(lblRegistroAdmin);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormRegistroAdmin";
            Text = "Formulario Acceso Administrador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRegistroAdmin;
        private Label lblUserAdmin;
        private TextBox txtUserAdmin;
        private Label lblPasswordAdmin;
        private TextBox txtPasswordAdmin;
        private Label lblConfPasswordAdmin;
        private TextBox txtConfPassAdmin;
        private Button btnRegistrarAdmin;
        private Button btnCancelarAdmin;
    }
}