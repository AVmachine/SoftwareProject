using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace SoftwareProject
{
    /// <summary>
    /// Interaction logic for StudentDashboard.xaml
    /// </summary>
    public partial class StudentDashboard : Window
    {
        private const string ConnectionString = @"Data Source=LTEA\SQLEXPRESS ; Initial Catalog=LoginDb; Integrated Security=True";
        SqlConnection sqlCon = new SqlConnection(ConnectionString);

        public StudentDashboard()
        {

            InitializeComponent();
            Fillcombo();

        }

        public void display_Exams()
        {
            sqlCon.Open();
            SqlCommand sqlCmd = sqlCon.CreateCommand();
            string query = "SELECT Exams,Grades FROM Students WHERE Student = 'Alex' AND Courses = 'Math'";
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = query;
            sqlCmd.ExecuteNonQuery();


            DataTable dt = new DataTable("Exams");
            SqlDataAdapter dataADP = new SqlDataAdapter(sqlCmd);
            dataADP.Fill(dt);
            StudentDashboardGrid1.ItemsSource = dt.DefaultView;
            dataADP.Update(dt);
            sqlCon.Close();

        }

        public void display_Scores()
        {
            sqlCon.Open();
            SqlCommand sqlCmd = sqlCon.CreateCommand();
            string query = "SELECT AVG(Grades) FROM Students WHERE Courses = 'Math'";
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = query;
            sqlCmd.ExecuteNonQuery();


            DataTable dt = new DataTable("Exams");
            SqlDataAdapter dataADP = new SqlDataAdapter(sqlCmd);
            dataADP.Fill(dt);
            StudentDashboardGrid2.ItemsSource = dt.DefaultView;
            dataADP.Update(dt);
            sqlCon.Close();

        }

        private void DisplayButton_Click(object sender, RoutedEventArgs e)
        {
            display_Exams();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            display_Scores();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
        }

        void Fillcombo()
        {
           
                SqlCommand sqlCmd = new SqlCommand("SELECT DISTINCT Courses FROM Students WHERE Student = 'Alex'", sqlCon);
                sqlCon.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    CoursesCombo.Items.Add(sqlReader["Courses"].ToString());
                }

                sqlReader.Close();
            sqlCon.Close();

        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
                this.Hide();
                LoginWindow logout = new LoginWindow();
                logout.Show();
        }
    }
   
}
