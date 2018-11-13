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

namespace SoftwareProject
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=ALEXANTHONYA945\SQLEXPRESS; Initial Catalog=LoginDB; Integrated Security=True");
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                    String query = "SELECT COUNT(1) FROM tblUser WHERE Username=@Username AND PASSWORD=@Password";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (count == 1)
                    {
                        StudentDashboard studentDashboard= new StudentDashboard();
                        studentDashboard.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Name or Password is incorrect");
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
