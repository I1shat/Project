using System;
using System.Collections.Generic;

#nullable disable

namespace Project
{
    public partial class Facility
    {
        public Facility()
        {
            FacilityConsumers = new HashSet<FacilityConsumer>();
            PersonalAccounts = new HashSet<PersonalAccount>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public double? LivingArea { get; set; }
        public double? TotalArea { get; set; }

        public virtual ICollection<FacilityConsumer> FacilityConsumers { get; set; }
        public virtual ICollection<PersonalAccount> PersonalAccounts { get; set; }
    }
}
