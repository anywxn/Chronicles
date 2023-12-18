﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chronicles
{
    /// <summary>
    /// Логика взаимодействия для Table2.xaml
    /// </summary>
    public partial class Table2 : Page
    {
        public Table2()
        {
            InitializeComponent();
            gor.ItemsSource = chronichlesEntities.GetContext().Горы.ToList();
        }
    }
}
