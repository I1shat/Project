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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Project.ViewModel;

namespace Project.View
{
    /// <summary>
    /// Логика взаимодействия для UserControlListOfConsumersForTheApplication.xaml
    /// </summary>
    public partial class UserControlListOfConsumersForTheApplication : UserControl
    {
        //public ListOfConsumersForTheApplication consumer;
        public UserControlListOfConsumersForTheApplicationViewModel dataContext { get; set; }
        public UserControlListOfConsumersForTheApplication()
        {
            InitializeComponent();

            dataContext = new UserControlListOfConsumersForTheApplicationViewModel();
            DataContext = dataContext;
        }
    }
}

/*xmlns:viewmodel="clr-namespace:Project.ViewModel" d:DataContext="{d:DesignInstance Type=viewmodel:UserControlListOfConsumersForTheApplicationViewModel}"*/
