using System;
using System.Collections.Generic;

#nullable disable

namespace Project
{
    public partial class RequestCommissioningIndividualMeteringDevice
    {
        public int Id { get; set; }
        public DateTime? DateofApplicationSubmission { get; set; }
        public string FullName { get; set; }
        public int? IdPersonalAccount { get; set; }
        public string Service { get; set; }
        public DateTime? DateCommissioning { get; set; }            //Дата ввода в эксплуатацию
        public string FactoryNumber { get; set; }
        public string TypeDevice { get; set; }
        public string DeviceReadingsAtTheTimeOfAdmission { get; set; }
        public string InstallationLocation { get; set; }
        public string ReviewStatus { get; set; }
    }
}
