using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Booking
    {
        public int BookingID { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string? AdultCount { get; set; }
        public string? ChildCount { get; set; }
        public string? RoomName { get; set; }
        public string? SpecialRequest { get; set; }        
        public string? Status { get; set; }
        public string? PhoneNumber { get; set; }
        
      
    }
}
