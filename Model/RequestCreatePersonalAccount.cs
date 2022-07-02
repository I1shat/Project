using System;
using System.Collections.Generic;

#nullable disable

namespace Project
{
    public partial class RequestCreatePersonalAccount
    {
        public int Id { get; set; }
        public DateTime? DateofApplicationSubmission { get; set; }
        public string AddressFacility { get; set; }
        public double? LivingArea { get; set; }
        public double? TotalArea { get; set; }
        public string ShareSize { get; set; }
        public string FullName { get; set; }
        public string PassportSeries { get; set; }
        public string PassportId { get; set; }
        public DateTime? PassportDate { get; set; }
        public string DepartmentCode { get; set; }
        public string Telephone { get; set; }
        public string ReviewStatus { get; set; }
    }
}
