using System.Data.SqlClient;

namespace AssesswatchAPI.Model
{
    public class Prodi
    {
        //alamat koneksi database
        private readonly string _connectionString;

        //koneksi sql
        private readonly SqlConnection _connection;

        //Constuctor kelas yang akan digunakan untuk mengsetup connection string

        public Prodi(IConfiguration configuration)
        {
            //Menganmbil konfigurasi connection string dari appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(_connectionString);
        }

        public List<ProdiModel> getAllData()
        {
            List<ProdiModel> prodiList = new List<ProdiModel>();
            try
            {
                string query = "select * from tb_prodi";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ProdiModel prodi = new ProdiModel
                    {
                        id = Convert.ToInt32(reader["id_prodi"].ToString()),
                        Nama_prodi = reader["nama_prodi"].ToString(),
                    };
                    prodiList.Add(prodi);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return prodiList;
        }

        public ProdiModel getData(int id)
        {
            ProdiModel prodiModel = new ProdiModel();
            try
            {
                string query = "select * from tb_prodi where id = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                prodiModel.id = Convert.ToInt32(reader["id_prodi"].ToString());
                prodiModel.Nama_prodi = reader["nama_prodi"].ToString();
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return prodiModel;
        }

        public void insertData(ProdiModel prodiModel)
        {
            try
            {
                string query = "insert into tb_prodi values(@p1,@p2,@p3)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", prodiModel.Nama_prodi);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void updateData(ProdiModel prodiModel)
        {
            try
            {
                string query = "update tb_prodi " +
                    "set nama_prodi = @p2" +
                    "where id_prodi = @p1";

                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", prodiModel.id);
                command.Parameters.AddWithValue("@p2", prodiModel.Nama_prodi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void deleteData(int id)
        {
            try
            {
                string query = "delete from tb_prodi id = @p1";
                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}

