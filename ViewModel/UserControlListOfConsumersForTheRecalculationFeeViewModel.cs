using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ViewModel
{
    public class UserControlListOfConsumersForTheRecalculationFeeViewModel
    {
        public ListOfConsumersForTheRecalculationFee GetConsumer()
        {
            return new ListOfConsumersForTheRecalculationFee() { FullName = LCRFullName, StartDate = LCRStartDate, EndDate = LCREndDate, IdRequestRecalculationFee = LCRIdApplicationForChangingTheNumberOfConsumers };
        }

        public string LCRFullName { get; set; }
        public DateTime LCRStartDate { get; set; }
        public DateTime? LCREndDate { get; set; }
        public int LCRIdApplicationForChangingTheNumberOfConsumers { get; set; }
    }
}
