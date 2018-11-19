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
    /// Interaction logic for StudentDashboard.xaml
    /// </summary>
    public partial class StudentDashboard : Window
    {
        private const string ConnectionString = @"Data Source=DESKTOP-D6AP9T9 ; Initial Catalog=LoginDb; Integrated Security=True";
        SqlConnection sqlCon = new SqlConnection(ConnectionString);

        public StudentDashboard()
        {
            


        }


    }
   
}
