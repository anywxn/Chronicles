using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddEditPageTable1.xaml
    /// </summary>
    public partial class AddEditPageTable1 : Page
    {
        private Альпинисты _currentAlpinist = new Альпинисты();
        public AddEditPageTable1(Альпинисты selectedAlpinist)
        {
            InitializeComponent();

            // Если передан объект для редактирования, используйте его
            if (selectedAlpinist != null)
            {
                _currentAlpinist = selectedAlpinist;
            }

            DataContext = _currentAlpinist;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder errors = new StringBuilder();

            if (_currentAlpinist.Имя_альпиниста == null)
                errors.AppendLine("Укажите имя альпиниста!");

            if (string.IsNullOrWhiteSpace(_currentAlpinist.Фамилия_альпиниста))
                errors.AppendLine("Укажите фамилию альпиниста!");

            if (string.IsNullOrWhiteSpace(_currentAlpinist.Отчество_альпиниста))
                errors.AppendLine("Укажите отчество альпиниста!");

            if (string.IsNullOrWhiteSpace(_currentAlpinist.Пол) || !(_currentAlpinist.Пол.Equals("М", StringComparison.OrdinalIgnoreCase) || _currentAlpinist.Пол.Equals("Ж", StringComparison.OrdinalIgnoreCase)))
            {
                errors.AppendLine("Укажите корректный пол альпиниста! (допустимы только 'М' или 'Ж')");
            }


            if (string.IsNullOrWhiteSpace(_currentAlpinist.Телефон) || !Regex.IsMatch(_currentAlpinist.Телефон.ToString(), @"^\+?\d+$"))
            {
                errors.AppendLine("Укажите верный формат телефона альпиниста! (например, +71234567890)");
            }


            if (_currentAlpinist.Адрес == null)
                errors.AppendLine("Укажите адрес альпиниста!");

            if (errors.Length != 0)
            {
                MessageBox.Show(errors.ToString());
                    return;
            }

            if (_currentAlpinist.ID_Альпиниста == 0)
                chronichlesEntities.GetContext().Альпинисты.Add(_currentAlpinist);

            try
            {
                chronichlesEntities.GetContext().SaveChanges();
                if (MessageBox.Show("Данные успешно сохранены", "Успех", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    Manager.MainFrame.GoBack();
                }
            }
            catch (DbEntityValidationException ex)
            {
                // Обработка ошибок валидации Entity Framework
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        // Вывод сообщений об ошибках в консоль (или лог)
                        Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                    }
                }

                MessageBox.Show("Произошла ошибка валидации данных. Проверьте правильность введенных данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
