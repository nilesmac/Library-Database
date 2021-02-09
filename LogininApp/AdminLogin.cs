using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogininApp
{
    public partial class AdminLogin : Form
    {
        public SqlConnection sqlConnection = new SqlConnection();
        string admin = "Admin";

        public AdminLogin()
        {
            InitializeComponent();
        }

        private void txtLname_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //connection 
                SqlConnection sqlCon = new SqlConnection();
                sqlConnection.ConnectionString =
                        "Data Source=DESKTOP-GJ2VEDA\\MSSQLSERVER02;" +
                        "Initial Catalog=Library;" +
                        "Integrated Security=True";
                sqlConnection.Open();

                //MessageBox.Show("Connected");

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            SqlCommand cmdCheckLogin = sqlConnection.CreateCommand();

            cmdCheckLogin.CommandText = "SELECT Lname, Password, Type FROM Customers WHERE Lname = @Lname AND  Password = @Password AND Type = @Type";
            cmdCheckLogin.Parameters.AddWithValue("@Lname", txtLname.Text);
            cmdCheckLogin.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmdCheckLogin.Parameters.AddWithValue("@Type", admin);


            SqlDataReader reader = cmdCheckLogin.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("Worked");
                MainScreen form = new MainScreen();
                form.sqlConnection.ConnectionString = sqlConnection.ConnectionString;
                form.Show();
            }
            else
                MessageBox.Show("Invalid Admin Information");

                reader.Close();
           }

       
    }
  }

