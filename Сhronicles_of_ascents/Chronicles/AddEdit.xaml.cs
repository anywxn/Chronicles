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
    /// Логика взаимодействия для AddEdit.xaml
    /// </summary>
    public partial class AddEdit : Page
    {
        public AddEdit()
        {
            InitializeComponent();
            Alp.ItemsSource = chronichlesEntities.GetContext().Альпинисты.ToList();
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            var SelectedForDelete = Alp.SelectedItems.Cast<Альпинисты>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить выделенные данные? Всего: {SelectedForDelete.Count()}", "Внимание", 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    chronichlesEntities.GetContext().Альпинисты.RemoveRange(SelectedForDelete);
                    chronichlesEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалена!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Btn_edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
