using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public DateTime ReserveTime { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual AppUser? User { get; set; }
        public int ResTabId { get; set; }
        public virtual RestTabs? ResTable { get; set; }
        public string Description { get; set; }
    }
}
