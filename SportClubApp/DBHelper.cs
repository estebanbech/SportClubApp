using System;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace SportClubApp
{
    public static class DBHelper
    {
        private static string Conn => Config.ConnectionString;

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(Conn);
        }

        public static bool TestConnection()
        {
            try
            {
                using var conn = GetConnection();
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // ============================================
        // MÉTODOS PARA PERSONA
        // ============================================
        public static bool PersonaExistsByDni(string dni)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("SELECT COUNT(1) FROM persona WHERE dni = @dni", conn);
            cmd.Parameters.AddWithValue("@dni", dni);
            var cnt = Convert.ToInt32(cmd.ExecuteScalar());
            return cnt > 0;
        }

        public static int InsertPersona(string nombre, string apellido, string dni, string telefono, string email, string tipoPersona)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"INSERT INTO persona (nombre, apellido, dni, telefono, email, tipo_persona) 
                  VALUES (@n, @a, @dni, @tel, @email, @tipo);
                  SELECT LAST_INSERT_ID();", conn);
            cmd.Parameters.AddWithValue("@n", nombre);
            cmd.Parameters.AddWithValue("@a", apellido);
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@tel", telefono ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@email", email ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@tipo", tipoPersona);
            var result = cmd.ExecuteScalar();
            return Convert.ToInt32(result);
        }

        // ============================================
        // MÉTODOS PARA SOCIO
        // ============================================
        public static void InsertSocio(int personaId, DateTime fechaAlta, bool habilitado, bool aptoFisico, string carnet)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"INSERT INTO socio (persona_id, fechaAlta, habilitado, aptofisico, carnet)
                  VALUES (@pid, @fecha, @hab, @apto, @carnet)", conn);
            cmd.Parameters.AddWithValue("@pid", personaId);
            cmd.Parameters.AddWithValue("@fecha", fechaAlta);
            cmd.Parameters.AddWithValue("@hab", habilitado);
            cmd.Parameters.AddWithValue("@apto", aptoFisico);
            cmd.Parameters.AddWithValue("@carnet", carnet ?? (object)DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        // ============================================
        // MÉTODOS PARA NO SOCIO
        // ============================================
        public static void InsertNoSocio(int personaId, bool habilitado, DateTime? fechaVisita)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand(
                @"INSERT INTO nosocio (persona_id, habilitado, fechaVisita)
                  VALUES (@pid, @hab, @fechaVisita)", conn);
            cmd.Parameters.AddWithValue("@pid", personaId);
            cmd.Parameters.AddWithValue("@hab", habilitado);
            cmd.Parameters.AddWithValue("@fechaVisita", fechaVisita.HasValue ? (object)fechaVisita.Value : DBNull.Value);
            cmd.ExecuteNonQuery();
        }

        // ============================================
        // MÉTODOS PARA USUARIO
        // ============================================
        public static bool UsernameExists(string username)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("SELECT COUNT(1) FROM usuario WHERE username = @user", conn);
            cmd.Parameters.AddWithValue("@user", username);
            var cnt = Convert.ToInt32(cmd.ExecuteScalar());
            return cnt > 0;
        }

        public static void InsertUsuario(string username, string passwordPlain, string rol)
        {
            using var conn = GetConnection();
            conn.Open();
            var hashed = BCrypt.Net.BCrypt.HashPassword(passwordPlain);
            using var cmd = new MySqlCommand(
                @"INSERT INTO usuario (username, password, rol, activo) 
                  VALUES (@user, @pass, @rol, @activo)", conn);
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", hashed);
            cmd.Parameters.AddWithValue("@rol", rol);
            cmd.Parameters.AddWithValue("@activo", true);
            cmd.ExecuteNonQuery();
        }

        public static void InsertUsuarioConPersona(string username, string passwordPlain, string rol, int personaId)
        {
            using var conn = GetConnection();
            conn.Open();
            var hashed = BCrypt.Net.BCrypt.HashPassword(passwordPlain);
            using var cmd = new MySqlCommand(
                @"INSERT INTO usuario (username, password, rol, activo, persona_id) 
                  VALUES (@user, @pass, @rol, @activo, @pid)", conn);
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", hashed);
            cmd.Parameters.AddWithValue("@rol", rol);
            cmd.Parameters.AddWithValue("@activo", true);
            cmd.Parameters.AddWithValue("@pid", personaId);
            cmd.ExecuteNonQuery();
        }

        public static bool ValidateUser(string username, string passwordPlain)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("SELECT password FROM usuario WHERE username = @user AND activo = 1", conn);
            cmd.Parameters.AddWithValue("@user", username);
            var obj = cmd.ExecuteScalar();
            if (obj == null) return false;
            var hashed = obj.ToString();
            return BCrypt.Net.BCrypt.Verify(passwordPlain, hashed);
        }

        public static string GetUserRol(string username)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new MySqlCommand("SELECT rol FROM usuario WHERE username = @user AND activo = 1", conn);
            cmd.Parameters.AddWithValue("@user", username);
            var obj = cmd.ExecuteScalar();
            return obj?.ToString(); // Devuelve null si no existe
        }
    }
}
