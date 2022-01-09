using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Models.BookingModel
{
    public class BookingDTO
    {
        public Guid UserId { get; set; }
        
        public Guid LocationId { get; set; }
        
        public Guid Id { get; set; }
        
        public DateTime CheckInDate { get; set; }
        
        public DateTime CheckOutDate { get; set; }
        
        public bool IsCancellable { get; set; }
    }
}
