using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseHandler
{
    public partial class RentalOrderDetail
    {
        public int OrderId { get; set; }
        public string PickUpDate { get; set; }
        public string DropOffDate { get; set; }
        public string DateOfficiallyReturned { get; set; }
        public int UserId { get; set; }
        public string SerialNumber { get; set; }
    }
}
