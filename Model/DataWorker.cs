using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Project.Model
{
    public static class DataWorker
    {
        #region GET
        public static List<RequestCreatePersonalAccount> GetRequestCreatePersonalAccounts()
        {
            using (RequestContext db = new RequestContext())
            {

                return (from request in db.RequestCreatePersonalAccounts select request).ToList();
            }
        }

        public static List<ApplicationForChangingTheNumberOfConsumer> GetApplicationForChangingTheNumberOfConsumers()
        {
            using (RequestContext requestContext = new RequestContext())
            {
                requestContext.ApplicationForChangingTheNumberOfConsumers.Load();
                return requestContext.ApplicationForChangingTheNumberOfConsumers.Local.ToList();
            }
        }

        public static List<ListOfConsumersForTheApplication> GetListOfConsumersForTheApplications(ApplicationForChangingTheNumberOfConsumer selectedItem)
        {
            using (RequestContext db = new RequestContext())
            { 
                
                return (from listOfConsumersForTheApplication in db.ListOfConsumersForTheApplications
                        where listOfConsumersForTheApplication.IdApplicationForChangingTheNumberOfConsumers == selectedItem.Id
                        select listOfConsumersForTheApplication).ToList();
            }
        }

        public static List<RequestChangeParametersPersonalAccount> GetRequestChangeParametersPersonalAccounts()
        {
            using (RequestContext db = new RequestContext())
            {
                return (from request in db.RequestChangeParametersPersonalAccounts select request).ToList();
            }
        }

        public static List<RequestRecalculationFee> GetRequestRecalculationFees()
        {
            using (RequestContext db = new RequestContext())
            {
                return (from request in db.RequestRecalculationFees select request).ToList();
            }
        }

        public static List<ListOfConsumersForTheRecalculationFee> GetListOfConsumersForTheRecalculationFees(RequestRecalculationFee selectedItem)
        {
            using (RequestContext db = new RequestContext())
            {
                //ListOfConsumersForTheApplications = db.ListOfConsumersForTheApplications.Where(p => p.IdApplicationForChangingTheNumberOfConsumers == 1);
                return (from listOfConsumersForTheRecalculationFee in db.ListOfConsumersForTheRecalculationFees
                        where listOfConsumersForTheRecalculationFee.IdRequestRecalculationFee == selectedItem.Id
                        select listOfConsumersForTheRecalculationFee).ToList();
                //ListOfConsumersForTheApplications = listOfConsumersForTheApplications;
            }
        }

        public static List<RequestCommissioningIndividualMeteringDevice> GetRequestCommissioningIndividualMeteringDevices()
        {
            using (RequestContext db = new RequestContext())
            {
                return (from request in db.RequestCommissioningIndividualMeteringDevices select request).ToList();
            }
        }

        #endregion

        #region ADD
        public static void AddRequestCreatePersonalAccount(RequestCreatePersonalAccount obj)
        {
            using (RequestContext db = new RequestContext())
            {
                db.RequestCreatePersonalAccounts.Add(obj);
                db.SaveChanges();
                MessageBox.Show("Заявка создана успешно");
            }
        }

        public static void AddApplicationForChangingTheNumberOfConsumer(ApplicationForChangingTheNumberOfConsumer obj, List<ListOfConsumersForTheApplication> listOfConsumers)
        {
            using (RequestContext db = new RequestContext())
            {
                bool check = false;
                List<Facility> listFacility = (from facilities in db.Facilities select facilities).ToList();                //Проверка на существование адреса
                foreach (Facility facility in listFacility)
                {
                    if (obj.AddressFacility == facility.Address)
                    {
                        check = true;
                    }
                }

                if (!check) 
                { 
                    MessageBox.Show("Такого адреса нет");
                    return;
                }

                db.ApplicationForChangingTheNumberOfConsumers.Add(obj);
                db.SaveChanges();


                List<ApplicationForChangingTheNumberOfConsumer> lastApplication = (from app in db.ApplicationForChangingTheNumberOfConsumers
                                                                                   select app).ToList();

                int maxId = -1;

                foreach(ApplicationForChangingTheNumberOfConsumer app in lastApplication)
                {
                    maxId = app.Id;
                }

                if(maxId != -1)
                {
                    foreach(ListOfConsumersForTheApplication сonsumer in listOfConsumers)
                    {
                        сonsumer.IdApplicationForChangingTheNumberOfConsumers = maxId;
                        db.ListOfConsumersForTheApplications.Add(сonsumer);
                    }
                }

                db.SaveChanges();
                MessageBox.Show("Заявка создана успешно");
            }
        }

        public static void AddRequestChangeParametersPersonalAccounts(RequestChangeParametersPersonalAccount obj)
        {
            using (RequestContext db = new RequestContext())
            {
                bool check = false;
                List<PersonalAccount> listPersonalAccount = (from account in db.PersonalAccounts select account).ToList();                //Проверка на существование лицевого счета
                foreach (PersonalAccount account in listPersonalAccount)
                {
                    if (obj.IdPersonalAccount == account.Id)
                    {
                        check = true;
                    }
                }

                if (!check)
                {
                    MessageBox.Show("Такого лицевого счета нету");
                    return;
                }

                db.RequestChangeParametersPersonalAccounts.Add(obj);
                db.SaveChanges();
                MessageBox.Show("Заявка создана успешно");
            }
        }

        public static void AddRequestRecalculationFee(RequestRecalculationFee obj, List<ListOfConsumersForTheRecalculationFee> listOfConsumers)
        {
            using (RequestContext db = new RequestContext())
            {
                db.RequestRecalculationFees.Add(obj);
                db.SaveChanges();


                List<RequestRecalculationFee> lastApplication = (from app in db.RequestRecalculationFees
                                                                                   select app).ToList();

                int maxId = -1;

                foreach (RequestRecalculationFee app in lastApplication)
                {
                    maxId = app.Id;
                }

                if (maxId != -1)
                {
                    foreach (ListOfConsumersForTheRecalculationFee сonsumer in listOfConsumers)
                    {
                        сonsumer.IdRequestRecalculationFee = maxId;
                        db.ListOfConsumersForTheRecalculationFees.Add(сonsumer);
                    }
                }

                db.SaveChanges();
                MessageBox.Show("Заявка создана успешно");
            }
        }

        public static void AddRequestCommissioningIndividualMeteringDevice(RequestCommissioningIndividualMeteringDevice obj)
        {
            using (RequestContext db = new RequestContext())
            {
                db.RequestCommissioningIndividualMeteringDevices.Add(obj);
                db.SaveChanges();
                MessageBox.Show("Заявка создана успешно");
            }
        }

        #endregion

        #region DELETE
        public static void DeleteRequestCreatePersonalAccount(RequestCreatePersonalAccount obj)
        {
            using (RequestContext db = new RequestContext())
            {
                db.RequestCreatePersonalAccounts.Remove(obj);
                db.SaveChanges();
            }
        }

        public static void DeleteApplicationForChangingTheNumberOfConsumer(ApplicationForChangingTheNumberOfConsumer obj)
        {
            using (RequestContext db = new RequestContext())
            {
                List<ListOfConsumersForTheApplication> listOfConsumers =(from o in db.ListOfConsumersForTheApplications 
                                                                        where o.IdApplicationForChangingTheNumberOfConsumers == obj.Id
                                                                        select o).ToList();

                foreach(ListOfConsumersForTheApplication consumer in listOfConsumers)
                {
                    db.ListOfConsumersForTheApplications.Remove(consumer);
                }

                db.ApplicationForChangingTheNumberOfConsumers.Remove(obj);
                db.SaveChanges();
            }
        }

        public static void DeleteRequestChangeParametersPersonalAccount(RequestChangeParametersPersonalAccount obj)
        {
            using (RequestContext db = new RequestContext())
            {
                db.RequestChangeParametersPersonalAccounts.Remove(obj);
                db.SaveChanges();
            }
        }

        public static void DeleteRequestRecalculationFee(RequestRecalculationFee obj)
        {
            using (RequestContext db = new RequestContext())
            {
                List<ListOfConsumersForTheRecalculationFee> listOfConsumers = (from o in db.ListOfConsumersForTheRecalculationFees
                                                                               where o.IdRequestRecalculationFee == obj.Id
                                                                               select o).ToList();

                foreach (ListOfConsumersForTheRecalculationFee consumer in listOfConsumers)
                {
                    db.ListOfConsumersForTheRecalculationFees.Remove(consumer);
                }

                db.RequestRecalculationFees.Remove(obj);
                db.SaveChanges();
            }
        }

        public static void DeleteRequestCommissioningIndividualMeteringDevice(RequestCommissioningIndividualMeteringDevice obj)
        {
            using (RequestContext db = new RequestContext())
            {
                db.RequestCommissioningIndividualMeteringDevices.Remove(obj);
                db.SaveChanges();
            }
        }

        #endregion

        #region EDIT
        public static void EditRequestCreatePersonalAccount(RequestCreatePersonalAccount obj)
        {   
            if(obj.ReviewStatus == "Одобрена")
            {
                MessageBox.Show("Данная запись не доступна для редактирования");
                return;
            }
            using (RequestContext db = new RequestContext())
            {
                
                db.RequestCreatePersonalAccounts.Update(obj);
                db.SaveChanges();
            }
        }

        public static void EditApplicationForChangingTheNumberOfConsumer(ApplicationForChangingTheNumberOfConsumer obj, List<ListOfConsumersForTheApplication> listOfConsumers)
        {
            if (obj.ReviewStatus == "Одобрена")
            {
                MessageBox.Show("Данная запись не доступна для редактирования");
                return;
            }

            using (RequestContext db = new RequestContext())
            {
                foreach(var consumer in listOfConsumers)                                                                    //установка внешнего ключа для все элементов контейнера(на случай, если будет добавление новых абонентов
                {
                    consumer.IdApplicationForChangingTheNumberOfConsumers = obj.Id;
                }

                db.ApplicationForChangingTheNumberOfConsumers.Update(obj);
                db.ListOfConsumersForTheApplications.RemoveRange(DataWorker.GetListOfConsumersForTheApplications(obj));
                db.ListOfConsumersForTheApplications.AddRange(listOfConsumers);
                db.SaveChanges();
            }
        }

        public static void EditRequestChangeParametersPersonalAccount(RequestChangeParametersPersonalAccount obj)
        {
            if (obj.ReviewStatus == "Одобрена")
            {
                MessageBox.Show("Данная запись не доступна для редактирования");
                return;
            }

            using (RequestContext db = new RequestContext())
            {
                db.RequestChangeParametersPersonalAccounts.Update(obj);
                db.SaveChanges();
            }
        }

        public static void EditRequestRecalculationFee(RequestRecalculationFee obj, List<ListOfConsumersForTheRecalculationFee> listOfConsumers)
        {
            if (obj.ReviewStatus == "Одобрена")
            {
                MessageBox.Show("Данная запись не доступна для редактирования");
                return;
            }

            using (RequestContext db = new RequestContext())
            {
                foreach (var consumer in listOfConsumers)                                                                    //установка внешнего ключа для все элементов контейнера(на случай, если будет добавление новых абонентов
                {
                    consumer.IdRequestRecalculationFee = obj.Id;
                }

                db.RequestRecalculationFees.Update(obj);
                db.ListOfConsumersForTheRecalculationFees.RemoveRange(DataWorker.GetListOfConsumersForTheRecalculationFees(obj));    
                db.ListOfConsumersForTheRecalculationFees.AddRange(listOfConsumers);
                db.SaveChanges();
            }
        }

        public static void EditRequestCommissioningIndividualMeteringDevice(RequestCommissioningIndividualMeteringDevice obj)
        {
            if (obj.ReviewStatus == "Одобрена")
            {
                MessageBox.Show("Данная запись не доступна для редактирования");
                return;
            }

            using (RequestContext db = new RequestContext())
            {
                db.RequestCommissioningIndividualMeteringDevices.Update(obj);
                db.SaveChanges();
            }
        }

        #endregion

        #region ChangingReviewStatus
        public static void ChangingReviewStatusRequestCreatePersonalAccount(RequestCreatePersonalAccount request, bool approve)
        {
            if (request.ReviewStatus == "Одобрена")
            {
                MessageBox.Show("Данная запись не доступна для изменения статуса рассмотрения");
                return;
            }

            using (RequestContext db = new RequestContext())
            {
                if(approve)
                {
                    request.ReviewStatus = "Одобрена";
                    db.RequestCreatePersonalAccounts.Update(request);

                    Facility facility = new Facility() { Address = request.AddressFacility, LivingArea = request.LivingArea, TotalArea = request.TotalArea };
                    db.Facilities.Add(facility);

                    Subscriber subscriber = new Subscriber() { FullName = request.FullName, PassportSeries = request.PassportSeries, PassportId = request.PassportId, PassportDate = request.PassportDate,
                                                                DepartmentCode = request.DepartmentCode, PhoneNumber = request.Telephone
                    };
                    db.Subscribers.Add(subscriber);
                    db.SaveChanges();

                    db.PersonalAccounts.Add(new PersonalAccount() { IdFacility = facility.Id, IdSubscriber = subscriber.Id, ShareSize = request.ShareSize });

                    db.SaveChanges();
                }
                else
                {
                    request.ReviewStatus = "Отклонена";
                    db.RequestCreatePersonalAccounts.Update(request);
                    db.SaveChanges();
                }
            }
        }

        public static void ChangingReviewStatusApplicationForChangingTheNumberOfConsumer(ApplicationForChangingTheNumberOfConsumer request, bool approve)
        {
            if (request.ReviewStatus == "Одобрена")
            {
                MessageBox.Show("Данная запись не доступна для изменения статуса рассмотрения");
                return;
            }

            using (RequestContext db = new RequestContext())
            {
                if(approve)
                {                   
                    bool check = false;
                    int idFacility = 0;
                    List<Facility> listFacility = (from facilities in db.Facilities select facilities).ToList();
                    foreach(Facility facility in listFacility)
                    {
                        if (request.AddressFacility == facility.Address) 
                        { 
                            check = true;
                            idFacility = facility.Id;
                        }
                    }

                    if(check)
                    {
                        List<ListOfConsumersForTheApplication> listOfConsumersTheApplication = (from consumers in db.ListOfConsumersForTheApplications
                                                                                  where consumers.IdApplicationForChangingTheNumberOfConsumers == request.Id
                                                                                  select consumers).ToList();

                        List<FacilityConsumer> facilityConsumersFromDelete = (from consumers in db.FacilityConsumers                    //удалем уже имеющихся consumers и добавляем заного созданных
                                                                              where consumers.IdFacility == idFacility
                                                                              select consumers).ToList();
                        db.FacilityConsumers.RemoveRange(facilityConsumersFromDelete);
                        db.SaveChanges();

                        foreach(ListOfConsumersForTheApplication consumersForTheApplication in listOfConsumersTheApplication)
                        {
                            db.FacilityConsumers.Add(new FacilityConsumer() { FullName = consumersForTheApplication.FullName, Status = consumersForTheApplication.Status,
                                                                                StartDate = (DateTime)consumersForTheApplication.StartDate, EndDate = consumersForTheApplication.EndDate, IdFacility = idFacility
                            });
                        }

                        request.ReviewStatus = "Одобрена";
                        db.ApplicationForChangingTheNumberOfConsumers.Update(request);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Такого адреса нету");
                    }
                }
                else
                {
                    request.ReviewStatus = "Отклонена";
                    db.ApplicationForChangingTheNumberOfConsumers.Update(request);
                    db.SaveChanges();
                }
            }
        }

        public static void ChangingReviewStatusRequestChangeParametersPersonalAccount(RequestChangeParametersPersonalAccount request, bool approve)
        {
            if (request.ReviewStatus == "Одобрена")
            {
                MessageBox.Show("Данная запись не доступна для изменения статуса рассмотрения");
                return;
            }

            using (RequestContext db = new RequestContext())
            {
                if (approve)
                {
                    bool check = false;
                    List<PersonalAccount> listPersonalAccount = (from account in db.PersonalAccounts select account).ToList();                //Проверка на существование лицевого счета
                    foreach (PersonalAccount account in listPersonalAccount)
                    {
                        if (request.IdPersonalAccount == account.Id)
                        {
                            check = true;
                        }
                    }
                    if (!check)
                    {
                        MessageBox.Show("Такого адреса нету");
                        return;
                    }


                    List<PersonalAccount> personalAccounts = (from account in db.PersonalAccounts
                                                              where account.Id == request.IdPersonalAccount
                                                              select account).ToList();
                    personalAccounts[0].ShareSize = request.ShareSize;
                    db.PersonalAccounts.Update(personalAccounts[0]);

                    int idSubscriber = (int)personalAccounts[0].IdSubscriber;
                    int idFacility = (int)personalAccounts[0].IdFacility;

                    List<Subscriber> subscribers = (from sub in db.Subscribers
                                                    where sub.Id == idSubscriber
                                                    select sub).ToList();
                    subscribers[0].FullName = request.FullName;
                    db.Subscribers.Update(subscribers[0]);

                    List<Facility> facilities = (from facility in db.Facilities
                                                 where facility.Id == idFacility
                                                 select facility).ToList();
                    facilities[0].TotalArea = request.TotalArea;
                    db.Facilities.Update(facilities[0]);

                    request.ReviewStatus = "Одобрена";
                    db.RequestChangeParametersPersonalAccounts.Update(request);

                    db.SaveChanges();
                }
                else
                {
                    request.ReviewStatus = "Отклонена";
                    db.RequestChangeParametersPersonalAccounts.Update(request);
                }
            }
        }

        public static void ChangingReviewStatusRequestRecalculationFee(RequestRecalculationFee request, bool approve)
        {
            if (request.ReviewStatus == "Одобрена")
            {
                MessageBox.Show("Данная запись не доступна для изменения статуса рассмотрения");
                return;
            }

            using (RequestContext db = new RequestContext())
            {
                if(approve)
                {
                    request.ReviewStatus = "Одобрена";
                    db.RequestRecalculationFees.Update(request);
                    db.SaveChanges();
                }
                else
                {
                    request.ReviewStatus = "Отклонена";
                    db.RequestRecalculationFees.Update(request);
                    db.SaveChanges();
                }
            }
        }

        public static void ChangingReviewStatusRequestCommissioningIndividualMeteringDevice(RequestCommissioningIndividualMeteringDevice request, bool approve)
        {
            if (request.ReviewStatus == "Одобрена")
            {
                MessageBox.Show("Данная запись не доступна для изменения статуса рассмотрения");
                return;
            }

            using (RequestContext db = new RequestContext())
            {
                if (approve)
                {
                    request.ReviewStatus = "Одобрена";
                    db.RequestCommissioningIndividualMeteringDevices.Update(request);
                    db.SaveChanges();
                }
                else
                {
                    request.ReviewStatus = "Отклонена";
                    db.RequestCommissioningIndividualMeteringDevices.Update(request);
                    db.SaveChanges();
                }
            }
        }

        #endregion
    }
}
