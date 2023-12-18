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
    }

}

