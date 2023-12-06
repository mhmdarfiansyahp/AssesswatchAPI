using System.ComponentModel.DataAnnotations;

namespace AssesswatchAPI.Model
{
    public class SkemaModel
    {
        public int id { get; set; }

        public string Nama_skema { get; set; }


        [DataType(DataType.Date)]
        public DateTime start_date { get; set; }

        [DataType(DataType.Date)]
        public DateTime end_date { get; set; }
    }
}
