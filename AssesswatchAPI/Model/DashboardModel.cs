using System.ComponentModel.DataAnnotations;

namespace AssesswatchAPI.Model
{
    public class DashboardModel
    {
        public int id { get; set; }
        public string nama { get; set; }
        public int kompeten { get; set; }
        public int tidak_kompeten { get; set; }
        public int tidak_hadir { get; set; }
        public int total { get; set; }
        public string nama_skema { get; set; }
        public string unit { get; set; }
    }
}
