using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для AddEditPageTable3.xaml
    /// </summary>
    public partial class AddEditPageTable3 : Page
    {
        private Восхождения _currentAlpinist = new Восхождения();
        public AddEditPageTable3(Восхождения selectedAlpinist)
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

            if (_currentAlpinist.ID_Горы <= 0)
            {
                errors.AppendLine("Укажите корректное значение для ID Горы!");
            }

            if (_currentAlpinist.ID_Группы <= 0)
            {
                errors.AppendLine("Укажите корректное значение для ID Группы!");
            }

            if (_currentAlpinist.Дата_Возхождения == null)
            {
                errors.AppendLine("Укажите корректную дату возхождения!");
            }

            // Проверка для поля "Успешность"
            if (_currentAlpinist.Успешность != "Успех" && _currentAlpinist.Успешность != "Неуспех")
            {
                errors.AppendLine("Выберите корректное значение для поля 'Успешность'! (Успех или Неуспех)");
            }

            if (_currentAlpinist.Длительность < 0)
            {
                errors.AppendLine("Укажите корректное значение для длительности!");
            }

            if (_currentAlpinist.Количество_вошедших < 0)
            {
                errors.AppendLine("Укажите корректное значение для количества вошедших!");
            }

            if (errors.Length != 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

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