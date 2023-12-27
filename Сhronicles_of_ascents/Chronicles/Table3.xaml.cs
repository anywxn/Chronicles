using System;
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
    /// Логика взаимодействия для Table3.xaml
    /// </summary>
    public partial class Table3 : Page
    {
        public Table3()
        {
            InitializeComponent();
            up.ItemsSource = chronichlesEntities.GetContext().Восхождения.ToList();
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            var SelectedForDelete = up.SelectedItems.Cast<Восхождения >().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить выделенные данные? Всего: {SelectedForDelete.Count()}", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    chronichlesEntities.GetContext().Восхождения.RemoveRange(SelectedForDelete);
                    chronichlesEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Btn_edit_Click(object sender, RoutedEventArgs e)
        {
            Восхождения selectedAlpinist = (Восхождения)up.SelectedItem;

            // Передайте выбранный объект на страницу редактирования
            Manager.MainFrame.Navigate(new AddEditPageTable3(selectedAlpinist));
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPageTable3(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                chronichlesEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                up.ItemsSource = chronichlesEntities.GetContext().Восхождения.ToList();

            }
        }

    }
}
