using Npgsql;
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
using System.Windows.Shapes;

namespace SchoolGUI
{
    /// <summary>
    /// Логика взаимодействия для StudentMainWindow.xaml
    /// </summary>
    public partial class StudentMainWindow : Window
    {
        #region Variables

        /// <summary>
        /// Логин ученика, вошедшего в систему
        /// </summary>
        string login;

        /// <summary>
        /// Пароль ученика, вошедшего в систему
        /// </summary>
        string password;

        CustomTask lastTask;

        /// <summary>
        /// Объект генерации случайныйх чисел
        /// </summary>
        Random random = new();

        /// <summary>
        /// Список заданий для решения
        /// </summary>
        List<CustomTask> tasks = new();

        /// <summary>
        /// Список ошибок для исправления
        /// </summary>
        List<CustomTask> mistakes = new();

        /// <summary>
        /// Страница информации об ученике
        /// </summary>
        readonly StudentInfoPage studentInfoPage = new();

        /// <summary>
        /// Страница статистики ученика
        /// </summary>
        readonly StudentStatsPage studentStatsPage = new();

        /// <summary>
        /// Страница решения задач
        /// </summary>
        readonly StudentTasksPage studentTasksPage = new();

        /// <summary>
        /// Страница исправления ошибок
        /// </summary>
        readonly StudentMistakesPage studentMistakesPage = new();

        #endregion


        #region Initialization


        /// <summary>
        /// Инициализация компонента StudentMainWindow
        /// </summary>
        public StudentMainWindow()
        {
            GetUserData();

            MakeTasksList();

            MakeMistakesList();

            InitializeComponent();
        }

        /// <summary>
        /// Получение авторизационных данных текущего пользователя
        /// </summary>
        public void GetUserData()
        {
            string text = File.ReadAllText(@"UserInfo.json");
            using JsonDocument doc = JsonDocument.Parse(text);
            JsonElement root = doc.RootElement;

            login = root.GetProperty("Login").ToString();
            password = root.GetProperty("Password").ToString();
        }

        /// <summary>
        /// Формирование списка задач
        /// </summary>
        public void MakeTasksList()
        {
            List<int> chosenThemes = new();

            NpgsqlConnection connection = new($"Server=127.0.0.1;User Id={login.ToLower()};Password={password};Database=school;");
            connection.Open();

            string query = $"SELECT * FROM get_chosen_themes('{login}');";

            NpgsqlCommand command = new(query, connection);

            NpgsqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                chosenThemes.Add(dataReader.GetInt32(1));
            }

            dataReader.Close();

            foreach (int themeId in chosenThemes)
            {
                query = $"SELECT * FROM get_theme_tasks_info({themeId});";

                command = new(query, connection);

                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    tasks.Add(new CustomTask(dataReader.GetInt32(0),
                                             dataReader.GetString(1),
                                             dataReader.GetString(2),
                                             dataReader.GetString(3),
                                             dataReader.GetInt32(4),
                                             dataReader.GetInt32(5),
                                             dataReader.GetInt32(6),
                                             dataReader.GetInt32(7),
                                             dataReader.GetString(8),
                                             dataReader.GetString(9)));
                }

                dataReader.Close();
            }
        }

        /// <summary>
        /// Формирование списка ошибок
        /// </summary>
        public void MakeMistakesList()
        {
            NpgsqlConnection connection = new($"Server=127.0.0.1;User Id={login.ToLower()};Password={password};Database=school;");
            connection.Open();

            foreach(CustomTask task in tasks)
            {
                string query = $"SELECT is_mistake('{login}', {task.Id});";

                NpgsqlCommand command = new(query, connection);

                NpgsqlDataReader dataReader = command.ExecuteReader();

                dataReader.Read();

                if ((bool)dataReader[0])
                {
                    mistakes.Add(task);
                }

                dataReader.Close();
            }

            connection.Close();
        }

        #endregion


        #region Buttons

        /// <summary>
        /// Отобразить персональную информацию ученика
        /// </summary>
        public void ShowInfoStudent(object sender, RoutedEventArgs e)
        {
            NpgsqlConnection connection = new($"Server=127.0.0.1;User Id={login.ToLower()};Password={password};Database=school;");
            connection.Open();

            string query = $"SELECT * FROM get_student_info('{login}');";

            NpgsqlCommand command = new(query, connection);

            NpgsqlDataReader dataReader = command.ExecuteReader();

            dataReader.Read();

            studentInfoPage.studentinfopage_login_label.Content = dataReader[0].ToString();
            studentInfoPage.studentinfopage_name_label.Content = dataReader[1].ToString();
            studentInfoPage.studentinfopage_surname_label.Content = dataReader[2].ToString();
            studentInfoPage.studentinfopage_phone_label.Content = dataReader[3].ToString();
            studentInfoPage.studentinfopage_email_label.Content = dataReader[4].ToString();

            studentmainwindow_check_mistake_button.Visibility = Visibility.Hidden;
            studentmainwindow_check_button.Visibility = Visibility.Hidden;

            studentmainwindow_main_frame.Navigate(studentInfoPage);
            
            connection.Close();
        }

        /// <summary>
        /// Отобразить статистику ученика
        /// </summary>
        public void ShowStatsStudent(object sender, RoutedEventArgs e)
        {
            NpgsqlConnection connection = new($"Server=127.0.0.1;User Id={login.ToLower()};Password={password};Database=school;");
            connection.Open();

            string query = $"SELECT * FROM get_student_info('{login}');";

            NpgsqlCommand command = new(query, connection);

            NpgsqlDataReader dataReader = command.ExecuteReader();

            dataReader.Read();

            studentStatsPage.studentstatspage_rating_label.Content = dataReader[5].ToString();
            studentStatsPage.studentstatspage_solved_label.Content= dataReader[6].ToString();
            studentStatsPage.studentstatspage_mistakes_labdel.Content = dataReader[7].ToString();

            studentmainwindow_check_mistake_button.Visibility = Visibility.Hidden;
            studentmainwindow_check_button.Visibility = Visibility.Hidden;

            studentmainwindow_main_frame.Navigate(studentStatsPage);

            connection.Close();
        }

        /// <summary>
        /// Отобразить решение задач
        /// </summary>
        public void ShowTasksStudent(object sender, RoutedEventArgs e)
        {
            CustomTask currentTask = tasks[random.Next(0, tasks.Count)];

            lastTask = currentTask;

            studentTasksPage.studenttaskspage_task_textblock.Text = currentTask.TaskText;
            studentTasksPage.studenttaskspage_task_image.Source = new BitmapImage(new Uri(currentTask.TaskPicture, UriKind.Relative));

            studentmainwindow_check_mistake_button.Visibility = Visibility.Hidden;
            studentmainwindow_check_button.Visibility = Visibility.Visible;

            studentmainwindow_main_frame.Navigate(studentTasksPage);
        }

        /// <summary>
        /// Отобразить исправление ошибок
        /// </summary>
        public void ShowMistakesStudent(object sender, RoutedEventArgs e)
        {
            CustomTask currentTask = mistakes[mistakes.Count - 1];

            lastTask = currentTask;

            studentMistakesPage.studentmistakespage_task_textblock.Text = currentTask.TaskText;
            studentMistakesPage.studentmistakespage_task_image.Source = new BitmapImage(new Uri(currentTask.TaskPicture, UriKind.Relative));

            studentmainwindow_check_button.Visibility = Visibility.Hidden;
            studentmainwindow_check_mistake_button.Visibility = Visibility.Visible;

            studentmainwindow_main_frame.Navigate(studentMistakesPage);
        }

        /// <summary>
        /// Проверить текущую задачу на правильность
        /// </summary>
        public void CheckCurrentTask(object sender, RoutedEventArgs e) 
        {
            NpgsqlConnection connection = new($"Server=127.0.0.1;User Id={login.ToLower()};Password={password};Database=school;");
            connection.Open();

            string answer = studentTasksPage.studenttaskspage_answer_texbox.Text;

            string query = $"SELECT check_task('{login}', {lastTask.Id}, '{answer}');";

            NpgsqlCommand command = new(query, connection);

            NpgsqlDataReader dataReader = command.ExecuteReader();

            dataReader.Read();

            if ((bool)dataReader[0])
            {
                MessageBox.Show("Верно!");
            }
            else
            {
                MessageBox.Show("Неверно!");
            }

            studentTasksPage.studenttaskspage_answer_texbox.Clear();

            CustomTask currentTask = tasks[random.Next(0, tasks.Count)];
            lastTask = currentTask;

            studentTasksPage.studenttaskspage_task_textblock.Text = currentTask.TaskText;
            studentTasksPage.studenttaskspage_task_image.Source = new BitmapImage(new Uri(currentTask.TaskPicture, UriKind.Relative));

            //studentmainwindow_check_button.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Проверить текущую исправляемую
        /// </summary>
        public void CheckCurrentMistake(object sender, RoutedEventArgs e)
        {
            NpgsqlConnection connection = new($"Server=127.0.0.1;User Id={login.ToLower()};Password={password};Database=school;");
            connection.Open();

            string answer = studentMistakesPage.studentmistakespage_answer_texbox.Text;

            string query = $"SELECT check_task('{login}', {lastTask.Id}, '{answer}');";

            NpgsqlCommand command = new(query, connection);

            NpgsqlDataReader dataReader = command.ExecuteReader();

            dataReader.Read();

            if ((bool)dataReader[0])
            {
                MakeMistakesList();

                MessageBox.Show("Верно!");
            }
            else
            {
                MakeMistakesList();

                MessageBox.Show("Неверно!");
            }

            studentMistakesPage.studentmistakespage_answer_texbox.Clear();

            CustomTask currentTask = mistakes[mistakes.Count - 1];
            lastTask = currentTask;

            studentMistakesPage.studentmistakespage_task_textblock.Text = currentTask.TaskText;
            studentMistakesPage.studentmistakespage_task_image.Source = new BitmapImage(new Uri(currentTask.TaskPicture, UriKind.Relative));

            //studentmainwindow_check_mistake_button.Visibility = Visibility.Visible;
        }



        #endregion
    }
}
