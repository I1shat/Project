using System;
using System.Windows.Controls;

namespace Project.ViewModel
{
    public class UserControlListOfConsumersForTheApplicationViewModel
    {
        public ListOfConsumersForTheApplication GetConsumer()
        {
            return new ListOfConsumersForTheApplication() {FullName = LCAFullName, Status = LCAStatus.Text, StartDate = LCAStartDate, EndDate = LCAEndDate, IdApplicationForChangingTheNumberOfConsumers = LCAIdApplicationForChangingTheNumberOfConsumers };
        }

        public string LCAFullName { get; set; }
        public TextBlock LCAStatus { get; set; }
        public DateTime LCAStartDate { get; set; }
        public DateTime? LCAEndDate { get; set; }
        public int LCAIdApplicationForChangingTheNumberOfConsumers { get; set; }
    }
}
