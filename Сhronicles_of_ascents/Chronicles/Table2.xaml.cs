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
    /// Логика взаимодействия для Table2.xaml
    /// </summary>
    public partial class Table2 : Page
    {
        public Table2()
        {
            InitializeComponent();
            gor.ItemsSource = chronichlesEntities.GetContext().Горы.ToList();
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            var SelectedForDelete = gor.SelectedItems.Cast<Горы>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить выделенные данные? Всего: {SelectedForDelete.Count()}", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    chronichlesEntities.GetContext().Горы.RemoveRange(SelectedForDelete);
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
            Горы selectedAlpinist = (Горы)gor.SelectedItem;

            // Передайте выбранный объект на страницу редактирования
            Manager.MainFrame.Navigate(new AddEditPageTable2(selectedAlpinist));
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPageTable2(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                chronichlesEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                gor.ItemsSource = chronichlesEntities.GetContext().Горы.ToList();

            }
        }

    }
}
