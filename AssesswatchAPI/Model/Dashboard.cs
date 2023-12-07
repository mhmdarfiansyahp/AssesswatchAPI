using System;
using System.Data.SqlClient;

namespace AssesswatchAPI.Model
{
    public class Dashboard
    {
        //alamat koneksi database
        private readonly string _connectionString;

        //koneksi sql
        private readonly SqlConnection _connection;

        //Constuctor kelas yang akan digunakan untuk mengsetup connection string

        public Dashboard(IConfiguration configuration)
        {
            //Menganmbil konfigurasi connection string dari appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(_connectionString);
        }

        public List<DashboardModel> getAllData()
        {
            List<DashboardModel> dashboardList = new List<DashboardModel>();
            try
            {
                string query = "select * from dashboard";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DashboardModel dashboard = new DashboardModel
                    {
                        id = Convert.ToInt32(reader["id_dashboard"].ToString()),
                        nama = reader["nama_prodi"].ToString(),
                        kompeten = Convert.ToInt32(reader["peserta_kompeten"].ToString()),
                        tidak_kompeten = Convert.ToInt32(reader["peserta_tidak_kompeten"].ToString()),
                        tidak_hadir = Convert.ToInt32(reader["peserta_tidak_hadir"].ToString()),
                        total = Convert.ToInt32(reader["total_peserta"].ToString()),
                        nama_skema = reader["Nama_Skema"].ToString(),
                        unit = reader["unit_kompetensi"].ToString(),
                    };
                    dashboardList.Add(dashboard);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dashboardList;
        }

        public DashboardModel getData(int id)
        {
            DashboardModel dashboardModel = new DashboardModel();
            try
            {
                string query = "select * from tb_dashboard where id = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                dashboardModel.id = Convert.ToInt32(reader["id_dashboard"].ToString());
                dashboardModel.nama = reader["nama_prodi"].ToString();
                dashboardModel.kompeten = Convert.ToInt32(reader["peserta_kompeten"].ToString());
                dashboardModel.tidak_kompeten = Convert.ToInt32(reader["peserta_tidak_kompeten"].ToString());
                dashboardModel.tidak_hadir = Convert.ToInt32(reader["peserta_tidak_hadir"].ToString());
                dashboardModel.total = Convert.ToInt32(reader["total_peserta"].ToString());
                dashboardModel.nama_skema = reader["Nama_Skema"].ToString();
                dashboardModel.unit = reader["unit_kompetensi"].ToString();
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dashboardModel;
        }

        public void insertData(DashboardModel dashboardModel)
        {
            try
            {
                string query = "insert into tb_dashboard values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", dashboardModel.nama);
                command.Parameters.AddWithValue("@p2", dashboardModel.kompeten);
                command.Parameters.AddWithValue("@p3", dashboardModel.tidak_kompeten);
                command.Parameters.AddWithValue("@p4", dashboardModel.tidak_hadir);
                command.Parameters.AddWithValue("@p5", dashboardModel.total);
                command.Parameters.AddWithValue("@p6", dashboardModel.nama_skema);
                command.Parameters.AddWithValue("@p7", dashboardModel.unit);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void updateData(DashboardModel dashboardModel)
        {
            try
            {
                string query = "update tb_dashboard " +
                    "set nama_prodi = @p2" +
                    ",peserta_kompeten = @p3" +
                    ",peserta_tidak_kompeten = @p4" +
                    ",peserta_tidak_hadir = @p5 " +
                    ",total_peserta = @p6 " +
                    ",Nama_Skema = @p7" +
                    ",unit_kompetensi = @p8" +
                    "where id_dashboard = @p1";

                using SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", dashboardModel.nama);
                command.Parameters.AddWithValue("@p2", dashboardModel.kompeten);
                command.Parameters.AddWithValue("@p3", dashboardModel.tidak_kompeten);
                command.Parameters.AddWithValue("@p4", dashboardModel.tidak_hadir);
                command.Parameters.AddWithValue("@p5", dashboardModel.total);
                command.Parameters.AddWithValue("@p6", dashboardModel.nama_skema);
                command.Parameters.AddWithValue("@p7", dashboardModel.unit);
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
                string query = "delete from tb_dashboard where id = @p1";
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
