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
    /// Логика взаимодействия для AddEditPageTable4.xaml
    /// </summary>
    public partial class AddEditPageTable4 : Page
    {
        private Группы _currentAlpinist = new Группы();
        public AddEditPageTable4(Группы selectedAlpinist)
        {
            InitializeComponent();
            if (selectedAlpinist != null)
            {
                _currentAlpinist = selectedAlpinist;
            }

            DataContext = _currentAlpinist;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentAlpinist.Количество <= 0)
            {
                errors.AppendLine("Укажите корректное значение для ID Горы!");
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
