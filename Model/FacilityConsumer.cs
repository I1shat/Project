using System;
using System.Collections.Generic;

#nullable disable

namespace Project
{
    public partial class FacilityConsumer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? IdFacility { get; set; }

        public virtual Facility IdFacilityNavigation { get; set; }
    }
}
