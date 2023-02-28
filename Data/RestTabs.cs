using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data
{
    public class RestTabs
    {
        [Key]
        public int Id { get; set; }
        public int Seats { get; set; }
        public bool isSmoking { get; set; }
    }
}
