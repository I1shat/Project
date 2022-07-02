using System;
using System.Collections.Generic;

#nullable disable

namespace Project
{
    public partial class Subscriber
    {
        public Subscriber()
        {
            PersonalAccounts = new HashSet<PersonalAccount>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? Dob { get; set; }
        public string PassportSeries { get; set; }
        public string PassportId { get; set; }
        public DateTime? PassportDate { get; set; }
        public string DepartmentCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<PersonalAccount> PersonalAccounts { get; set; }
    }
}
