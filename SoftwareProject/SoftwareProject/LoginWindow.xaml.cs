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
using System.Data.Common;
using System.Configuration;

namespace SoftwareProject
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private const string ConnectionString = @"Data Source=ALEXANTHONYA945\SQLEXPRESS; Initial Catalog=LoginDB; Integrated Security=True";
        private const string queryString = "SELECT COUNT(1) FROM UserTable WHERE Username=@Username AND Password=@Password";

        public LoginWindow()
        {
            //Data Source=DESKTOP-D6AP9T9;Initial Catalog=LoginDB;Integrated Security=True;Pooling=False
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                    string query = queryString;
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (count == 1)
                    {

                        MessageBox.Show("Welcome");
                        StudentDashboard student1 = new StudentDashboard();
                        student1.Show();
                        this.Close();
                       // ProfessorDashboard prof1 = new ProfessorDashboard();
                       // prof1.Show();
                       // this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Name or Password is incorrect");
                        ProfessorDashboard prof1 = new ProfessorDashboard();
                        prof1.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
