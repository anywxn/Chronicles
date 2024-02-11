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
    /// Логика взаимодействия для Table4.xaml
    /// </summary>
    public partial class Table4 : Page
    {
        public Table4()
        {
            InitializeComponent();
            group.ItemsSource = chronichlesEntities.GetContext().Группы.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Вставьте здесь код выполнения SQL-запроса
            using (var context = new chronichlesEntities()) // Замените YourEntities на ваш класс контекста
            {
                var updateQuery = @"
                UPDATE [chronichles].[dbo].[Группы]
                SET Количество = (
                    SELECT COUNT(*)
                    FROM [chronichles].[dbo].[Альпинисты в группах]
                    WHERE [Альпинисты в группах].[ID Группы] = [chronichles].[dbo].[Группы].[ID Группы]
                )";

                context.Database.ExecuteSqlCommand(updateQuery);
            }
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            var SelectedForDelete = group.SelectedItems.Cast<Группы>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить выделенные данные? Всего: {SelectedForDelete.Count()}", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    chronichlesEntities.GetContext().Группы.RemoveRange(SelectedForDelete);
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
            Группы selectedAlpinist = (Группы)group.SelectedItem;

            // Передайте выбранный объект на страницу редактирования
            Manager.MainFrame.Navigate(new AddEditPageTable4(selectedAlpinist));
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPageTable4(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                chronichlesEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                group.ItemsSource = chronichlesEntities.GetContext().Группы.ToList();

            }
        }
    }

}

