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
            List<SkemaModel> skemaList = new List<SkemaModel>();
            try
            {
                string query = "select * from monitoring_data";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SkemaModel skema = new SkemaModel
                    {
                        id = Convert.ToInt32(reader["id_skema"].ToString()),
                        Nama_skema = reader["Nama_Skema"].ToString(),
                        start_date = Convert.ToDateTime(reader["start_date"]),
                        end_date = Convert.ToDateTime(reader["end_date"]),
                    };
                    skemaList.Add(skema);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return skemaList;
        }

        public SkemaModel getData(int id)
        {
            SkemaModel skemaModel = new SkemaModel();
            try
            {
                string query = "select * from monitoring_data where id = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                skemaModel.id = Convert.ToInt32(reader["id_skema"].ToString());
                skemaModel.Nama_skema = reader["Nama_Skema"].ToString();
                skemaModel.start_date = Convert.ToDateTime(reader["start_date"]);
                skemaModel.end_date = Convert.ToDateTime(reader["end_date"]);
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return skemaModel;
        }

        public void insertData(SkemaModel skemaModel)
        {
            try
            {
                string query = "insert into monitoring_data values(@p1,@p2,@p3)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", skemaModel.Nama_skema);
                command.Parameters.AddWithValue("@p2", skemaModel.start_date);
                command.Parameters.AddWithValue("@p3", skemaModel.end_date);
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
                string query = "update monitoring_data " +
                    "set Nama_Skena = @p2" +
                    ",start_date = @p3" +
                    ",end_date = @p4" +
                    "where id_skema = @p1";

                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", skemaModel.id);
                command.Parameters.AddWithValue("@p2", skemaModel.Nama_skema);
                command.Parameters.AddWithValue("@P3", skemaModel.start_date);
                command.Parameters.AddWithValue("@p4", skemaModel.end_date);
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
                string query = "delete from monitoring_data id = @p1";
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
