using System;
using System.Collections.Generic;
using Project.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Project.ViewModel
{
    public class AddRequestWindowViewModel : INotifyPropertyChanged
    {
        #region ADDRequestCreatePersonalAccount
        public string PAAddressFacility { get; set; }
        public double? PALivingArea { get; set; }
        public double? PATotalArea { get; set; }
        public string PAShareSize { get; set; }
        public string PAFullName { get; set; }
        public string PAPassportSeries { get; set; } //4
        public string PAPassportId { get; set; }    //6
        public DateTime PAPassportDate { get; set; }
        public string PADepartmentCode { get; set; }    //###-###
        public string PATelephone { get; set; }

        private RelayCommand addRequestCreatePersonalAccountCommand;

        public RelayCommand AddRequestCreatePersonalAccountCommand
        {
            get
            {
                return addRequestCreatePersonalAccountCommand ??
                    (addRequestCreatePersonalAccountCommand = new RelayCommand(obj =>
                    {
                        RequestCreatePersonalAccount request = new RequestCreatePersonalAccount() { DateofApplicationSubmission = DateTime.Today, ReviewStatus = "На рассмотрении",
                                                                                                    LivingArea = PALivingArea, TotalArea = PATotalArea, ShareSize = PAShareSize,
                                                                                                    AddressFacility = PAAddressFacility, FullName = PAFullName,
                                                                                                    PassportSeries = PAPassportSeries, PassportId = PAPassportId, PassportDate = PAPassportDate,
                                                                                                    DepartmentCode = PADepartmentCode, Telephone = PATelephone
                        };
                        DataWorker.AddRequestCreatePersonalAccount(request);
                    }));
            }
        }
        #endregion

        #region ADDApplicationForChangingTheNumberOfConsumer

        public string NCAddressFacility { get; set; }
        public string NCFullNameApplicant { get; set; }
        public string NCPassportSeries { get; set; }
        public string NCPassportId { get; set; }
        public DateTime NCPassportDate { get; set; }
        public string NCDepartmentCode { get; set; }
        public string NCTelephone { get; set; }

        public List<ListOfConsumersForTheApplication> ListOfConsumers { get; set; }

        private RelayCommand addConsumer;
        public RelayCommand AddConsumer
        {
            get
            {
                return addConsumer ?? 
                    (addConsumer = new RelayCommand(obj =>
                    {
                        DataWorker.AddApplicationForChangingTheNumberOfConsumer(new ApplicationForChangingTheNumberOfConsumer() { AddressFacility = NCAddressFacility, FullNameApplicant = NCFullNameApplicant, ReviewStatus = "На рассмотрении",
                                                                                                                                   DateofApplicationSubmission = DateTime.Today, PassportSeries = NCPassportSeries, PassportId = NCPassportId,
                                                                                                                                   PassportDate = NCPassportDate, DepartmentCode = NCDepartmentCode,Telephone = NCTelephone                   
                        }, ListOfConsumers );                      
                    }));
            }
        }
        #endregion

        #region ADDRequestChangeParametersPersonalAccount

        public int? CPIdPersonalAccount { get; set; }
        public string CPAddressFacility { get; set; }
        public double? CPTotalArea { get; set; }
        public string CPFullName { get; set; }
        public string CPShareSize { get; set; }
        public string CPPassportSeries { get; set; }
        public string CPPassportId { get; set; }
        public DateTime? CPPassportDate { get; set; }
        public string CPDepartmentCode { get; set; }
        public string CPTelephone { get; set; }

        private RelayCommand addRequestChangeParametersPersonalAccount;
        public RelayCommand AddRequestChangeParametersPersonalAccount
        {
            get
            {
                return addRequestChangeParametersPersonalAccount ??
                    (addRequestChangeParametersPersonalAccount = new RelayCommand(obj => 
                    { 
                        /*RequestChangeParametersPersonalAccount request = new RequestChangeParametersPersonalAccount(){ IdPersonalAccount = CPIdPersonalAccount, AddressFacility = CPAddressFacility, ReviewStatus = "На рассмотрении",
                        TotalArea = CPTotalArea, FullName = CPFullName, ShareSize = CPShareSize, DateofApplicationSubmission = CPDateofApplicationSubmission,
                        PassportSeries = CPPassportSeries, PassportId = CPPassportId, PassportDate = CPPassportDate, DepartmentCode = CPDepartmentCode, Telephone = CPTelephone};*/

                        DataWorker.AddRequestChangeParametersPersonalAccounts(new RequestChangeParametersPersonalAccount(){ IdPersonalAccount = CPIdPersonalAccount, AddressFacility = CPAddressFacility, ReviewStatus = "На рассмотрении",
                        TotalArea = CPTotalArea, FullName = CPFullName, ShareSize = CPShareSize, DateofApplicationSubmission = DateTime.Today,
                        PassportSeries = CPPassportSeries, PassportId = CPPassportId, PassportDate = CPPassportDate, DepartmentCode = CPDepartmentCode, Telephone = CPTelephone});
                    }));
            }
        }

        #endregion

        #region ADDRequestRecalculationFee

        public int? RFIdPersonalAccount { get; set; }
        public string RFFullName { get; set; }
        public string RFPassportSeries { get; set; }
        public string RFPassportId { get; set; }
        public DateTime? RFPassportDate { get; set; }
        public string RFDepartmentCode { get; set; }
        public string RFTelephone { get; set; }

        public List<ListOfConsumersForTheRecalculationFee> ListListOfConsumersForTheRecalculationFee { get; set; }

        private RelayCommand addRequestRecalculationFee;
        public RelayCommand AddRequestRecalculationFee
        {
            get
            {
                return addRequestRecalculationFee ??
                    (addRequestRecalculationFee = new RelayCommand(obj=>
                    { 
                        DataWorker.AddRequestRecalculationFee(new RequestRecalculationFee() { IdPersonalAccount = RFIdPersonalAccount, FullName = RFFullName, DateofApplicationSubmission = DateTime.Today,
                                                                                            PassportSeries = RFPassportSeries, PassportId = RFPassportId, PassportDate = RFPassportDate, DepartmentCode = RFDepartmentCode, Telephone = RFTelephone, ReviewStatus = "На рассмотрении"}, ListListOfConsumersForTheRecalculationFee
                        );
                    }));
            }
        }

        #endregion

        #region ADDRequestCommissioningIndividualMeteringDevice

        public string MDFullName { get; set; }
        public int? MDIdPersonalAccount { get; set; }
        public string MDService { get; set; }
        public DateTime? MDDateCommissioning { get; set; }            //Дата ввода в эксплуатацию
        public string MDFactoryNumber { get; set; }
        public string MDTypeDevice { get; set; }
        public string MDDeviceReadingsAtTheTimeOfAdmission { get; set; }
        public string MDInstallationLocation { get; set; }

        private RelayCommand addRequestCommissioningIndividualMeteringDevice;
        public RelayCommand AddRequestCommissioningIndividualMeteringDevice
        {
            get
            {
                return addRequestCommissioningIndividualMeteringDevice ??
                    (addRequestCommissioningIndividualMeteringDevice = new RelayCommand(obj =>
                    {
                        DataWorker.AddRequestCommissioningIndividualMeteringDevice(new RequestCommissioningIndividualMeteringDevice() { ReviewStatus = "На рассмотрении", FullName = MDFullName, IdPersonalAccount = MDIdPersonalAccount, DateofApplicationSubmission = DateTime.Today,
                        Service = MDService, DateCommissioning = MDDateCommissioning, FactoryNumber = MDFactoryNumber, TypeDevice = MDTypeDevice, DeviceReadingsAtTheTimeOfAdmission = MDDeviceReadingsAtTheTimeOfAdmission, InstallationLocation = MDInstallationLocation
                        });
                    }));
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
