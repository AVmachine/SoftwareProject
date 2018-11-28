using System;
using System.Collections.Generic;
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
using System.Data;

namespace SoftwareProject
{
    /// <summary>
    /// Interaction logic for AddCourses.xaml
    /// </summary>
    public partial class Stu_AddCourses : Window
    {
        private const string ConnectionString = @"Data Source=LTEA\SQLEXPRESS ; Initial Catalog=LoginDb; Integrated Security=True";
        SqlConnection sqlCon = new SqlConnection(ConnectionString);
        public Stu_AddCourses()
        {
            InitializeComponent();
        }

        private void Load_table_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    display_data();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow logout = new LoginWindow();
            logout.Show();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();

                    SqlCommand sqlCmd = sqlCon.CreateCommand();
                    string query = "insert into StudentCourses values('" + IDTextBox.Text + "','" + CourseIDTextBox.Text + "')";
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = query;
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                    display_data();

                    MessageBox.Show("Courses Added Succesfully");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();

                    SqlCommand sqlCmd = sqlCon.CreateCommand();
                    string query = "Delete FROM StudentCourses WHERE CourseID = ('" + CourseIDTextBox.Text + "')";
                    //sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = query;
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                    display_data();

                    MessageBox.Show("Course Removed Succesfully");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = sqlCon.CreateCommand();
                    string query = "UPDATE StudentCourses SET StudentID = '" + IDTextBox.Text + "', CourseID ='" + this.CourseIDTextBox.Text + "', CourseName ='" +
                    "' where CourseID = '" + CourseIDTextBox.Text + "'";
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = query;
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                    display_data();

                    MessageBox.Show("Updated");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                sqlCon.Close();
                display_data();
            }
        }


        public void display_data()
        {
            sqlCon.Open();
            SqlCommand sqlCmd = sqlCon.CreateCommand();
            string query = "select * from StudentCourses";
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = query;
            sqlCmd.ExecuteNonQuery();

            
            DataTable dt = new DataTable("StudentCourses");
            SqlDataAdapter dataADP = new SqlDataAdapter(sqlCmd);
            dataADP.Fill(dt);
            Stu_AddCourses1.ItemsSource = dt.DefaultView;
            dataADP.Update(dt);
            sqlCon.Close();

        }

        private void Stu_AddCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }


}