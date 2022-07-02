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
using Project.ViewModel;

namespace Project.View
{
    /// <summary>
    /// Логика взаимодействия для AddApplicationForChangingTheNumberOfConsumers.xaml
    /// </summary>
    public partial class AddApplicationForChangingTheNumberOfConsumers : Window
    {
        private List<ListOfConsumersForTheApplication> listOfConsumersForTheApplications = new List<ListOfConsumersForTheApplication>();        //коллекция listOfConsumersForTheApplications хранит ссылки на готовые объекты ListOfConsumersForTheApplication и потом отправится в AddRequestWindow
        public List<ListOfConsumersForTheApplication> ListOfConsumersForTheApplications
        {
            get { return listOfConsumersForTheApplications; }
            set { listOfConsumersForTheApplications = value; }
        }

        private List<UserControlListOfConsumersForTheApplication> listUserControl = new List<UserControlListOfConsumersForTheApplication>();        //Коллекция listUserControl хранит ссылки на объекты UserControl в stackPanel 
        public AddRequestWindowViewModel dataContext;
        public AddApplicationForChangingTheNumberOfConsumers()
        {
            InitializeComponent();

            dataContext = new AddRequestWindowViewModel();
            DataContext = dataContext;

            UserControlListOfConsumersForTheApplication userControl = new UserControlListOfConsumersForTheApplication();
            stackPanel.Children.Add(userControl);
            listUserControl.Add(userControl);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserControlListOfConsumersForTheApplication userControl = new UserControlListOfConsumersForTheApplication();
            stackPanel.Children.Add(userControl);
            listUserControl.Add(userControl);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { 
            stackPanel.Children.RemoveAt(stackPanel.Children.Count-1);
            listUserControl.RemoveAt(listUserControl.Count - 1); 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            foreach(UserControlListOfConsumersForTheApplication control in listUserControl)                 //Проходимся по всему контейнеру userControl и получаем из контекста данных каждого UserControl ссылку на объект ListOfConsumersForTheApplication с помощью метода GetConsumer 
            {
                listOfConsumersForTheApplications.Add(control.dataContext.GetConsumer());
            }

            dataContext.ListOfConsumers = this.ListOfConsumersForTheApplications;               //отправляем ссылку на полученный контейнер в AddRequestWindowViewModel
            ListOfConsumersForTheApplications = new List<ListOfConsumersForTheApplication>();
        }
    }
}


/* xmlns:viewmodel="clr-namespace:Project.ViewModel" d:DataContext="{d:DesignInstance Type=viewmodel:AddRequestWindowViewModel}"*/
