using Npgsql;
using System;
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
    /// Логика взаимодействия для TeacherMainWindow.xaml
    /// </summary>
    public partial class TeacherMainWindow : Window
    {
        #region Variables

        /// <summary>
        /// Логин преподавателя, вошедшего в систему
        /// </summary>
        string login;

        /// <summary>
        /// Пароль преподавателя, вошедшего в систему
        /// </summary>
        string password;

        /// <summary>
        /// Страница информации о преподавателе
        /// </summary>
        readonly TeacherInfoPage teacherInfoPage = new();

        /// <summary>
        /// Страница списка учеников
        /// </summary>
        readonly TeacherStudentsPage teacherStudentsPage = new();

        /// <summary>
        /// Страница добавления задания
        /// </summary>
        readonly TeacherAddPage teacherAddPage = new();

        /// <summary>
        /// Страница списка заданий
        /// </summary>
        readonly TeacherTasksPage teacherTasksPage = new();

        #endregion


        #region Initialization


        /// <summary>
        /// Инициализация компонента TeacherMainWindow
        /// </summary>
        public TeacherMainWindow()
        {
            GetUserData();

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

        #endregion


        #region Buttons


        /// <summary>
        /// Отобразить страницу информации о пользователе
        /// </summary>
        public void ShowInfoTeacher(object sender, RoutedEventArgs e)
        {
            NpgsqlConnection connection = new($"Server=127.0.0.1;User Id={login.ToLower()};Password={password};Database=school;");
            connection.Open();

            string query = $"SELECT * FROM get_teacher_info('{login}');";

            NpgsqlCommand command = new(query, connection);

            NpgsqlDataReader dataReader = command.ExecuteReader();

            dataReader.Read();

            teacherInfoPage.teacherinfopage_login_label.Content = dataReader[0].ToString();
            teacherInfoPage.teacherinfopage_name_label.Content = dataReader[1].ToString();
            teacherInfoPage.teacherinfopage_surname_label.Content = dataReader[2].ToString();
            teacherInfoPage.teacherinfopage_phone_label.Content = dataReader[3].ToString();
            teacherInfoPage.teacherinfopage_email_label.Content = dataReader[4].ToString();

            teachermainwindow_save_new_task_button.Visibility = Visibility.Hidden;

            teachermainwindow_main_frame.Navigate(teacherInfoPage);

            connection.Close();
        }

        /// <summary>
        /// Отобразить список учеников
        /// </summary>
        public void ShowStudentsList(object sender, RoutedEventArgs e)
        {

            NpgsqlConnection connection = new($"Server=127.0.0.1;User Id={login.ToLower()};Password={password};Database=school;");
            connection.Open();

            string query = $"SELECT * FROM get_all_students_info();";

            NpgsqlCommand command = new(query, connection);

            using NpgsqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string studentLogin = dataReader.GetString(0);
                string studentName = dataReader.GetString(1);
                string studentSurname = dataReader.GetString(2);
                string studentPhone = dataReader.GetString(3);
                string studentEmail = dataReader.GetString(4);
                int studentRating = dataReader.GetInt32(5);
                int studentSolved = dataReader.GetInt32(6);
                int studentMistakes = dataReader.GetInt32(7);

                Border studentInfoBorder = new()
                {
                    CornerRadius = new CornerRadius(6),
                    BorderBrush = Brushes.Blue,
                    BorderThickness = new Thickness(1),
                };

                StackPanel studentInfoStackPanel= new()
                {
                    Orientation = Orientation.Horizontal,
                };

                StackPanel loginNameSurname = new()
                {
                    Orientation = Orientation.Vertical,
                };

                StackPanel phoneEmail = new()
                {
                    Orientation = Orientation.Vertical,
                };

                StackPanel ratingSolvedMistakes = new()
                {
                    Orientation = Orientation.Vertical,
                };

                Label loginLabel = new()
                {
                    FontFamily = new FontFamily("Franklin Gothic Medium"),
                    Foreground = Brushes.White,
                    FontSize = 14,
                    Content = studentLogin
                };

                Label nameLabel = new()
                {
                    FontFamily = new FontFamily("Franklin Gothic Medium"),
                    Foreground = Brushes.White,
                    FontSize = 14,
                    Content = studentName
                };

                Label surnameLabel = new()
                {
                    FontFamily = new FontFamily("Franklin Gothic Medium"),
                    Foreground = Brushes.White,
                    FontSize = 14,
                    Content = studentSurname
                };

                Label phoneLabel = new()
                {
                    FontFamily = new FontFamily("Franklin Gothic Medium"),
                    Foreground = Brushes.White,
                    FontSize = 14,
                    Content = studentPhone
                };

                Label emailLabel = new()
                {
                    FontFamily = new FontFamily("Franklin Gothic Medium"),
                    Foreground = Brushes.White,
                    FontSize = 14,
                    Content = studentEmail
                };

                Label ratingLabel = new()
                {
                    FontFamily = new FontFamily("Franklin Gothic Medium"),
                    Foreground = Brushes.White,
                    FontSize = 14,
                    Content = "Рейтинг: " + studentRating
                };

                Label solvedLabel = new()
                {
                    FontFamily = new FontFamily("Franklin Gothic Medium"),
                    Foreground = Brushes.White,
                    FontSize = 14,
                    Content = "Решено: " + studentSolved
                };

                Label mistakesLabel = new()
                {
                    FontFamily = new FontFamily("Franklin Gothic Medium"),
                    Foreground = Brushes.White,
                    FontSize = 14,
                    Content = "Ошибок: " + studentMistakes
                };

                loginNameSurname.Children.Add(loginLabel);
                loginNameSurname.Children.Add(nameLabel);
                loginNameSurname.Children.Add(surnameLabel);
                phoneEmail.Children.Add(phoneLabel);
                phoneEmail.Children.Add(emailLabel);
                ratingSolvedMistakes.Children.Add(ratingLabel);
                ratingSolvedMistakes.Children.Add(solvedLabel);
                ratingSolvedMistakes.Children.Add(mistakesLabel);

                studentInfoStackPanel.Children.Add(loginNameSurname);
                studentInfoStackPanel.Children.Add(phoneEmail);
                studentInfoStackPanel.Children.Add(ratingSolvedMistakes);

                studentInfoBorder.Child = studentInfoStackPanel;

                teachermainwindow_save_new_task_button.Visibility = Visibility.Hidden;

                teacherStudentsPage.teacherstudentspage_students_stackpanel.Children.Add(studentInfoBorder);
            }

            teachermainwindow_main_frame.Navigate(teacherStudentsPage);

            connection.Close();
        }

        /// <summary>
        /// Отобразить список заданий
        /// </summary>
        public void ShowTaskList(object sender, RoutedEventArgs e)
        {
            teacherTasksPage.teachertaskspage_tasks_stackpanel.Children.Clear();

            NpgsqlConnection connection = new($"Server=127.0.0.1;User Id={login.ToLower()};Password={password};Database=school;");
            connection.Open();

            string query = $"SELECT * FROM get_all_tasks_info();";

            NpgsqlCommand command = new(query, connection);

            using NpgsqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                int taskId = dataReader.GetInt32(0);
                string taskText = dataReader.GetString(1);
                string taskPicture = dataReader.GetString(2);
                string taskAnswer = dataReader.GetString(3);
                int taskSubtheme = dataReader.GetInt32(4);
                int taskSolutionId = dataReader.GetInt32(5);
                int taskDifficulty = dataReader.GetInt32(6);
                int solutionId = dataReader.GetInt32(7);
                string solutionText = dataReader.GetString(8);
                string solutionPicture = dataReader.GetString(9);

                Border taskInfoBorder = new()
                {
                    CornerRadius = new CornerRadius(6),
                    BorderBrush = Brushes.Blue,
                    BorderThickness = new Thickness(1),
                };

                StackPanel taskInfoStackPanel = new()
                {
                    Orientation = Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };

                TextBlock taskIdTextblock = new()
                {
                    FontFamily = new FontFamily("Franklin Gothic Medium"),
                    Foreground = Brushes.Red,
                    FontSize = 18,
                    TextWrapping = TextWrapping.Wrap,
                    Text = "ID: " + taskId,
                };

                TextBlock taskTextTextblock = new()
                {
                    FontFamily = new FontFamily("Franklin Gothic Medium"),
                    Foreground = Brushes.White,
                    FontSize = 14,
                    TextWrapping = TextWrapping.Wrap,
                    Text = "Задание: " + taskText,
                    Width = 800,
                };

                TextBlock solutionTextTextblock = new()
                {
                    FontFamily = new FontFamily("Franklin Gothic Medium"),
                    Foreground = Brushes.Yellow,
                    FontSize = 14,
                    TextWrapping = TextWrapping.Wrap,
                    Text = "Решение: " + solutionText,
                    Width = 800,
                };

                TextBlock answerTextblock = new()
                {
                    FontFamily = new FontFamily("Franklin Gothic Medium"),
                    Foreground = Brushes.Yellow,
                    FontSize = 18,
                    TextWrapping = TextWrapping.Wrap,
                    Text = "Ответ: " + taskAnswer,
                };

                TextBlock subthemeTextblock = new()
                {
                    FontFamily = new FontFamily("Franklin Gothic Medium"),
                    Foreground = Brushes.White,
                    FontSize = 18,
                    TextWrapping = TextWrapping.Wrap,
                    Text = "ID подтемы: " + taskSubtheme,
                };

                taskInfoStackPanel.Children.Add(taskIdTextblock);
                taskInfoStackPanel.Children.Add(taskTextTextblock);
                taskInfoStackPanel.Children.Add(solutionTextTextblock);
                taskInfoStackPanel.Children.Add(answerTextblock);
                taskInfoStackPanel.Children.Add(subthemeTextblock);

                taskInfoBorder.Child = taskInfoStackPanel;

                teacherTasksPage.teachertaskspage_tasks_stackpanel.Children.Add(taskInfoBorder);
            }

            connection.Close();

            teachermainwindow_save_new_task_button.Visibility = Visibility.Hidden;

            teachermainwindow_main_frame.Navigate(teacherTasksPage);
        }

        /// <summary>
        /// Отобразить страницу создания задания
        /// </summary>
        public void ShowTaskAdding(object sender, RoutedEventArgs e)
        {
            NpgsqlConnection connection = new($"Server=127.0.0.1;User Id={login.ToLower()};Password={password};Database=school;");
            connection.Open();

            string query = $"SELECT * FROM get_themes();";

            NpgsqlCommand command = new(query, connection);

            NpgsqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                int themeId = dataReader.GetInt32(0) - 1;
                int themeNumber = dataReader.GetInt32(0);
                string themeName = dataReader.GetString(1);

                teacherAddPage.teacheraddpage_theme_combobox.Items.Insert(themeId, themeNumber + " " + themeName);
            }

            dataReader.Close();

            query = $"SELECT * FROM get_subthemes();";

            command = new(query, connection);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                int subthemeId = dataReader.GetInt32(0) - 1;
                string subthemeName = dataReader.GetInt32(2).ToString() + " " + dataReader.GetString(1);

                teacherAddPage.teacheraddpage_subtheme_combobox.Items.Insert(subthemeId, subthemeName);
            }

            dataReader.Close();

            query = $"SELECT * FROM get_difficulties();";

            command = new(query, connection);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                int difficultyId = dataReader.GetInt32(0) - 1;
                string difficultyName = dataReader.GetString(1);

                teacherAddPage.teacheraddpage_difficulty_combobox.Items.Insert(difficultyId, difficultyName);
            }

            dataReader.Close();

            teachermainwindow_save_new_task_button.Visibility = Visibility.Visible;

            teachermainwindow_main_frame.Navigate(teacherAddPage);
        }

        /// <summary>
        /// Сохранить задание
        /// </summary>
        public void SaveNewTask(object sender, RoutedEventArgs e)
        {
            string taskText = teacherAddPage.teacheraddpage_task_textbox.Text;
            string answer = teacherAddPage.teacheraddpage_answer_textbox.Text;
            int difficulty = teacherAddPage.teacheraddpage_difficulty_combobox.SelectedIndex + 1;
            string solutionText = teacherAddPage.teacheraddpage_solution_textbox.Text;
            int theme = teacherAddPage.teacheraddpage_theme_combobox.SelectedIndex + 1;
            int subtheme = teacherAddPage.teacheraddpage_subtheme_combobox.SelectedIndex + 1;
            string taskPic = (bool)teacherAddPage.teacheraddpage_image_task_checkbox.IsChecked ? "TRUE" : "FALSE";
            string solutionPic = (bool)teacherAddPage.teacheraddpage_image_solution_checkbox.IsChecked ? "TRUE" : "FALSE";

            NpgsqlConnection connection = new($"Server=127.0.0.1;User Id={login.ToLower()};Password={password};Database=school;");
            connection.Open();

            string query = $"CALL add_task('{taskText}', {taskPic}, '{answer}', {theme}, {subtheme}, '{solutionText}', {solutionPic}, {difficulty});";

            NpgsqlCommand command = new(query, connection);

            command.ExecuteNonQuery();

            connection.Close();

            teachermainwindow_main_frame.NavigationService.RemoveBackEntry();

            teachermainwindow_save_new_task_button.Visibility = Visibility.Hidden;
        }

        #endregion
    }
}
