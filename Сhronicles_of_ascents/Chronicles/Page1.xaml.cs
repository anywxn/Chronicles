using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Table1_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEdit());
        }

        private void Table2_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Table2());
        }

        private void Table3_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Table3());
        }

        private void Table4_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Table4());
        }

        private void Table5_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Table5());
        }

        private void query1_Click(object sender, RoutedEventArgs e)
        {
            var context = new chronichlesEntities();
            try
            {
                var query = from Горы in context.Горы
                            where Горы.Высота < 5000
                            select new
                            {
                                Название = Горы.Название,
                                Высота = Горы.Высота
                            };

                resultGrid.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void query2_Click(object sender, RoutedEventArgs e)
        {
            var context = new chronichlesEntities();
            try
            {
                var query = from альпинист in context.Альпинисты
                            join альпинистыВГруппах in context.Альпинисты_в_группах on альпинист.ID_Альпиниста equals альпинистыВГруппах.ID_Альпиниста
                            join группа in context.Группы on альпинистыВГруппах.ID_Группы equals группа.ID_Группы
                            join восхождение in context.Восхождения on группа.ID_Группы equals восхождение.ID_Группы
                            join гора in context.Горы on восхождение.ID_Горы equals гора.ID_Горы
                            group альпинист by new
                            {
                                ID = альпинист.ID_Альпиниста,
                                Фамилия = альпинист.Фамилия_альпиниста,
                                Имя = альпинист.Имя_альпиниста,
                                Отчество = альпинист.Отчество_альпиниста
                            } into g
                            orderby g.Count() descending
                            select new
                            {
                                ID = g.Key.ID,
                                Фамилия = g.Key.Фамилия,
                                Имя = g.Key.Имя,
                                Отчество = g.Key.Отчество,
                                Восхождения = g.Count()
                            };

                resultGrid.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void query3_Click(object sender, RoutedEventArgs e)
        {
            var context = new chronichlesEntities();
            try
            {
                var query = from гора in context.Горы
                            join восхождение in context.Восхождения on гора.ID_Горы equals восхождение.ID_Горы
                            join группа in context.Группы on восхождение.ID_Группы equals группа.ID_Группы
                            join альпинистВГруппе in context.Альпинисты_в_группах on группа.ID_Группы equals альпинистВГруппе.ID_Группы
                            join альпинист in context.Альпинисты on альпинистВГруппе.ID_Альпиниста equals альпинист.ID_Альпиниста
                            group восхождение by new
                            {
                                Страна = гора.Страна,
                                Пол = альпинист.Пол
                            } into g
                            orderby g.Key.Страна, g.Key.Пол
                            select new
                            {
                                Страна = g.Key.Страна,
                                Пол = g.Key.Пол,
                                Средняя__длительность__восхождений = Math.Round((double)g.Average(в => в.Длительность), 2)
                            };

                resultGrid.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void query4_Click(object sender, RoutedEventArgs e)
        {
            var context = new chronichlesEntities();
            try
            {
                var query = from гора in context.Горы
                            where гора.Высота > 5000
                            group гора by гора.Страна into g
                            select new
                            {
                                Страна = g.Key,
                                Количество__гор = g.Count(),
                                Общая__высота = g.Sum(г => г.Высота)
                            };

                resultGrid.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void query5_Click(object sender, RoutedEventArgs e)
        {
            var context = new chronichlesEntities();
            try
            {
                var query = from гора in context.Горы
                            join восхождение in context.Восхождения on гора.ID_Горы equals восхождение.ID_Горы
                            join альпинистыВГруппах in context.Альпинисты_в_группах on восхождение.ID_Группы equals альпинистыВГруппах.ID_Группы
                            join альпинист in context.Альпинисты on альпинистыВГруппах.ID_Альпиниста equals альпинист.ID_Альпиниста
                            orderby альпинистыВГруппах.Дата_начала_возхождения
                            select new
                            {
                                ID__Группы = альпинистыВГруппах.ID_Группы,
                                ID__Альпиниста = альпинист.ID_Альпиниста,
                                Название__горы = гора.Название,
                                Имя__альпиниста = альпинист.Имя_альпиниста,
                                Фамилия__альпиниста = альпинист.Фамилия_альпиниста,
                                Дата__начала__восхождения = DbFunctions.TruncateTime(альпинистыВГруппах.Дата_начала_возхождения)
                            };

                resultGrid.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void query6_Click(object sender, RoutedEventArgs e)
        {
            var context = new chronichlesEntities();
            try
            {
                var query = from гора in context.Горы
                            join восхождение in context.Восхождения on гора.ID_Горы equals восхождение.ID_Горы
                            group восхождение by new
                            {
                                Название_Горы = гора.Название,
                                ID__Горы = гора.ID_Горы
                            } into g
                            orderby g.Count() descending
                            select new
                            {
                                Название__Горы = g.Key.Название_Горы,
                                Количество__восхождений = g.Count()
                            };

                resultGrid.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void query7_Click(object sender, RoutedEventArgs e)
        {
            var context = new chronichlesEntities();
            try
            {
                var query = from альпинист in context.Альпинисты
                            orderby альпинист.Фамилия_альпиниста
                            select new
                            {
                                ID__Альпиниста = альпинист.ID_Альпиниста,
                                Фамилия__альпиниста = альпинист.Фамилия_альпиниста,
                                Имя__альпиниста = альпинист.Имя_альпиниста,
                                Отчество__альпиниста = альпинист.Отчество_альпиниста
                            };

                resultGrid.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void query8_Click(object sender, RoutedEventArgs e)
        {
            var context = new chronichlesEntities();
            try
            {
                var subquery = from альпинистВГруппах in context.Альпинисты_в_группах
                               select альпинистВГруппах.ID_Альпиниста;

                var query = from альпинист in context.Альпинисты
                            where !subquery.Contains(альпинист.ID_Альпиниста)
                            select new
                            {
                                ID__Альпиниста = альпинист.ID_Альпиниста,
                                Фамилия__альпиниста = альпинист.Фамилия_альпиниста,
                                Имя__альпиниста = альпинист.Имя_альпиниста,
                                Отчество__альпиниста = альпинист.Отчество_альпиниста
                            };

                resultGrid.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

        }

        private void query9_Click(object sender, RoutedEventArgs e)
        {
            var context = new chronichlesEntities();
            try
            {
                var query = from гора in context.Горы
                            join восхождение in context.Восхождения on гора.ID_Горы equals восхождение.ID_Горы into climbs
                            from climb in climbs.DefaultIfEmpty()
                            group climb by гора.Страна into g
                            select new
                            {
                                Страна = g.Key,
                                Количество__всех__восхождений = g.Count(),
                                Количество__успешных__восхождений = g.Count(c => c != null && c.Успешность == "Успех"),
                                Количество__неуспешных__восхождений = g.Count(c => c != null && c.Успешность == "Неуспех")
                            };

                resultGrid.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void query10_Click(object sender, RoutedEventArgs e)
        {
            var context = new chronichlesEntities();
            try
            {
                var query = from альпинист in context.Альпинисты
                            join альпинистВГруппах in context.Альпинисты_в_группах on альпинист.ID_Альпиниста equals альпинистВГруппах.ID_Альпиниста
                            join восхождение in context.Восхождения on альпинистВГруппах.ID_Группы equals восхождение.ID_Группы
                            group альпинист by new { альпинист.ID_Альпиниста, альпинист.Фамилия_альпиниста, альпинист.Имя_альпиниста } into g
                            orderby g.Count() descending
                            select new
                            {
                                ID__Альпиниста = g.Key.ID_Альпиниста,
                                Фамилия__альпиниста = g.Key.Фамилия_альпиниста,
                                Имя__альпиниста = g.Key.Имя_альпиниста,
                                Количество__восхождений = g.Count()
                            };

                resultGrid.ItemsSource = query.Take(5).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnView1_Click(object sender, RoutedEventArgs e)
        {
            var context = new chronichlesEntities();
            try
            {
                var successfulAscents = from ascent in context.Восхождения
                                        where ascent.Успешность == "Успех"
                                        select ascent;

                var query = from successfulAscent in successfulAscents
                            join mountain in context.Горы on successfulAscent.ID_Горы equals mountain.ID_Горы
                            select new
                            {
                                ID__Горы = successfulAscent.ID_Горы,
                                ID__Группы = successfulAscent.ID_Группы,
                                Дата__Восхождения = successfulAscent.Дата_Возхождения,
                                Успешность = successfulAscent.Успешность,
                                Длительность = successfulAscent.Длительность,
                                Количество__вошедших = successfulAscent.Количество_вошедших,
                                Название__горы = mountain.Название,
                                Высота = mountain.Высота,
                                Страна = mountain.Страна
                            };

                ViewGrid.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnView2_Click(object sender, RoutedEventArgs e)
        {
            var context = new chronichlesEntities();
            try
            {
                var query = from альпинист in context.Альпинисты
                            join альпинистВГруппах in context.Альпинисты_в_группах on альпинист.ID_Альпиниста equals альпинистВГруппах.ID_Альпиниста
                            join группа in context.Группы on альпинистВГруппах.ID_Группы equals группа.ID_Группы
                            join восхождение in context.Восхождения on группа.ID_Группы equals восхождение.ID_Группы
                            join гора in context.Горы on восхождение.ID_Горы equals гора.ID_Горы
                            group альпинист by new
                            {
                                альпинист.ID_Альпиниста,
                                альпинист.Фамилия_альпиниста,
                                альпинист.Имя_альпиниста,
                                альпинист.Отчество_альпиниста
                            } into g
                            select new
                            {
                                ID__Альпиниста = g.Key.ID_Альпиниста,
                                Фамилия__альпиниста = g.Key.Фамилия_альпиниста,
                                Имя__альпиниста = g.Key.Имя_альпиниста,
                                Отчество__альпиниста = g.Key.Отчество_альпиниста,
                                Количество__восхождений = g.Count()
                            };

                ViewGrid.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnView3_Click(object sender, RoutedEventArgs e)
        {
            var context = new chronichlesEntities();
            try
            {
                var query = from гора in context.Горы
                            join восхождение in context.Восхождения on гора.ID_Горы equals восхождение.ID_Горы
                            group гора by new
                            {
                                гора.ID_Горы,
                                гора.Название
                            } into g
                            select new
                            {
                                ID__Горы = g.Key.ID_Горы,
                                Название__Горы = g.Key.Название,
                                Количество__восхождений = g.Count()
                            };

                ViewGrid.ItemsSource = query.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnView4_Click(object sender, RoutedEventArgs e)
        {
            var context = new chronichlesEntities();
            try
            {
                var query = from гора in context.Горы
                            join восхождение in context.Восхождения on гора.ID_Горы equals восхождение.ID_Горы
                            join группа in context.Группы on восхождение.ID_Группы equals группа.ID_Группы
                            join альпинистВГруппе in context.Альпинисты_в_группах on группа.ID_Группы equals альпинистВГруппе.ID_Группы
                            join альпинист in context.Альпинисты on альпинистВГруппе.ID_Альпиниста equals альпинист.ID_Альпиниста
                            group восхождение by new
                            {
                                Страна = гора.Страна,
                                Пол = альпинист.Пол
                            } into g
                            orderby g.Key.Страна, g.Key.Пол
                            select new
                            {
                                Страна = g.Key.Страна,
                                Пол = g.Key.Пол,
                                Средняя__длительность__восхождений = Math.Round((double)g.Average(в => в.Длительность), 2)
                            };


                ViewGrid.ItemsSource = query.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnView5_Click(object sender, RoutedEventArgs e)
        {
            var context = new chronichlesEntities();
            try
            {
                var query = from гора in context.Горы
                            where гора.Высота > 5000
                            group гора by гора.Страна into g
                            select new
                            {
                                Страна = g.Key,
                                Количество__гор = g.Count(),
                                Общая__высота = g.Sum(x => x.Высота)
                            };

                ViewGrid.ItemsSource = query.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
