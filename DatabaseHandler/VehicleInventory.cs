using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseHandler
{
    public partial class VehicleInventory
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public int Kilometers { get; set; }
        public bool? CarPhotograph { get; set; }
        public bool Operational { get; set; }
        public bool Available { get; set; }
        public string SerialNumber { get; set; }

        public virtual VehicleType VehicleType { get; set; }
    }
}
