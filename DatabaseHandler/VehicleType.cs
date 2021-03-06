using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseHandler
{
    public partial class VehicleType
    {
        public int VehicleTypeId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public decimal CostPerDay { get; set; }
        public decimal CostPerDayDelayed { get; set; }
        public string DateManufactured { get; set; }
        public string Gear { get; set; }
    }
}
