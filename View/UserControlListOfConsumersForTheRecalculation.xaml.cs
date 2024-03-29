﻿using Project.ViewModel;
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

namespace Project.View
{
    /// <summary>
    /// Логика взаимодействия для UserControlListOfConsumersForTheRecalculation.xaml
    /// </summary>
    public partial class UserControlListOfConsumersForTheRecalculation : UserControl
    {
        public UserControlListOfConsumersForTheRecalculationFeeViewModel dataContext { get; set; }
        public UserControlListOfConsumersForTheRecalculation()
        {
            InitializeComponent();

            dataContext = new UserControlListOfConsumersForTheRecalculationFeeViewModel();
            DataContext = dataContext;
        }
    }
}
