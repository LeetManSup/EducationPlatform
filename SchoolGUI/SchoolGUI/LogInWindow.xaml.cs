using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using System.Xml.Linq;
using Npgsql;

namespace SchoolGUI
{
    /// <summary>
    /// Логика взаимодействия для LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        #region Initialization

        public LogInWindow()
        {
            InitializeComponent();
        }

        #endregion


        #region Helpers

        //Запись информации о пользователе в json файл
        public static string SetUserInfoJson(string login, string password)
        {
            User user = new User(login, password);
            string json = JsonSerializer.Serialize(user);
            return json;
        }

        #endregion


        #region Buttons

        //Вход в систему (кнопка Войти)
        public void LogInLoginWindowClick(object sender, RoutedEventArgs e)
        {
            //Извлекаем введённые значения логина и пароля
            string login = loginwindow_login_textbox.Text;
            string password = loginwindow_password_passwordbox.Password;

            //Создаём соединение
            NpgsqlConnection connection = new NpgsqlConnection("Server=127.0.0.1;Username=auth;Password=QlHx08MAr_tT;Database=school");
            //Открываем соединение с заданными параметрами
            connection.Open();

            //Создаём запрос на выполнение функции проверки правильности введённых данных
            string query = $"SELECT check_user('{login}', '{password}');";
            //Создаём команду на выполнение запроса query по соединению connection
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            //Cоздаём поставщика (поток) данных для получения строк из источника данных
            NpgsqlDataReader dataReader = command.ExecuteReader();
            //Получение строки из результатов запроса
            dataReader.Read();
            //Создаём переменную значения доступа и передаём туда значение (True/False)
            var access = dataReader[0];
            //Перекрываем поток данных
            dataReader.Close();

            query = $"SELECT is_teacher('{login}');";
            command = new NpgsqlCommand(query, connection);
            dataReader = command.ExecuteReader();        
            dataReader.Read();
            var isTeacher = dataReader[0];
            dataReader.Close();

            //Закрываем соединение для авторизационной роли
            connection.Close();

            //Если доступ разрешён
            if (access.ToString() == "True")
            {
                //Создаём текст Json файла с введёнными данными пользователя
                string info = SetUserInfoJson(login, password);
                //Устанавливаем путь к файлу (искать в "SchoolGUI/bin/Debug")
                string filepath = @"UserInfo.json";
                //Записываем 
                File.WriteAllText(filepath, info);

                //Если подключился преподаватель
                if (isTeacher.ToString() == "True")
                {
                    //Переходим на главное окно преподавателя
                    TeacherMainWindow teacherMainWindow = new TeacherMainWindow();
                    teacherMainWindow.Show();
                    Close();
                } 
                //Если подключился ученик
                else
                {
                    //Переходим на главное окно ученика
                    StudentMainWindow studentMainWindow = new StudentMainWindow();
                    studentMainWindow.Show();
                    Close();
                }
            }
            //Если доступ запрещён
            else
            {
                registerwindow_error_label.Content = "Введены неверные данные!";
            }
        }

        //Переход на окно регистрации (кнопка Зарегистрироваться)
        private void RegisterLogInWindowClick(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Close();
        }

        #endregion


        #region InputRules

        //Разрешения на использование 
        private void loginwindowAllowedSymbols(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890".IndexOf(e.Text) < 0;
        }

        private void loginwindowRuEngDigAllowedSymbols(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "ЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮёйцукенгшщзхъфывапролджэячсмитьбюQWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890".IndexOf(e.Text) < 0;
        }

        private void loginwindowNoEnterOrSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}
