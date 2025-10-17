using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportClubApp
{
    public partial class FormRegistroSocio : Form
    {
        public FormRegistroSocio()
        {
            InitializeComponent();

            // ===== Dark Mode =====
            // Aplicar tema al abrir
            ThemeManager.ApplyTheme(this);
            AplicarTema();

            // Suscribirse a cambios
            ThemeManager.ThemeChanged += (s, e) => AplicarTema();
            // ================================

            if (!DBHelper.TestConnection())
            {
                MessageBox.Show(
                    "No se pudo conectar a la base de datos.\n\n" +
                    "Verifica que MySQL esté ejecutándose.",
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            // Configurar PasswordChar para los campos de contraseña
            txtPassword.PasswordChar = '*';
            txtConfirmarPassword.PasswordChar = '*';
        }

        // ===== Método para Aplicar Dark Mode =====
        private void AplicarTema()
        {
            if (ThemeManager.IsDarkMode)
            {
                this.BackColor = ThemeManager.DarkTheme.Background;
                this.ForeColor = ThemeManager.DarkTheme.Text;
                
            }
            else
            {
                this.BackColor = ThemeManager.LightTheme.Background;
                this.ForeColor = ThemeManager.LightTheme.Text;
            }
        }
        // ====================================================


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                MessageBox.Show("El DNI es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDNI.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("La contraseña es obligatoria", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtConfirmarPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarPassword.Focus();
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Verificar DNI duplicado
            if (DBHelper.PersonaExistsByDni(txtDNI.Text.Trim()))
            {
                MessageBox.Show("Ya existe una persona con ese DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDNI.Focus();
                return;
            }

            // Verificar username duplicado
            if (DBHelper.UsernameExists(txtUsuario.Text.Trim()))
            {
                MessageBox.Show("Ese nombre de usuario ya está en uso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Focus();
                return;
            }

            try
            {
                // 1. Insertar Persona
                int personaId = DBHelper.InsertPersona(
                    txtNombre.Text.Trim(),
                    txtApellido.Text.Trim(),
                    txtDNI.Text.Trim(),
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                    string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    "Socio"
                );

                // 2. Generar carnet
                string carnet = $"SOC-{personaId:D5}";

                // 3. Insertar Socio
                DBHelper.InsertSocio(
                    personaId,
                    dtpFechaAlta.Value.Date,
                    chkHabilitado.Checked,
                    chkAptoFisico.Checked,
                    carnet
                );

                // 4. Crear usuario asociado
                DBHelper.InsertUsuarioConPersona(
                    txtUsuario.Text.Trim(),
                    txtPassword.Text,
                    "Socio",
                    personaId
                );

                MessageBox.Show(
                    $"Socio registrado exitosamente\n\n" +
                    $"Nombre: {txtNombre.Text} {txtApellido.Text}\n" +
                    $"DNI: {txtDNI.Text}\n" +
                    $"Usuario: {txtUsuario.Text}\n" +
                    $"Carnet: {carnet}\n" +
                    $"Fecha Alta: {dtpFechaAlta.Value.ToShortDateString()}",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}