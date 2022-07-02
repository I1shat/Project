using System;
using System.Collections.Generic;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using Project.Model;
using System.Linq;

namespace Project.ViewModel
{
    class PersonalAccountStatementWindowViewModel
    {
        private void DocumentPersonalAccountStatement(PersonalAccount personalAccount, Subscriber subscriber, Facility facility, List<FacilityConsumer> facilityConsumers)
        {
            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph titleParagraph = document.Paragraphs.Add();
            //titleParagraph.set_Style("Title");
            Word.Range titleRange = titleParagraph.Range;
            titleRange.Text = "Копия финансового лицевого счета";
            titleParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            titleRange.Font.Size = 16;
            titleRange.InsertParagraphAfter();

            Word.Paragraph paragraph1 = document.Paragraphs.Add();
            paragraph1.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            Word.Range range1 = paragraph1.Range;
            range1.Text = "ФИО собственника: " + subscriber.FullName;
            range1.Font.Size = 12;
            range1.InsertParagraphAfter();

            Word.Paragraph paragraph2 = document.Paragraphs.Add();
            paragraph2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            Word.Range range2 = paragraph2.Range;
            range2.Text = "Адресс: " + facility.Address;
            range2.Font.Size = 12;
            range2.InsertParagraphAfter();

            Word.Paragraph paragraph3 = document.Paragraphs.Add();
            paragraph3.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            Word.Range range3 = paragraph3.Range;
            range3.Text = "Жилая площадь: " + facility.LivingArea + "   Общая площадь: " + facility.TotalArea;
            range3.Font.Size = 12;
            range3.InsertParagraphAfter();

            Word.Paragraph paragraph4 = document.Paragraphs.Add();
            paragraph4.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            Word.Range range4 = paragraph4.Range;
            range4.Text = "Размер доли в праве общей собственности: " + personalAccount.ShareSize;
            range4.Font.Size = 12;
            range4.InsertParagraphAfter();

            Word.Paragraph paragraph5 = document.Paragraphs.Add();
            paragraph5.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            Word.Range range5 = paragraph4.Range;
            range5.Text = "На указанной площади прописаны и проживают: ";
            range5.Font.Size = 12;
            range5.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, facilityConsumers.Count() + 1, 5);
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = paymentsTable.Cell(1, 1).Range;
            cellRange.Text = "№";
            cellRange = paymentsTable.Cell(1, 2).Range;
            cellRange.Text = "ФИО абонента";
            cellRange = paymentsTable.Cell(1, 3).Range;
            cellRange.Text = "Статус прописки";
            cellRange = paymentsTable.Cell(1, 4).Range;
            cellRange.Text = "Дата начала";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Дата окончания";


            for(int i = 0; i<facilityConsumers.Count(); i++)
            {
                cellRange = paymentsTable.Cell(i+2, 1).Range;
                cellRange.Text = Convert.ToString(facilityConsumers[i].Id);
                cellRange = paymentsTable.Cell(i+2, 2).Range;
                cellRange.Text = facilityConsumers[i].FullName;
                cellRange = paymentsTable.Cell(i+2, 3).Range;
                cellRange.Text = facilityConsumers[i].Status;
                cellRange = paymentsTable.Cell(i+2, 4).Range;
                cellRange.Text = Convert.ToString(Convert.ToString(facilityConsumers[i].StartDate)).Remove(10, 8);
                cellRange = paymentsTable.Cell(i+2, 5).Range;
                if (facilityConsumers[i].EndDate == null)
                {
                    cellRange.Text = Convert.ToString(facilityConsumers[i].EndDate);
                }
                else
                {
                    cellRange.Text = Convert.ToString(Convert.ToString(facilityConsumers[i].EndDate)).Remove(10, 8);
                }               
            }

            application.Visible = true;
        }

        public int IdPersonalAccount { get; set; } = 0;

        private RelayCommand createDocumentPersonalAccountStatement;
        public RelayCommand CreateDocumentPersonalAccountStatement
        { 
            get
            {
                return createDocumentPersonalAccountStatement ??
                    (createDocumentPersonalAccountStatement = new RelayCommand(obj =>
                    {
                        using(RequestContext db = new RequestContext())
                        {
                            var personalAccount = (from pA in db.PersonalAccounts
                                                    where pA.Id == IdPersonalAccount
                                                    select pA).ToList();
                            var subscriber = (from sub in db.Subscribers
                                              where sub.Id == personalAccount[0].IdSubscriber
                                              select sub).ToList();
                            var facility = (from fac in db.Facilities
                                            where fac.Id == personalAccount[0].IdFacility
                                            select fac).ToList();
                            var facilityConsumers = (from fC in db.FacilityConsumers
                                                     where fC.IdFacility == facility[0].Id
                                                     select fC).ToList();

                            DocumentPersonalAccountStatement(personalAccount[0], subscriber[0], facility[0], facilityConsumers);
                        }
                    }));
            } 
        }
    }
}
