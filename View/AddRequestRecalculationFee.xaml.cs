using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project.View
{
    /// <summary>
    /// Логика взаимодействия для AddRequestRecalculationFee.xaml
    /// </summary>
    public partial class AddRequestRecalculationFee : Window
    {
        public AddRequestRecalculationFee()
        {
            InitializeComponent();

            dataContext = new AddRequestWindowViewModel();
            DataContext = dataContext;

            UserControlListOfConsumersForTheRecalculation userControl = new UserControlListOfConsumersForTheRecalculation();
            stackPanel.Children.Add(userControl);
            listUserControl.Add(userControl);
        }
        private List<ListOfConsumersForTheRecalculationFee> listOfConsumersForTheRecalculationFee = new List<ListOfConsumersForTheRecalculationFee>();        //коллекция listOfConsumersForTheRecalculationFee хранит ссылки на готовые объекты ListOfConsumersForTheApplication и потом отправится в AddRequestWindow
        public List<ListOfConsumersForTheRecalculationFee> ListOfConsumersForTheRecalculationFee
        {
            get { return listOfConsumersForTheRecalculationFee; }
            set { listOfConsumersForTheRecalculationFee = value; }
        }

        private List<UserControlListOfConsumersForTheRecalculation> listUserControl = new List<UserControlListOfConsumersForTheRecalculation>();        //Коллекция listUserControl хранит ссылки на объекты UserControl в stackPanel 
        public AddRequestWindowViewModel dataContext;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserControlListOfConsumersForTheRecalculation userControl = new UserControlListOfConsumersForTheRecalculation();
            stackPanel.Children.Add(userControl);
            listUserControl.Add(userControl);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            stackPanel.Children.RemoveAt(stackPanel.Children.Count - 1);
            listUserControl.RemoveAt(listUserControl.Count - 1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach (UserControlListOfConsumersForTheRecalculation control in listUserControl)                 //Проходимся по всему контейнеру userControl и получаем из контекста данных каждого UserControl ссылку на объект ListOfConsumersForTheApplication с помощью метода GetConsumer 
            {
                listOfConsumersForTheRecalculationFee.Add(control.dataContext.GetConsumer());
            }

            dataContext.ListListOfConsumersForTheRecalculationFee = this.listOfConsumersForTheRecalculationFee;               //отправляем ссылку на полученный контейнер в AddRequestWindowViewModel
            listOfConsumersForTheRecalculationFee = new List<ListOfConsumersForTheRecalculationFee>();
        }
    }
}
