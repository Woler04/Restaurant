using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReserveTime { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual AppUser? User { get; set; }

        [ForeignKey("TableId")]
        public string TableId { get; set; }
        public virtual Table? Table { get; set; }
        public string Description { get; set; }
    }
}
