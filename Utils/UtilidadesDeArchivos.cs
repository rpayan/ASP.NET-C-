using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Ine.SihPublico.UI.Web.Utils
{
    public class UtilidadesDeArchivos
    {

        private static string GetConnectionString()
        {
            return ConfigurationManager.AppSettings["DBConnectionString"];
        }

        private static void OpenConnection(SqlConnection connection)
        {
            connection.ConnectionString = GetConnectionString();
            connection.Open();
        }

        // Get the list of the files in the database
        public static DataTable GetFileList(int idAsignacion)
        {
            DataTable fileList = new DataTable();
            using (SqlConnection connection = new SqlConnection())
            {
                OpenConnection(connection);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;

                cmd.CommandText = "SELECT idArchivo, nombreArchivo, tipoArchivo, size, data, idResolucion, idAsignacion FROM Registro.Adjuntos WHERE idAsignacion = @idAsignacion";
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();

                cmd.Parameters.Add("@idAsignacion", SqlDbType.Int);
                cmd.Parameters["@idAsignacion"].Value = idAsignacion;

                adapter.SelectCommand = cmd;
                adapter.Fill(fileList);

                connection.Close();
            }

            return fileList;
        }

        // Save a file into the database
        public static void SaveFile(string nombreArchivo, string tipoArchivo, int size, byte[] data, int idResolucion,int idAsignacion, DateTime fechaRegistro, DateTime fechaModificacion, int idUsuarioRegistro, int idUsuarioModificacion, Boolean activo)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                OpenConnection(connection);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;

                string commandText = "INSERT INTO Registro.Adjuntos(nombreArchivo,tipoArchivo,size,data,idResolucion,idAsignacion,fechaRegistro,fechaModificacion,idUsuarioRegistro,idUsuarioModificacion,activo) " +
                                     "VALUES(@nombreArchivo, @tipoArchivo, @size, @data, @idResolucion,@idAsignacion, @fechaRegistro, @fechaModificacion, @idUsuarioRegistro, @idUsuarioModificacion, @activo)";
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@nombreArchivo", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@tipoArchivo", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@size", SqlDbType.Int);
                cmd.Parameters.Add("@data", SqlDbType.VarBinary);
                cmd.Parameters.Add("@idResolucion", SqlDbType.Int);
                cmd.Parameters.Add("@idAsignacion", SqlDbType.Int);
                cmd.Parameters.Add("@fechaRegistro", SqlDbType.DateTime);
                cmd.Parameters.Add("@fechaModificacion", SqlDbType.DateTime);
                cmd.Parameters.Add("@idUsuarioRegistro", SqlDbType.Int);
                cmd.Parameters.Add("@idUsuarioModificacion", SqlDbType.Int);
                cmd.Parameters.Add("@activo", SqlDbType.Bit);


                cmd.Parameters["@nombreArchivo"].Value = nombreArchivo;
                cmd.Parameters["@tipoArchivo"].Value = tipoArchivo;
                cmd.Parameters["@size"].Value = size;
                cmd.Parameters["@data"].Value = data;
                cmd.Parameters["@idResolucion"].Value = idResolucion;
                cmd.Parameters["@idAsignacion"].Value = idAsignacion;
                cmd.Parameters["@fechaRegistro"].Value = fechaRegistro;
                cmd.Parameters["@fechaModificacion"].Value = fechaModificacion;
                cmd.Parameters["@idUsuarioRegistro"].Value = idUsuarioRegistro;
                cmd.Parameters["@idUsuarioModificacion"].Value = idUsuarioModificacion;
                cmd.Parameters["@activo"].Value = activo;
                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        // Get a file from the database by ID
        public static DataTable GetAFile(int idArchivo)
        {
            DataTable file = new DataTable();
            using (SqlConnection connection = new SqlConnection())
            {
                OpenConnection(connection);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;

                cmd.CommandText = "SELECT idArchivo, nombreArchivo, tipoArchivo, size, data FROM Registro.Adjuntos WHERE idArchivo=@idArchivo";
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();

                cmd.Parameters.Add("@idArchivo", SqlDbType.Int);
                cmd.Parameters["@idArchivo"].Value = idArchivo;

                adapter.SelectCommand = cmd;
                adapter.Fill(file);

                connection.Close();
            }

            return file;
        }

        // Get a file from the database by ID
        public static void DeleteAFile(int idArchivo)
        {
            
            using (SqlConnection connection = new SqlConnection())
            {
                OpenConnection(connection);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;

                cmd.CommandText = "Delete FROM Registro.Adjuntos WHERE idArchivo=@idArchivo";
                cmd.CommandType = CommandType.Text;
                

                cmd.Parameters.Add("@idArchivo", SqlDbType.Int);
                cmd.Parameters["@idArchivo"].Value = idArchivo;

                cmd.ExecuteNonQuery();
                connection.Close();
            }

           
        }

    }
}