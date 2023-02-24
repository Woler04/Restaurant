using Microsoft.AspNetCore.Identity;

namespace Restaurant.Data
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public virtual List<Reservation> ReservationsList { get; set; }
        public AppUser()
        {
            ReservationsList = new List<Reservation>();
        }
    }
}
