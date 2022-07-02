using System;
using System.Collections.Generic;

#nullable disable

namespace Project
{
    public partial class RequestRecalculationFee
    {
        public RequestRecalculationFee()
        {
            ListOfConsumersForTheRecalculationFees = new HashSet<ListOfConsumersForTheRecalculationFee>();
        }

        public int Id { get; set; }
        public int? IdPersonalAccount { get; set; }
        public string FullName { get; set; }
        public DateTime? DateofApplicationSubmission { get; set; }
        public string PassportSeries { get; set; }
        public string PassportId { get; set; }
        public DateTime? PassportDate { get; set; }
        public string DepartmentCode { get; set; }
        public string Telephone { get; set; }
        public string ReviewStatus { get; set; }

        public virtual ICollection<ListOfConsumersForTheRecalculationFee> ListOfConsumersForTheRecalculationFees { get; set; }
    }
}
