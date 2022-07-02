using System;
using System.Collections.Generic;
using System.Text;
using Project.View;
using Project.Model;

namespace Project.ViewModel
{
    class MenuViewModel
    {
        private RelayCommand openMainWindowCommand;
        public RelayCommand OpenMainWindowCommand
        {
            get
            {
                return openMainWindowCommand ??
                    (openMainWindowCommand = new RelayCommand(obj =>
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                    }));
            }
        }

        private RelayCommand openAddRequestWindowCommand;
        public RelayCommand OpenAddRequestWindowCommand
        {
            get
            {
                return openAddRequestWindowCommand ??
                    (openAddRequestWindowCommand = new RelayCommand(obj =>
                    {
                        AddRequestWindow addRequestWindow = new AddRequestWindow();
                        addRequestWindow.ShowDialog();
                    }));
            }
        }

        private RelayCommand openAddApplicationForChangingTheNumberOfConsumersCommand;
        public RelayCommand OpenAddApplicationForChangingTheNumberOfConsumersCommand
        {
            get
            {
                return openAddApplicationForChangingTheNumberOfConsumersCommand ??
                    (openAddApplicationForChangingTheNumberOfConsumersCommand = new RelayCommand(obj =>
                    {
                        AddApplicationForChangingTheNumberOfConsumers window = new AddApplicationForChangingTheNumberOfConsumers();
                        window.ShowDialog();
                    }));
            }
        }

        private RelayCommand openAddRequestChangeParametersPersonalAccount;
        public RelayCommand OpenAddRequestChangeParametersPersonalAccount
        {
            get
            {
                return openAddRequestChangeParametersPersonalAccount ??
                    (openAddRequestChangeParametersPersonalAccount = new RelayCommand(obj =>
                    {
                        AddRequestChangeParametersPersonalAccount window = new AddRequestChangeParametersPersonalAccount();
                        window.ShowDialog();
                    }));
            }
        }

        private RelayCommand openAddRequestRecalculationFee;
        public RelayCommand OpenAddRequestRecalculationFee
        {
            get
            {
                return openAddRequestRecalculationFee ??
                    (openAddRequestRecalculationFee = new RelayCommand(obj =>
                    {
                        AddRequestRecalculationFee window = new AddRequestRecalculationFee();
                        window.ShowDialog();
                    }));
            }
        }

        private RelayCommand openAddRequestCommissioningIndividualMeteringDevice;
        public RelayCommand OpenAddRequestCommissioningIndividualMeteringDevice
        {
            get
            {
                return openAddRequestCommissioningIndividualMeteringDevice ??
                    (openAddRequestCommissioningIndividualMeteringDevice = new RelayCommand(obj =>
                    {
                        AddRequestCommissioningIndividualMeteringDevice window = new AddRequestCommissioningIndividualMeteringDevice();
                        window.ShowDialog();
                    }));
            }
        }

        private RelayCommand openWindowPersonalAccountStatement;
        public RelayCommand OpenWindowPersonalAccountStatement
        {
            get
            {
                return openWindowPersonalAccountStatement ??
                    (openWindowPersonalAccountStatement = new RelayCommand(obj =>
                    {
                        PersonalAccountStatementWindow window = new PersonalAccountStatementWindow();
                        window.ShowDialog();
                    }));
            }
        }

        private RelayCommand openReportWindow;
        public RelayCommand OpenReportWindow
        {
            get
            {
                return openReportWindow ??
                    (openReportWindow = new RelayCommand(obj =>
                    {
                        ReportWindow window = new ReportWindow();
                        window.ShowDialog();
                    }));
            }
        }
    }
}
//OpenReportWindow