using System;
using System.Collections.Generic;

#nullable disable

namespace Project
{
    public partial class ApplicationForChangingTheNumberOfConsumer
    {
        public ApplicationForChangingTheNumberOfConsumer()
        {
            ListOfConsumersForTheApplications = new HashSet<ListOfConsumersForTheApplication>();
        }

        public int Id { get; set; }
        public string AddressFacility { get; set; }
        public string FullNameApplicant { get; set; }
        public string ReviewStatus { get; set; }
        public DateTime? DateofApplicationSubmission { get; set; }
        public string PassportSeries { get; set; }
        public string PassportId { get; set; }
        public DateTime? PassportDate { get; set; }
        public string DepartmentCode { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<ListOfConsumersForTheApplication> ListOfConsumersForTheApplications { get; set; }
    }
}
