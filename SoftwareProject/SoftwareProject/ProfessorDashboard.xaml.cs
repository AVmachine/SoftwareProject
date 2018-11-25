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
    /// Interaction logic for ProfessorDashboard.xaml
    /// </summary>
    public partial class ProfessorDashboard : Window
    {
        private const string ConnectionString = @"Data Source=ALEXANTHONYA945/SQLEXPRESS ; Initial Catalog=LoginDb; Integrated Security=True";
        SqlConnection sqlCon = new SqlConnection(ConnectionString);
        public ProfessorDashboard()
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

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();

                    SqlCommand sqlCmd = sqlCon.CreateCommand();
                    string query = "insert into StudentTable values('"+IDTextBox.Text+"','"+NameTextBox.Text+ "','"+ LastNameTextBox.Text+ "','"+IDTextBox.Text+"')";
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = query;
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                    display_data();

                    MessageBox.Show("Student Inserted Succesfully");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public void display_data()
        {
            sqlCon.Open();
            SqlCommand sqlCmd = sqlCon.CreateCommand();
            string query = "select * from StudentTable";
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = query;
            sqlCmd.ExecuteNonQuery();


            DataTable dt = new DataTable("StudentTable");
            SqlDataAdapter dataADP = new SqlDataAdapter(sqlCmd);
            dataADP.Fill(dt);
            ProfessorDashboard1.ItemsSource = dt.DefaultView;
            dataADP.Update(dt);
            sqlCon.Close();

        }

        // Remove Button
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();

                    SqlCommand sqlCmd = sqlCon.CreateCommand();
                    string query = "Delete FROM StudentTable WHERE StudentID = ('" + IDTextBox.Text + "')";
                    //sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = query;
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                    display_data();

                    MessageBox.Show("Student Removed Succesfully");
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
                    string query = "UPDATE StudentTable SET StudentID = '" + IDTextBox.Text + "' ,StudentName ='" + this.NameTextBox.Text + "', StudentLastname ='" + this.LastNameTextBox.Text+
                    "' where StudentID = '" + IDTextBox.Text+ "'";
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
    }
    }