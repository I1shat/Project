using System;

#nullable disable

namespace Project
{
    public partial class ListOfConsumersForTheApplication
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? IdApplicationForChangingTheNumberOfConsumers { get; set; }

        public virtual ApplicationForChangingTheNumberOfConsumer IdApplicationForChangingTheNumberOfConsumersNavigation { get; set; }
    }
}
