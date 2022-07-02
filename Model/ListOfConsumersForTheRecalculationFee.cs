using System;
using System.Collections.Generic;

#nullable disable

namespace Project
{
    public partial class ListOfConsumersForTheRecalculationFee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? IdRequestRecalculationFee { get; set; }

        public virtual RequestRecalculationFee IdRequestRecalculationFeeNavigation { get; set; }
    }
}
