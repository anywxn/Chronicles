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
    /// Логика взаимодействия для AddEditPageTable2.xaml
    /// </summary>
    public partial class AddEditPageTable2 : Page
    {

        private Горы _currentAlpinist = new Горы();

        public AddEditPageTable2(Горы selectedAlpinist)
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

            if (string.IsNullOrWhiteSpace(_currentAlpinist.Название))
                errors.AppendLine("Укажите название горы!");

            if (_currentAlpinist.Высота == null)
                errors.AppendLine("Укажите высоту горы!");

            if (string.IsNullOrWhiteSpace(_currentAlpinist.Страна))
                errors.AppendLine("Укажите страну горы!");

           

            if (errors.Length != 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentAlpinist.ID_Горы == 0)
                chronichlesEntities.GetContext().Горы.Add(_currentAlpinist);

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
