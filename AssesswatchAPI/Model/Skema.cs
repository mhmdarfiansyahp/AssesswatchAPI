using System.Data.SqlClient;

namespace AssesswatchAPI.Model
{
    public class Skema
    {
        //alamat koneksi database
        private readonly string _connectionString;

        //koneksi sql
        private readonly SqlConnection _connection;

        //Constuctor kelas yang akan digunakan untuk mengsetup connection string

        public Skema(IConfiguration configuration)
        {
            //Menganmbil konfigurasi connection string dari appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(_connectionString);
        }

        public List<SkemaModel> getAllData()
        {
            List<SkemaModel> bukuList = new List<SkemaModel>();
            try
            {
                string query = "select * from tb_skema";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SkemaModel buku = new SkemaModel
                    {
                        id = Convert.ToInt32(reader["id_skema"].ToString()),
                        Nama_skema = reader["Nama_skema"].ToString(),
                    };
                    bukuList.Add(buku);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return bukuList;
        }

        public SkemaModel getData(int id)
        {
            SkemaModel skemaModel = new SkemaModel();
            try
            {
                string query = "select * from tb_skema where id_skema = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                skemaModel.id = Convert.ToInt32(reader["id_skema"].ToString());
                skemaModel.Nama_skema = reader["Nama_Skema"].ToString();
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return skemaModel;
        }

        public void insertData(SkemaModel bukuModel)
        {
            try
            {
                string query = "insert into tb_skema values(@p1)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", bukuModel.Nama_skema);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void updateData(SkemaModel skemaModel)
        {
            try
            {
                string query = "update tb_skema " +
                    "set Nama_Skena = @p2" +
                    "where id_skema = @p1";

                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", skemaModel.id);
                command.Parameters.AddWithValue("@p2", skemaModel.Nama_skema);
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
                string query = "delete from tb_skema id_skema = @p1";
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
