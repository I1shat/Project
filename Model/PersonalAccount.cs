using System;
using System.Collections.Generic;

#nullable disable

namespace Project
{
    public partial class PersonalAccount
    {
        public int Id { get; set; }
        public int? IdSubscriber { get; set; }
        public int? IdFacility { get; set; }
        public string ShareSize { get; set; }

        public virtual Facility IdFacilityNavigation { get; set; }
        public virtual Subscriber IdSubscriberNavigation { get; set; }
    }
}
