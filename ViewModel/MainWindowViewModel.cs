using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using Project.View;
using Project.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Linq;


namespace Project.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region HISTORY OF REquest
        private List<RequestCreatePersonalAccount> requestCreatePersonalAccounts = DataWorker.GetRequestCreatePersonalAccounts();
        public List<RequestCreatePersonalAccount> RequestCreatePersonalAccounts
        {
            get { return requestCreatePersonalAccounts; }
            set
            {
                requestCreatePersonalAccounts = value;
                OnPropertyChanged("RequestCreatePersonalAccounts");
            }
        }

        private List<ApplicationForChangingTheNumberOfConsumer> applicationForChangingTheNumberOfConsumers = DataWorker.GetApplicationForChangingTheNumberOfConsumers();
        public List<ApplicationForChangingTheNumberOfConsumer> ApplicationForChangingTheNumberOfConsumers
        {
            get { return applicationForChangingTheNumberOfConsumers; }
            set
            {
                applicationForChangingTheNumberOfConsumers = value;
                OnPropertyChanged("ApplicationForChangingTheNumberOfConsumers");
            }
        }

        private List<ListOfConsumersForTheApplication> listOfConsumersForTheApplications;
        public List<ListOfConsumersForTheApplication> ListOfConsumersForTheApplications
        {
            get { return listOfConsumersForTheApplications; }
            set
            {
                listOfConsumersForTheApplications = value;
                OnPropertyChanged("ListOfConsumersForTheApplications");
            }
        }

        private List<RequestChangeParametersPersonalAccount> requestChangeParametersPersonalAccounts = DataWorker.GetRequestChangeParametersPersonalAccounts();
        public List<RequestChangeParametersPersonalAccount> RequestChangeParametersPersonalAccounts
        {
            get { return requestChangeParametersPersonalAccounts; }
            set
            {
                requestChangeParametersPersonalAccounts = value;
                OnPropertyChanged("RequestChangeParametersPersonalAccounts");
            }
        }

        private List<RequestRecalculationFee> requestRecalculationFees = DataWorker.GetRequestRecalculationFees();
        public List<RequestRecalculationFee> RequestRecalculationFees
        {
            get { return requestRecalculationFees; }
            set
            {
                requestRecalculationFees = value;
                OnPropertyChanged("RequestRecalculationFees");
            }
        }

        private List<ListOfConsumersForTheRecalculationFee> listOfConsumersForTheRecalculationFees;
        public List<ListOfConsumersForTheRecalculationFee> ListOfConsumersForTheRecalculationFees
        {
            get { return listOfConsumersForTheRecalculationFees; }
            set
            {
                listOfConsumersForTheRecalculationFees = value;
                OnPropertyChanged("ListOfConsumersForTheRecalculationFees");
            }
        }

        private List<RequestCommissioningIndividualMeteringDevice> requestCommissioningIndividualMeteringDevices = DataWorker.GetRequestCommissioningIndividualMeteringDevices();
        public List<RequestCommissioningIndividualMeteringDevice> RequestCommissioningIndividualMeteringDevices
        {
            get { return requestCommissioningIndividualMeteringDevices; }
            set
            {
                requestCommissioningIndividualMeteringDevices = value;
                OnPropertyChanged("RequestCommissioningIndividualMeteringDevices");
            }
        }

        #endregion

        #region SELECTED ITEM
        public RequestCreatePersonalAccount SelectedRequestCreatePersonalAccount { get; set; }

        private ApplicationForChangingTheNumberOfConsumer selectedApplicationForChangingTheNumberOfConsumer;
        public ApplicationForChangingTheNumberOfConsumer SelectedApplicationForChangingTheNumberOfConsumer
        {
            get { return selectedApplicationForChangingTheNumberOfConsumer; }
            set
            {
                selectedApplicationForChangingTheNumberOfConsumer = value;
                if(selectedApplicationForChangingTheNumberOfConsumer != null)
                {
                    ListOfConsumersForTheApplications = DataWorker.GetListOfConsumersForTheApplications(selectedApplicationForChangingTheNumberOfConsumer);
                }
                //OnPropertyChanged("SelectedApplicationForChangingTheNumberOfConsumer");
            }
        }

        public ListOfConsumersForTheApplication SelectedListOfConsumersForTheApplication { get; set; }

        public RequestChangeParametersPersonalAccount SelectedRequestChangeParametersPersonalAccount { get; set; }

        private RequestRecalculationFee selectedRequestRecalculationFee;
        public RequestRecalculationFee SelectedRequestRecalculationFee
        {
            get { return selectedRequestRecalculationFee; }
            set
            {
                selectedRequestRecalculationFee = value;
                if(selectedRequestRecalculationFee != null)
                {
                    ListOfConsumersForTheRecalculationFees = DataWorker.GetListOfConsumersForTheRecalculationFees(selectedRequestRecalculationFee);
                }
                //OnPropertyChanged("SelectedApplicationForChangingTheNumberOfConsumer");
            }
        }

        public ListOfConsumersForTheRecalculationFee SelectedListOfConsumersForTheRecalculationFee { get; set; }

        public RequestCommissioningIndividualMeteringDevice SelectedRequestCommissioningIndividualMeteringDevice { get; set; }


        public MainWindowViewModel() { }

        public TabItem SelectedTabItem { get; set; }

        #endregion

        #region DELETE


        private RelayCommand deleteRequest;
        public RelayCommand DeleteRequest
        {
            get
            {
                return deleteRequest ??
                    (deleteRequest = new RelayCommand(obj =>
                    {
                        if (SelectedTabItem.Name == "RequestCreatePersonalAccountsTab" && SelectedRequestCreatePersonalAccount != null)
                        {
                            DataWorker.DeleteRequestCreatePersonalAccount(SelectedRequestCreatePersonalAccount);
                            RequestCreatePersonalAccounts = DataWorker.GetRequestCreatePersonalAccounts();
                        }
                        else if (SelectedTabItem.Name == "ApplicationForChangingTheNumberOfConsumersTab" && SelectedApplicationForChangingTheNumberOfConsumer != null)
                        {
                            DataWorker.DeleteApplicationForChangingTheNumberOfConsumer(SelectedApplicationForChangingTheNumberOfConsumer);
                            ApplicationForChangingTheNumberOfConsumers = DataWorker.GetApplicationForChangingTheNumberOfConsumers();
                        }
                        else if(SelectedTabItem.Name == "RequestChangeParametersPersonalAccountTab" && SelectedRequestChangeParametersPersonalAccount != null)
                        {
                            DataWorker.DeleteRequestChangeParametersPersonalAccount(SelectedRequestChangeParametersPersonalAccount);
                            RequestChangeParametersPersonalAccounts = DataWorker.GetRequestChangeParametersPersonalAccounts();
                        }
                        else if(SelectedTabItem.Name == "RequestRecalculationFeeTab" && SelectedRequestRecalculationFee != null)
                        {
                            DataWorker.DeleteRequestRecalculationFee(SelectedRequestRecalculationFee);
                            RequestRecalculationFees = DataWorker.GetRequestRecalculationFees();
                        }
                        else if(SelectedTabItem.Name == "RequestCommissioningIndividualMeteringDeviceTab" && SelectedRequestCommissioningIndividualMeteringDevice != null)
                        {
                            DataWorker.DeleteRequestCommissioningIndividualMeteringDevice(SelectedRequestCommissioningIndividualMeteringDevice);
                            RequestCommissioningIndividualMeteringDevices = DataWorker.GetRequestCommissioningIndividualMeteringDevices();
                        }
                    }));
            }
        }
        #endregion

        #region EDITRequestCreatePersonalAccount
        public DateTime PADateofApplicationSubmission { get; set; }
        public string PAAddressFacility { get; set; }
        public double? PALivingArea { get; set; }
        public double? PATotalArea { get; set; }
        public string PAShareSize { get; set; }
        public string PAFullName { get; set; }
        public string PAPassportSeries { get; set; }
        public string PAPassportId { get; set; }
        public DateTime PAPassportDate { get; set; }
        public string PADepartmentCode { get; set; }
        public string PATelephone { get; set; }

        private RelayCommand openWindowEditRequestCreatePersonalAccountCommand;
        public RelayCommand OpenWindowEditRequestCreatePersonalAccountCommand
        {
            get
            {
                return openWindowEditRequestCreatePersonalAccountCommand ??
                    (openWindowEditRequestCreatePersonalAccountCommand = new RelayCommand(obj =>
                    {
                        if (SelectedRequestCreatePersonalAccount.ReviewStatus == "Одобрена")
                        {
                            MessageBox.Show("Данная запись не доступна для редактирования");
                            return;
                        }

                        PADateofApplicationSubmission = (DateTime)SelectedRequestCreatePersonalAccount.DateofApplicationSubmission;
                        PAAddressFacility = SelectedRequestCreatePersonalAccount.AddressFacility;
                        PALivingArea = SelectedRequestCreatePersonalAccount.LivingArea;
                        PATotalArea = SelectedRequestCreatePersonalAccount.TotalArea;
                        PAShareSize = SelectedRequestCreatePersonalAccount.ShareSize;
                        PAFullName = SelectedRequestCreatePersonalAccount.FullName;
                        PAPassportSeries = SelectedRequestCreatePersonalAccount.PassportSeries;
                        PAPassportId = SelectedRequestCreatePersonalAccount.PassportId;
                        PAPassportDate = (DateTime)SelectedRequestCreatePersonalAccount.PassportDate;
                        PADepartmentCode = SelectedRequestCreatePersonalAccount.DepartmentCode;
                        PATelephone = SelectedRequestCreatePersonalAccount.Telephone;

                        var editRequestWindow = new EditRequestCreatePersonalAccount
                        {
                            DataContext = this
                        };
                        editRequestWindow.ShowDialog();
                    }));
            }
        }

        private RelayCommand editRequestCreatePersonalAccountCommand;
        public RelayCommand EditRequestCreatePersonalAccountCommand
        {
            get
            {
                return editRequestCreatePersonalAccountCommand ??
                    (editRequestCreatePersonalAccountCommand = new RelayCommand(obj =>
                    {
                        SelectedRequestCreatePersonalAccount.DateofApplicationSubmission = PADateofApplicationSubmission;
                        SelectedRequestCreatePersonalAccount.AddressFacility = PAAddressFacility;
                        SelectedRequestCreatePersonalAccount.LivingArea = PALivingArea;
                        SelectedRequestCreatePersonalAccount.TotalArea = PATotalArea;
                        SelectedRequestCreatePersonalAccount.ShareSize = PAShareSize;
                        SelectedRequestCreatePersonalAccount.FullName = PAFullName;
                        SelectedRequestCreatePersonalAccount.PassportSeries = PAPassportSeries;
                        SelectedRequestCreatePersonalAccount.PassportId = PAPassportId;
                        SelectedRequestCreatePersonalAccount.PassportDate = PAPassportDate;
                        SelectedRequestCreatePersonalAccount.DepartmentCode = PADepartmentCode;
                        SelectedRequestCreatePersonalAccount.Telephone = PATelephone;
                        DataWorker.EditRequestCreatePersonalAccount(SelectedRequestCreatePersonalAccount);
                        RequestCreatePersonalAccounts = DataWorker.GetRequestCreatePersonalAccounts();
                    }));
            }
        }

        #endregion

        #region EDITApplicationForChangingTheNumberOfConsumer

        public DateTime NCDateofApplicationSubmission { get; set; }
        public string NCAddressFacility { get; set; }
        public string NCFullNameApplicant { get; set; }
        public string NCPassportSeries { get; set; }
        public string NCPassportId { get; set; }
        public DateTime NCPassportDate { get; set; }
        public string NCDepartmentCode { get; set; }
        public string NCTelephone { get; set; }


        private RelayCommand deleteSelectedListOfConsumersForTheApplication;
        public RelayCommand DeleteSelectedListOfConsumersForTheApplication
        {
            get
            {
                return deleteSelectedListOfConsumersForTheApplication ??
                    (deleteSelectedListOfConsumersForTheApplication = new RelayCommand(obj =>
                    {
                        ListOfConsumersForTheApplications.Remove(SelectedListOfConsumersForTheApplication);
                    }));
            }
        }

        private RelayCommand openWindowEditApplicationForChangingTheNumberOfConsumer;
        public RelayCommand OpenWindowEditApplicationForChangingTheNumberOfConsumer
        {
            get
            {
                return openWindowEditApplicationForChangingTheNumberOfConsumer ??
                    (openWindowEditApplicationForChangingTheNumberOfConsumer = new RelayCommand(obj =>
                    {
                        if (SelectedApplicationForChangingTheNumberOfConsumer.ReviewStatus == "Одобрена")
                        {
                            MessageBox.Show("Данная запись не доступна для редактирования");
                            return;
                        }

                        NCDateofApplicationSubmission = (DateTime)SelectedApplicationForChangingTheNumberOfConsumer.DateofApplicationSubmission;
                        NCAddressFacility = SelectedApplicationForChangingTheNumberOfConsumer.AddressFacility;
                        NCFullNameApplicant = SelectedApplicationForChangingTheNumberOfConsumer.FullNameApplicant;
                        NCPassportSeries = SelectedApplicationForChangingTheNumberOfConsumer.PassportSeries;
                        NCPassportId = SelectedApplicationForChangingTheNumberOfConsumer.PassportId;
                        NCPassportDate = (DateTime)SelectedApplicationForChangingTheNumberOfConsumer.PassportDate;
                        NCDepartmentCode = SelectedApplicationForChangingTheNumberOfConsumer.DepartmentCode;
                        NCTelephone = SelectedApplicationForChangingTheNumberOfConsumer.Telephone;

                        //EditListOfConsumers = DataWorker.GetListOfConsumersForTheApplications(selectedApplicationForChangingTheNumberOfConsumer);

                        EditApplicationForChangingTheNumberOfConsumer window = new EditApplicationForChangingTheNumberOfConsumer
                        {
                            DataContext = this
                        };
                        window.ShowDialog();
                    }));
            }
        }

        private RelayCommand editApplicationForChangingTheNumberOfConsumer;
        public RelayCommand EditApplicationForChangingTheNumberOfConsumer
        {
            get
            {
                return editApplicationForChangingTheNumberOfConsumer ??
                    (editApplicationForChangingTheNumberOfConsumer = new RelayCommand(obj =>
                    {
                        SelectedApplicationForChangingTheNumberOfConsumer.DateofApplicationSubmission = NCDateofApplicationSubmission;
                        SelectedApplicationForChangingTheNumberOfConsumer.AddressFacility = NCAddressFacility;
                        SelectedApplicationForChangingTheNumberOfConsumer.FullNameApplicant = NCFullNameApplicant;
                        SelectedApplicationForChangingTheNumberOfConsumer.PassportSeries = NCPassportSeries;
                        SelectedApplicationForChangingTheNumberOfConsumer.PassportId = NCPassportId;
                        SelectedApplicationForChangingTheNumberOfConsumer.PassportDate = NCPassportDate;
                        SelectedApplicationForChangingTheNumberOfConsumer.DepartmentCode = NCDepartmentCode;
                        SelectedApplicationForChangingTheNumberOfConsumer.Telephone = NCTelephone;

                        DataWorker.EditApplicationForChangingTheNumberOfConsumer(selectedApplicationForChangingTheNumberOfConsumer, ListOfConsumersForTheApplications);
                        ApplicationForChangingTheNumberOfConsumers = DataWorker.GetApplicationForChangingTheNumberOfConsumers();
                    }));
            }
        }

        #endregion

        #region EDITRequestChangeParametersPersonalAccount
        public int? CPIdPersonalAccount { get; set; }
        public string CPAddressFacility { get; set; }
        public double? CPTotalArea { get; set; }
        public string CPFullName { get; set; }
        public string CPShareSize { get; set; }
        public DateTime? CPDateofApplicationSubmission { get; set; }
        public string CPPassportSeries { get; set; }
        public string CPPassportId { get; set; }
        public DateTime? CPPassportDate { get; set; }
        public string CPDepartmentCode { get; set; }
        public string CPTelephone { get; set; }

        private RelayCommand openWindowEditRequestChangeParametersPersonalAccount;
        public RelayCommand OpenWindowEditRequestChangeParametersPersonalAccount
        {    
            get
            {
                return openWindowEditRequestChangeParametersPersonalAccount ??
                    (openWindowEditRequestChangeParametersPersonalAccount = new RelayCommand(obj =>
                    {
                        if (SelectedRequestChangeParametersPersonalAccount.ReviewStatus == "Одобрена")
                        {
                            MessageBox.Show("Данная запись не доступна для редактирования");
                            return;
                        }

                        CPIdPersonalAccount = SelectedRequestChangeParametersPersonalAccount.IdPersonalAccount;
                        CPAddressFacility = SelectedRequestChangeParametersPersonalAccount.AddressFacility;
                        CPTotalArea = SelectedRequestChangeParametersPersonalAccount.TotalArea;
                        CPFullName = SelectedRequestChangeParametersPersonalAccount.FullName;
                        CPShareSize = SelectedRequestChangeParametersPersonalAccount.ShareSize;
                        CPDateofApplicationSubmission = SelectedRequestChangeParametersPersonalAccount.DateofApplicationSubmission;
                        CPPassportSeries = SelectedRequestChangeParametersPersonalAccount.PassportSeries;
                        CPPassportId = SelectedRequestChangeParametersPersonalAccount.PassportId;
                        CPPassportDate = SelectedRequestChangeParametersPersonalAccount.PassportDate;
                        CPDepartmentCode = SelectedRequestChangeParametersPersonalAccount.DepartmentCode;
                        CPTelephone = SelectedRequestChangeParametersPersonalAccount.Telephone;

                        var editWindow = new EditRequestChangeParametersPersonalAccount() { DataContext = this};
                        editWindow.ShowDialog();
                    }));
            }
        }

        private RelayCommand editRequestChangeParametersPersonalAccount;
        public RelayCommand EditRequestChangeParametersPersonalAccount
        {
            get
            {
                return editRequestChangeParametersPersonalAccount ??
                    (editRequestChangeParametersPersonalAccount = new RelayCommand(obj =>
                    {
                        SelectedRequestChangeParametersPersonalAccount.IdPersonalAccount = CPIdPersonalAccount;
                        SelectedRequestChangeParametersPersonalAccount.AddressFacility = CPAddressFacility;
                        SelectedRequestChangeParametersPersonalAccount.TotalArea = CPTotalArea;
                        SelectedRequestChangeParametersPersonalAccount.FullName = CPFullName;
                        SelectedRequestChangeParametersPersonalAccount.ShareSize = CPShareSize;
                        SelectedRequestChangeParametersPersonalAccount.DateofApplicationSubmission = CPDateofApplicationSubmission;
                        SelectedRequestChangeParametersPersonalAccount.PassportSeries = CPPassportSeries;
                        SelectedRequestChangeParametersPersonalAccount.PassportId = CPPassportId;
                        SelectedRequestChangeParametersPersonalAccount.PassportDate = CPPassportDate;
                        SelectedRequestChangeParametersPersonalAccount.DepartmentCode = CPDepartmentCode;
                        SelectedRequestChangeParametersPersonalAccount.Telephone = CPTelephone;

                        DataWorker.EditRequestChangeParametersPersonalAccount(SelectedRequestChangeParametersPersonalAccount);
                        RequestChangeParametersPersonalAccounts = DataWorker.GetRequestChangeParametersPersonalAccounts();
                    }));
            }
        }

        #endregion

        #region EDITRequestRecalculationFee
        public int? RFIdPersonalAccount { get; set; }
        public string RFFullName { get; set; }
        public DateTime? RFDateofApplicationSubmission { get; set; }
        public string RFPassportSeries { get; set; }
        public string RFPassportId { get; set; }
        public DateTime? RFPassportDate { get; set; }
        public string RFDepartmentCode { get; set; }
        public string RFTelephone { get; set; }

        private RelayCommand deleteSelectedListOfConsumersForTheRecalculationFee;
        public RelayCommand DeleteSelectedListOfConsumersForTheRecalculationFee
        {
            get
            {
                return deleteSelectedListOfConsumersForTheRecalculationFee ??
                    (deleteSelectedListOfConsumersForTheRecalculationFee = new RelayCommand(obj =>
                    {
                        ListOfConsumersForTheRecalculationFees.Remove(SelectedListOfConsumersForTheRecalculationFee);
                    }));
            }
        }

        private RelayCommand openWindowEditRequestRecalculationFee;
        public RelayCommand OpenWindowEditRequestRecalculationFee
        {
            get
            {
                return openWindowEditRequestRecalculationFee ??
                    (openWindowEditRequestRecalculationFee = new RelayCommand(obj =>
                    {
                        if (SelectedRequestRecalculationFee.ReviewStatus == "Одобрена")
                        {
                            MessageBox.Show("Данная запись не доступна для редактирования");
                            return;
                        }

                        RFIdPersonalAccount = SelectedRequestRecalculationFee.IdPersonalAccount;
                        RFFullName = SelectedRequestRecalculationFee.FullName;
                        RFDateofApplicationSubmission = SelectedRequestRecalculationFee.DateofApplicationSubmission;
                        RFPassportSeries = SelectedRequestRecalculationFee.PassportSeries;
                        RFPassportId = SelectedRequestRecalculationFee.PassportId;
                        RFPassportDate = SelectedRequestRecalculationFee.PassportDate;
                        RFDepartmentCode = SelectedRequestRecalculationFee.DepartmentCode;
                        RFTelephone = SelectedRequestRecalculationFee.Telephone;

                        var window = new EditRequestRecalculationFee() { DataContext = this};
                        window.ShowDialog();
                    }));
            }
        }

        private RelayCommand editRequestRecalculationFee;
        public RelayCommand EditRequestRecalculationFee
        {
            get
            {
                return editRequestRecalculationFee ??
                    (editRequestRecalculationFee = new RelayCommand(obj =>
                    {
                        SelectedRequestRecalculationFee.IdPersonalAccount = RFIdPersonalAccount;
                        SelectedRequestRecalculationFee.FullName = RFFullName;
                        SelectedRequestRecalculationFee.DateofApplicationSubmission = RFDateofApplicationSubmission;
                        SelectedRequestRecalculationFee.PassportSeries = RFPassportSeries;
                        SelectedRequestRecalculationFee.PassportId = RFPassportId;
                        SelectedRequestRecalculationFee.PassportDate = RFPassportDate;
                        SelectedRequestRecalculationFee.DepartmentCode = RFDepartmentCode;
                        SelectedRequestRecalculationFee.Telephone = RFTelephone;

                        DataWorker.EditRequestRecalculationFee(SelectedRequestRecalculationFee, ListOfConsumersForTheRecalculationFees);
                        RequestRecalculationFees = DataWorker.GetRequestRecalculationFees();
                    }));
            }
        }

        #endregion

        #region EDITRequestCommissioningIndividualMeteringDevice
        public string MDFullName { get; set; }
        public int? MDIdPersonalAccount { get; set; }
        public string MDService { get; set; }
        public DateTime? MDDateCommissioning { get; set; }            //Дата ввода в эксплуатацию
        public string MDFactoryNumber { get; set; }
        public string MDTypeDevice { get; set; }
        public string MDDeviceReadingsAtTheTimeOfAdmission { get; set; }
        public string MDInstallationLocation { get; set; }

        private RelayCommand openWindowEditRequestCommissioningIndividualMeteringDevice;
        public RelayCommand OpenWindowEditRequestCommissioningIndividualMeteringDevice
        {
            get
            {
                return openWindowEditRequestCommissioningIndividualMeteringDevice ??
                    (openWindowEditRequestCommissioningIndividualMeteringDevice = new RelayCommand(obj =>
                    {
                        if (SelectedRequestCommissioningIndividualMeteringDevice.ReviewStatus == "Одобрена")
                        {
                            MessageBox.Show("Данная запись не доступна для редактирования");
                            return;
                        }

                        MDFullName = SelectedRequestCommissioningIndividualMeteringDevice.FullName;
                        MDIdPersonalAccount = SelectedRequestCommissioningIndividualMeteringDevice.IdPersonalAccount;
                        MDService = SelectedRequestCommissioningIndividualMeteringDevice.Service;
                        MDDateCommissioning = SelectedRequestCommissioningIndividualMeteringDevice.DateCommissioning;
                        MDFactoryNumber = SelectedRequestCommissioningIndividualMeteringDevice.FactoryNumber;
                        MDTypeDevice = SelectedRequestCommissioningIndividualMeteringDevice.TypeDevice;
                        MDDeviceReadingsAtTheTimeOfAdmission = SelectedRequestCommissioningIndividualMeteringDevice.DeviceReadingsAtTheTimeOfAdmission;
                        MDInstallationLocation = SelectedRequestCommissioningIndividualMeteringDevice.InstallationLocation;

                        var window = new EditRequestCommissioningIndividualMeteringDevice() { DataContext = this };
                        window.ShowDialog();
                    }));
            }
        }

        private RelayCommand editRequestCommissioningIndividualMeteringDevice;
        public RelayCommand EditRequestCommissioningIndividualMeteringDevice
        {
            get
            {
                return editRequestCommissioningIndividualMeteringDevice ??
                    (editRequestCommissioningIndividualMeteringDevice = new RelayCommand(obj =>
                    {
                        SelectedRequestCommissioningIndividualMeteringDevice.FullName = MDFullName;
                        SelectedRequestCommissioningIndividualMeteringDevice.IdPersonalAccount = MDIdPersonalAccount;
                        SelectedRequestCommissioningIndividualMeteringDevice.Service = MDService;
                        SelectedRequestCommissioningIndividualMeteringDevice.DateCommissioning = MDDateCommissioning;
                        SelectedRequestCommissioningIndividualMeteringDevice.FactoryNumber = MDFactoryNumber;
                        SelectedRequestCommissioningIndividualMeteringDevice.TypeDevice = MDTypeDevice;
                        SelectedRequestCommissioningIndividualMeteringDevice.DeviceReadingsAtTheTimeOfAdmission = MDDeviceReadingsAtTheTimeOfAdmission;
                        SelectedRequestCommissioningIndividualMeteringDevice.InstallationLocation = MDInstallationLocation;

                        DataWorker.EditRequestCommissioningIndividualMeteringDevice(SelectedRequestCommissioningIndividualMeteringDevice);
                        RequestCommissioningIndividualMeteringDevices = DataWorker.GetRequestCommissioningIndividualMeteringDevices();
                    }));
            }
        }

        #endregion

        #region CHANGINGReviewStatus

        private RelayCommand openChangingReviewStatus;
        public RelayCommand OpenChangingReviewStatus
        {
            get
            {
                return openChangingReviewStatus ??
                    (openChangingReviewStatus = new RelayCommand(obj =>
                    {
                        if ((SelectedTabItem.Name == "RequestCreatePersonalAccountsTab" && SelectedRequestCreatePersonalAccount.ReviewStatus == "Одобрена") ||
                        (SelectedTabItem.Name == "ApplicationForChangingTheNumberOfConsumersTab" && SelectedApplicationForChangingTheNumberOfConsumer.ReviewStatus == "Одобрена") ||
                        (SelectedTabItem.Name == "RequestChangeParametersPersonalAccountTab" && SelectedRequestChangeParametersPersonalAccount.ReviewStatus == "Одобрена") ||
                        (SelectedTabItem.Name == "RequestRecalculationFeeTab" && SelectedRequestRecalculationFee.ReviewStatus == "Одобрена") ||
                        (SelectedTabItem.Name == "RequestCommissioningIndividualMeteringDeviceTab" && SelectedRequestCommissioningIndividualMeteringDevice.ReviewStatus == "Одобрена"))
                        {
                            MessageBox.Show("Данная запись не доступна для изменения статуса рассмотрения");
                            return;
                        }


                        ChangingReviewStatus window = new ChangingReviewStatus();
                        window.DataContext = this;
                        window.ShowDialog();
                    }));
            }
        }

        public bool Approve { get; set; }
        public bool Reject { get; set; }

        private RelayCommand changingReviewStatus;
        public RelayCommand ChangingReviewStatus
        {
            get
            {
                return changingReviewStatus ??
                    (changingReviewStatus = new RelayCommand(obj => 
                    {
                        if(SelectedTabItem.Name == "RequestCreatePersonalAccountsTab" && SelectedRequestCreatePersonalAccount != null)
                        {
                            DataWorker.ChangingReviewStatusRequestCreatePersonalAccount(SelectedRequestCreatePersonalAccount, Approve);
                            RequestCreatePersonalAccounts = DataWorker.GetRequestCreatePersonalAccounts();
                        }
                        if(SelectedTabItem.Name == "ApplicationForChangingTheNumberOfConsumersTab" && SelectedApplicationForChangingTheNumberOfConsumer != null)
                        {
                            DataWorker.ChangingReviewStatusApplicationForChangingTheNumberOfConsumer(SelectedApplicationForChangingTheNumberOfConsumer, Approve);
                            ApplicationForChangingTheNumberOfConsumers = DataWorker.GetApplicationForChangingTheNumberOfConsumers();
                        }
                        if(SelectedTabItem.Name == "RequestChangeParametersPersonalAccountTab" && SelectedRequestChangeParametersPersonalAccount != null)
                        {
                            DataWorker.ChangingReviewStatusRequestChangeParametersPersonalAccount(SelectedRequestChangeParametersPersonalAccount, Approve);
                            RequestChangeParametersPersonalAccounts = DataWorker.GetRequestChangeParametersPersonalAccounts();
                        }
                        if(SelectedTabItem.Name == "RequestRecalculationFeeTab" && SelectedRequestRecalculationFee != null)
                        {
                            DataWorker.ChangingReviewStatusRequestRecalculationFee(SelectedRequestRecalculationFee, Approve);
                            RequestRecalculationFees = DataWorker.GetRequestRecalculationFees();
                        }
                        if(SelectedTabItem.Name == "RequestCommissioningIndividualMeteringDeviceTab" && SelectedRequestCommissioningIndividualMeteringDevice != null)
                        {
                            DataWorker.ChangingReviewStatusRequestCommissioningIndividualMeteringDevice(SelectedRequestCommissioningIndividualMeteringDevice, Approve);
                            RequestCommissioningIndividualMeteringDevices = DataWorker.GetRequestCommissioningIndividualMeteringDevices();
                        }
                        
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
