using Npgsql;
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
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;

namespace SchoolGUI
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        #region Initialization

        public RegisterWindow()
        {
            InitializeComponent();

            FillThemesList();
        }

        #endregion


        #region Buttons

        public void RegisterRegisterWindowClick(object sender, RoutedEventArgs e)
        {
            string login = registerwindow_login_textbox.Text;
            string password = registerwindow_password_passwordbox.Password;
            string password2 = registerwindow_password2_passwordbox.Password;
            string name = registerwindow_name_textbox.Text;
            string surname = registerwindow_surname_textbox.Text;
            string phone = "+7" + registerwindow_phone_textbox.Text; ;
            string email = registerwindow_email_textbox.Text; ;
            List<int> chosenThemesList = new();
            
            foreach (CheckBox a in themes_stackpanel.Children)
            {
                if (a.IsChecked == true)
                {
                    string checkboxName = a.Name;
                 
                    int themeId = int.Parse(checkboxName.Substring(8));

                    chosenThemesList.Add(themeId);
                }
            }

            string chosen_themes = "{" + string.Join(", ", chosenThemesList.ToArray()) + "}";

            //Создаём соединение
            NpgsqlConnection connection = new NpgsqlConnection("Server=127.0.0.1;Username=auth;Password=QlHx08MAr_tT;Database=school");
            //Открываем соединение с заданными параметрами
            connection.Open();

            //Создаём запрос на выполнение функции проверки правильности введённых данных
            string query = $"SELECT is_user_exists('{login}');";
            //Создаём команду на выполнение запроса query по соединению connection
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            //Cоздаём поставщика (поток) данных для получения строк из источника данных
            NpgsqlDataReader dataReader = command.ExecuteReader();
            //Получение строки из результатов запроса
            dataReader.Read();

            //Создаём переменную значения доступа и передаём туда значение (True/False)
            var access = dataReader[0];

            //Закрываем соединение по авторизационной роли
            connection.Close();

            //Если пароли не совпадают
            if (password != password2)
            {
                registerwindow_error_label.Content = "Пароли не совпадают!";
            }
            //Если номер содержит не 12 символов
            else if (phone.Length != 12)
            {
                registerwindow_error_label.Content = "Некорректно введён номер телефона!";
            }
            //Если совпадают 
            else
            {
                //Если пользователь с введённым логином существует
                if (access.ToString() == "True")
                {
                    registerwindow_error_label.Content = "Аккаунт с указанным логином уже существует!";
                }
                else
                {
                    //Открываем соединение заново
                    connection.Open();

                    //Создаём запрос на вызов процедуры добавления сотрудника
                    query = $"CALL add_account('{login}', '{password}', '{name}', '{surname}', '{phone}', '{email}', '{chosen_themes}');";

                    //Создаём команду на выполнение запроса query по соединению connection
                    command = new(query, connection);

                    command.ExecuteNonQuery();

                    //Закрываем соединение
                    connection.Close();

                    //Перенаправляем на страницу для входа в систему
                    LogInWindow logInWindow = new();
                    logInWindow.Show();
                    Close();
                }
            }
        }

        //Переход на окно входа в систему (кнопка Войти)
        public void LogInRegisterWindowClick(object sender, RoutedEventArgs e)
        {
            LogInWindow logInWindow = new();
            logInWindow.Show();
            Close();
        }

        #endregion


        #region InputRules

        public void FillThemesList()
        {
            //Создаём соединение
            NpgsqlConnection connection = new("Server=127.0.0.1;Username=auth;Password=QlHx08MAr_tT;Database=school");
            //Открываем соединение с заданными параметрами
            connection.Open();

            //Создаём запрос на выполнение функции проверки правильности введённых данных
            string query = $"SELECT * FROM get_themes();";
            //Создаём команду на выполнение запроса query по соединению connection
            NpgsqlCommand command = new(query, connection);

            NpgsqlDataReader dataReader = command.ExecuteReader();

            StackPanel themesList = new()
            {
                Orientation = Orientation.Vertical,
                Width = 300
            };

            while (dataReader.Read())
            {
                int taskId = dataReader.GetInt32(0);
                string taskName = dataReader.GetString(1);

                CheckBox themeNameCheckBox = new()
                {
                    FontSize = 14,
                    Content = taskName,
                    Name = $"checkBox{taskId}",
                    IsChecked = false
                };

                themes_stackpanel.Children.Add(themeNameCheckBox);
      
            }

            connection.Close();
        }

        //Разрешения на использование 
        private void registerwindowEngDigAllowedSymbols(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890".IndexOf(e.Text) < 0;
        }

        private void registerwindowRuEngDigAllowedSymbols(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "ЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбюQWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890".IndexOf(e.Text) < 0;
        }

        private void registerwindowRuAllowedSymbols(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "ЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбю".IndexOf(e.Text) < 0;
        }

        private void registerwindowPhoneAllowedSymbols(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890".IndexOf(e.Text) < 0;
        }

        private void registerwindowNoEnterOrSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void registerwindowEmailAllowedSymbols(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890@!$%&*+-/=?^_{|};.".IndexOf(e.Text) < 0;
        }

        #endregion
    }
}
