using System;
using System.Collections.Generic;
using System.Text;
using Project.Model;
using Word = Microsoft.Office.Interop.Word;
using System.Linq;

namespace Project.ViewModel
{
    public enum RequestEnum
    {
        RequestCreatePersonalAccount,
        ApplicationForChangingTheNumberOfConsumer,
        RequestChangeParametersPersonalAccount,
        RequestRecalculationFee,
        RequestCommissioningIndividualMeteringDevice
    }
    public class ReportWindowViewModel
    {
        #region RADIOBUTTON
        RequestEnum requestEnum = RequestEnum.RequestCreatePersonalAccount;
        public RequestEnum RequestEnum
        {
            get { return requestEnum; }
            set
            {
                if (requestEnum == value) return;
                requestEnum = value;
            }
        }

        public bool IsRequestCreatePersonalAccount
        {
            get { return RequestEnum == RequestEnum.RequestCreatePersonalAccount; }
            set { RequestEnum = value ? RequestEnum.RequestCreatePersonalAccount : RequestEnum; }
        }

        public bool IsApplicationForChangingTheNumberOfConsumer
        {
            get { return RequestEnum == RequestEnum.ApplicationForChangingTheNumberOfConsumer; }
            set { RequestEnum = value ? RequestEnum.ApplicationForChangingTheNumberOfConsumer : RequestEnum; }
        }

        public bool IsRequestChangeParametersPersonalAccount
        {
            get { return RequestEnum == RequestEnum.RequestChangeParametersPersonalAccount; }
            set { RequestEnum = value ? RequestEnum.RequestChangeParametersPersonalAccount : RequestEnum; }
        }
        public bool IsRequestRecalculationFee
        {
            get { return RequestEnum == RequestEnum.RequestRecalculationFee; }
            set { RequestEnum = value ? RequestEnum.RequestRecalculationFee : RequestEnum; }
        }
        public bool IsRequestCommissioningIndividualMeteringDevice
        {
            get { return RequestEnum == RequestEnum.RequestCommissioningIndividualMeteringDevice; }
            set { RequestEnum = value ? RequestEnum.RequestCommissioningIndividualMeteringDevice : RequestEnum; }
        }
        #endregion

        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today;

        private void createReportRequest()
        {
            List<RequestCreatePersonalAccount> ListRequestCreatePersonalAccounts;
            List<ApplicationForChangingTheNumberOfConsumer> ListApplicationForChangingTheNumberOfConsumer;
            List<ListOfConsumersForTheApplication> ListOfConsumersForTheApplications;
            List<RequestChangeParametersPersonalAccount> ListRequestChangeParametersPersonalAccount;
            List<RequestRecalculationFee> ListRequestRecalculationFee;
            List<ListOfConsumersForTheRecalculationFee> ListOfConsumersForTheRecalculationFees;
            List<RequestCommissioningIndividualMeteringDevice> ListRequestCommissioningIndividualMeteringDevice;


            if (RequestEnum == RequestEnum.RequestCreatePersonalAccount)
            {
                

                using(RequestContext db = new RequestContext())
                {
                    ListRequestCreatePersonalAccounts = (from request in db.RequestCreatePersonalAccounts
                                                         where request.DateofApplicationSubmission >= StartDate && request.DateofApplicationSubmission <= EndDate
                                                         select request).ToList();
                }

                var application = new Word.Application();

                Word.Document document = application.Documents.Add();
                document.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                Word.Paragraph titleParagraph = document.Paragraphs.Add();
                //titleParagraph.set_Style("Title");
                Word.Range titleRange = titleParagraph.Range;
                titleRange.Text = "Отчет по заявке на создание нового лицевого счета";
                titleParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                titleRange.Font.Size = 16;
                titleRange.InsertParagraphAfter();
              

                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table paymentsTable = document.Tables.Add(tableRange, ListRequestCreatePersonalAccounts.Count() + 1, 7);
                paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                Word.Range cellRange;

                cellRange = paymentsTable.Cell(1, 1).Range;
                cellRange.Text = "Дата подачи заявки";
                cellRange = paymentsTable.Cell(1, 2).Range;
                cellRange.Text = "ФИО";
                cellRange = paymentsTable.Cell(1, 3).Range;
                cellRange.Text = "Адрес помещения";
                cellRange = paymentsTable.Cell(1, 4).Range;
                cellRange.Text = "Жилая площадь";
                cellRange = paymentsTable.Cell(1, 5).Range;
                cellRange.Text = "Общая площадь";
                cellRange = paymentsTable.Cell(1, 6).Range;
                cellRange.Text = "Размер доли";
                cellRange = paymentsTable.Cell(1, 7).Range;
                cellRange.Text = "Статус рассмотрения";


                for (int i = 0; i < ListRequestCreatePersonalAccounts.Count(); i++)
                {
                    cellRange = paymentsTable.Cell(i + 2, 1).Range;
                    cellRange.Text = Convert.ToString(ListRequestCreatePersonalAccounts[i].DateofApplicationSubmission).Remove(10, 8);
                    cellRange = paymentsTable.Cell(i + 2, 2).Range;
                    cellRange.Text = ListRequestCreatePersonalAccounts[i].FullName;
                    cellRange = paymentsTable.Cell(i + 2, 3).Range;
                    cellRange.Text = ListRequestCreatePersonalAccounts[i].AddressFacility;
                    cellRange = paymentsTable.Cell(i + 2, 4).Range;
                    cellRange.Text = Convert.ToString(ListRequestCreatePersonalAccounts[i].LivingArea);
                    cellRange = paymentsTable.Cell(i + 2, 5).Range;
                    cellRange.Text = Convert.ToString(ListRequestCreatePersonalAccounts[i].TotalArea);
                    cellRange = paymentsTable.Cell(i + 2, 6).Range;
                    cellRange.Text = Convert.ToString(ListRequestCreatePersonalAccounts[i].ShareSize);
                    cellRange = paymentsTable.Cell(i + 2, 7).Range;
                    cellRange.Text = Convert.ToString(ListRequestCreatePersonalAccounts[i].ReviewStatus);
                }

                application.Visible = true;
            }
            else if (RequestEnum == RequestEnum.ApplicationForChangingTheNumberOfConsumer) 
            { 
                using (RequestContext db = new RequestContext())
                {
                    ListApplicationForChangingTheNumberOfConsumer = (from request in db.ApplicationForChangingTheNumberOfConsumers
                                                                     where request.DateofApplicationSubmission >= StartDate && request.DateofApplicationSubmission <= EndDate
                                                                     select request).ToList();
                }

                var application = new Word.Application();

                Word.Document document = application.Documents.Add();
                document.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                Word.Paragraph titleParagraph = document.Paragraphs.Add();
                //titleParagraph.set_Style("Title");
                Word.Range titleRange = titleParagraph.Range;
                titleRange.Text = "Отчет по заявке на изменение количества потребителей";
                titleParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                titleRange.Font.Size = 16;
                titleRange.InsertParagraphAfter();


                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table paymentsTable = document.Tables.Add(tableRange, ListApplicationForChangingTheNumberOfConsumer.Count() + 1, 5);
                paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                Word.Range cellRange;

                cellRange = paymentsTable.Cell(1, 1).Range;
                cellRange.Text = "Дата подачи заявки";
                cellRange = paymentsTable.Cell(1, 2).Range;
                cellRange.Text = "ФИО";
                cellRange = paymentsTable.Cell(1, 3).Range;
                cellRange.Text = "Адрес помещения";
                cellRange = paymentsTable.Cell(1, 4).Range;
                cellRange.Text = "Абоненты";
                cellRange = paymentsTable.Cell(1, 5).Range;
                cellRange.Text = "Статус рассмотрения";


                for (int i = 0; i < ListApplicationForChangingTheNumberOfConsumer.Count(); i++)
                {
                    cellRange = paymentsTable.Cell(i + 2, 1).Range;
                    cellRange.Text = (Convert.ToString(ListApplicationForChangingTheNumberOfConsumer[i].DateofApplicationSubmission)).Remove(10, 8);
                    cellRange = paymentsTable.Cell(i + 2, 2).Range;
                    cellRange.Text = ListApplicationForChangingTheNumberOfConsumer[i].FullNameApplicant;
                    cellRange = paymentsTable.Cell(i + 2, 3).Range;
                    cellRange.Text = ListApplicationForChangingTheNumberOfConsumer[i].AddressFacility;
                    cellRange = paymentsTable.Cell(i + 2, 4).Range;                   
                    
                    using(RequestContext db = new RequestContext())
                    {
                        ListOfConsumersForTheApplications = (from consumer in db.ListOfConsumersForTheApplications
                                                             where consumer.IdApplicationForChangingTheNumberOfConsumers == ListApplicationForChangingTheNumberOfConsumer[i].Id
                                                             select consumer).ToList();
                    }
                    string startDate, endDate;
                    foreach(ListOfConsumersForTheApplication consumer in ListOfConsumersForTheApplications)
                    {
                        startDate = (Convert.ToString(consumer.StartDate)).Remove(10, 8);
                        if (consumer.EndDate != null)
                        {
                            endDate = (Convert.ToString(consumer.EndDate)).Remove(10, 8);
                            cellRange.Text += "ФИО: " + consumer.FullName + "; Статус регистрации: " + consumer.Status + "; Дата начала: " + startDate + "; Дата окончания: " + endDate + Environment.NewLine;
                        }
                        else { cellRange.Text += "ФИО: " + consumer.FullName + "; Статус регистрации: " + consumer.Status + "; Дата начала: " + startDate + Environment.NewLine; }
                        
                    }


                    cellRange = paymentsTable.Cell(i + 2, 5).Range;
                    cellRange.Text = ListApplicationForChangingTheNumberOfConsumer[i].ReviewStatus;
                }

                application.Visible = true;
            }
            else if (RequestEnum == RequestEnum.RequestChangeParametersPersonalAccount) 
            {
                using (RequestContext db = new RequestContext())
                {
                    ListRequestChangeParametersPersonalAccount = (from request in db.RequestChangeParametersPersonalAccounts
                                                                  where request.DateofApplicationSubmission >= StartDate && request.DateofApplicationSubmission <= EndDate
                                                                  select request).ToList();
                }

                var application = new Word.Application();

                Word.Document document = application.Documents.Add();
                document.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                Word.Paragraph titleParagraph = document.Paragraphs.Add();
                //titleParagraph.set_Style("Title");
                Word.Range titleRange = titleParagraph.Range;
                titleRange.Text = "Отчет по заявке на изменение параметров лицевого счета";
                titleParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                titleRange.Font.Size = 16;
                titleRange.InsertParagraphAfter();


                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table paymentsTable = document.Tables.Add(tableRange, ListRequestChangeParametersPersonalAccount.Count() + 1, 7);
                paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                Word.Range cellRange;

                cellRange = paymentsTable.Cell(1, 1).Range;
                cellRange.Text = "Дата подачи заявки";                
                cellRange = paymentsTable.Cell(1, 2).Range;
                cellRange.Text = "Номер лицевого счета";                
                cellRange = paymentsTable.Cell(1, 3).Range;
                cellRange.Text = "Адрес помещения";
                cellRange = paymentsTable.Cell(1, 4).Range;
                cellRange.Text = "ФИО";
                cellRange = paymentsTable.Cell(1, 5).Range;
                cellRange.Text = "Площадь помещения";
                cellRange = paymentsTable.Cell(1, 6).Range;
                cellRange.Text = "Размер доли";
                cellRange = paymentsTable.Cell(1, 7).Range;
                cellRange.Text = "Статус рассмотрения";


                for (int i = 0; i < ListRequestChangeParametersPersonalAccount.Count(); i++)
                {
                    cellRange = paymentsTable.Cell(i + 2, 1).Range;
                    cellRange.Text = Convert.ToString(ListRequestChangeParametersPersonalAccount[i].DateofApplicationSubmission).Remove(10, 8);
                    cellRange = paymentsTable.Cell(i + 2, 2).Range;
                    cellRange.Text = Convert.ToString(ListRequestChangeParametersPersonalAccount[i].IdPersonalAccount);
                    cellRange = paymentsTable.Cell(i + 2, 3).Range;
                    cellRange.Text = ListRequestChangeParametersPersonalAccount[i].AddressFacility;
                    cellRange = paymentsTable.Cell(i + 2, 4).Range;
                    cellRange.Text = Convert.ToString(ListRequestChangeParametersPersonalAccount[i].FullName);
                    cellRange = paymentsTable.Cell(i + 2, 5).Range;
                    cellRange.Text = Convert.ToString(ListRequestChangeParametersPersonalAccount[i].TotalArea);
                    cellRange = paymentsTable.Cell(i + 2, 6).Range;
                    cellRange.Text = Convert.ToString(ListRequestChangeParametersPersonalAccount[i].ShareSize);
                    cellRange = paymentsTable.Cell(i + 2, 7).Range;
                    cellRange.Text = Convert.ToString(ListRequestChangeParametersPersonalAccount[i].ReviewStatus);
                }

                application.Visible = true;
            }
            else if (RequestEnum == RequestEnum.RequestRecalculationFee) 
            {
                using (RequestContext db = new RequestContext())
                {
                    ListRequestRecalculationFee = (from request in db.RequestRecalculationFees
                                                   where request.DateofApplicationSubmission >= StartDate && request.DateofApplicationSubmission <= EndDate
                                                   select request).ToList();
                }

                var application = new Word.Application();

                Word.Document document = application.Documents.Add();
                document.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                Word.Paragraph titleParagraph = document.Paragraphs.Add();
                Word.Range titleRange = titleParagraph.Range;
                titleRange.Text = "Отчет по заявке на изменение количества потребителей";
                titleParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                titleRange.Font.Size = 16;
                titleRange.InsertParagraphAfter();


                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table paymentsTable = document.Tables.Add(tableRange, ListRequestRecalculationFee.Count() + 1, 5);
                paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                Word.Range cellRange;

                cellRange = paymentsTable.Cell(1, 1).Range;
                cellRange.Text = "Дата подачи заявки";
                cellRange = paymentsTable.Cell(1, 2).Range;
                cellRange.Text = "ФИО";
                cellRange = paymentsTable.Cell(1, 3).Range;
                cellRange.Text = "Адрес помещения";
                cellRange = paymentsTable.Cell(1, 4).Range;
                cellRange.Text = "Абоненты";
                cellRange = paymentsTable.Cell(1, 5).Range;
                cellRange.Text = "Статус рассмотрения";


                for (int i = 0; i < ListRequestRecalculationFee.Count(); i++)
                {
                    cellRange = paymentsTable.Cell(i + 2, 1).Range;
                    cellRange.Text = Convert.ToString(ListRequestRecalculationFee[i].DateofApplicationSubmission).Remove(10, 8);
                    cellRange = paymentsTable.Cell(i + 2, 2).Range;
                    cellRange.Text = Convert.ToString(ListRequestRecalculationFee[i].IdPersonalAccount);
                    cellRange = paymentsTable.Cell(i + 2, 3).Range;
                    cellRange.Text = ListRequestRecalculationFee[i].FullName;
                    cellRange = paymentsTable.Cell(i + 2, 4).Range;

                    using (RequestContext db = new RequestContext())
                    {
                        ListOfConsumersForTheRecalculationFees = (from consumer in db.ListOfConsumersForTheRecalculationFees
                                                             where consumer.IdRequestRecalculationFee == ListRequestRecalculationFee[i].Id
                                                             select consumer).ToList();
                    }
                    string startDate, endDate;
                    foreach (ListOfConsumersForTheRecalculationFee consumer in ListOfConsumersForTheRecalculationFees)
                    {
                        startDate = (Convert.ToString(consumer.StartDate)).Remove(10, 8);                    
                        endDate = (Convert.ToString(consumer.EndDate)).Remove(10, 8);
                        cellRange.Text += "ФИО: " + consumer.FullName + "; Дата начала: " + startDate + "; Дата окончания: " + endDate + Environment.NewLine;
                    }


                    cellRange = paymentsTable.Cell(i + 2, 5).Range;
                    cellRange.Text = ListRequestRecalculationFee[i].ReviewStatus;
                }

                application.Visible = true;
            }
            else if (RequestEnum == RequestEnum.RequestCommissioningIndividualMeteringDevice)
            {
                using (RequestContext db = new RequestContext())
                {
                    ListRequestCommissioningIndividualMeteringDevice = (from request in db.RequestCommissioningIndividualMeteringDevices
                                                                        where request.DateofApplicationSubmission >= StartDate && request.DateofApplicationSubmission <= EndDate
                                                                        select request).ToList();
                }

                var application = new Word.Application();

                Word.Document document = application.Documents.Add();
                document.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                Word.Paragraph titleParagraph = document.Paragraphs.Add();
                //titleParagraph.set_Style("Title");
                Word.Range titleRange = titleParagraph.Range;
                titleRange.Text = "Отчет по заявке на изменение параметров лицевого счета";
                titleParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                titleRange.Font.Size = 16;
                titleRange.InsertParagraphAfter();


                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table paymentsTable = document.Tables.Add(tableRange, ListRequestCommissioningIndividualMeteringDevice.Count() + 1, 10);
                paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                Word.Range cellRange;

                cellRange = paymentsTable.Cell(1, 1).Range;
                cellRange.Text = "Дата подачи заявки";
                cellRange = paymentsTable.Cell(1, 2).Range;
                cellRange.Text = "ФИО";
                cellRange = paymentsTable.Cell(1, 3).Range;
                cellRange.Text = "Номер лицевого счета";
                cellRange = paymentsTable.Cell(1, 4).Range;
                cellRange.Text = "Услуга";
                cellRange = paymentsTable.Cell(1, 5).Range;
                cellRange.Text = "Дата введения в эксплуатацию";
                cellRange = paymentsTable.Cell(1, 6).Range;
                cellRange.Text = "Заводской номер";
                cellRange = paymentsTable.Cell(1, 7).Range;
                cellRange.Text = "Тип устройства";
                cellRange = paymentsTable.Cell(1, 8).Range;
                cellRange.Text = "Показания прибора на момент допуска";
                cellRange = paymentsTable.Cell(1, 9).Range;
                cellRange.Text = "Место установки ПУ";
                cellRange = paymentsTable.Cell(1, 10).Range;
                cellRange.Text = "Статус рассмотрения";

                for (int i = 0; i < ListRequestCommissioningIndividualMeteringDevice.Count(); i++)
                {
                    cellRange = paymentsTable.Cell(i + 2, 1).Range;
                    cellRange.Text = Convert.ToString(ListRequestCommissioningIndividualMeteringDevice[i].DateofApplicationSubmission).Remove(10, 8);
                    cellRange = paymentsTable.Cell(i + 2, 2).Range;
                    cellRange.Text = Convert.ToString(ListRequestCommissioningIndividualMeteringDevice[i].FullName);
                    cellRange = paymentsTable.Cell(i + 2, 3).Range;
                    cellRange.Text = Convert.ToString(ListRequestCommissioningIndividualMeteringDevice[i].IdPersonalAccount);
                    cellRange = paymentsTable.Cell(i + 2, 4).Range;
                    cellRange.Text = Convert.ToString(ListRequestCommissioningIndividualMeteringDevice[i].Service);
                    cellRange = paymentsTable.Cell(i + 2, 5).Range;
                    cellRange.Text = Convert.ToString(ListRequestCommissioningIndividualMeteringDevice[i].DateCommissioning).Remove(10, 8);
                    cellRange = paymentsTable.Cell(i + 2, 6).Range;
                    cellRange.Text = Convert.ToString(ListRequestCommissioningIndividualMeteringDevice[i].FactoryNumber);
                    cellRange = paymentsTable.Cell(i + 2, 7).Range;
                    cellRange.Text = Convert.ToString(ListRequestCommissioningIndividualMeteringDevice[i].TypeDevice);
                    cellRange = paymentsTable.Cell(i + 2, 8).Range;
                    cellRange.Text = Convert.ToString(ListRequestCommissioningIndividualMeteringDevice[i].DeviceReadingsAtTheTimeOfAdmission);
                    cellRange = paymentsTable.Cell(i + 2, 9).Range;
                    cellRange.Text = Convert.ToString(ListRequestCommissioningIndividualMeteringDevice[i].InstallationLocation);
                    cellRange = paymentsTable.Cell(i + 2, 10).Range;
                    cellRange.Text = Convert.ToString(ListRequestCommissioningIndividualMeteringDevice[i].ReviewStatus);
                }

                application.Visible = true;
            }       
        }

        private RelayCommand reportRequest;
        public RelayCommand ReportRequest
        {
            get
            {
                return reportRequest ??
                    (reportRequest = new RelayCommand(obj =>
                    {
                        createReportRequest();
                    }));
            }
        }
    }
}
