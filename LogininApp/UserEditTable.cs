using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LogininApp
{
    public partial class UserEditTable : Form
    {
        public SqlConnection sqlConnection = new SqlConnection();
        string admin;
        public UserEditTable()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
            StartUp frm = new StartUp();
            frm.ShowDialog();
            
            

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            
            if (txtFname.Text == "" || txtPassword.Text == "" || lblLname.Text == "" ||
                lbAddress.Text == "" || txtCity.Text == "" || lbEmail.Text == ""
                || txtState.Text == "" || txtZIP.Text == "")
                MessageBox.Show("Do not leave anything unfilled");
            else
            {

                //connection 
                SqlConnection sqlCon = new SqlConnection(); //enter propertie of DB here

                sqlCon.ConnectionString =
                                "Data Source=DESKTOP-GJ2VEDA\\MSSQLSERVER02;" +
                                "Initial Catalog=Library;" +
                                "Integrated Security=True";
                sqlCon.Open();
                SqlCommand cmdGet = sqlCon.CreateCommand();
                /*cmdGet.CommandText = "SELECT Count(*) FROM Users";
                SqlDataReader reader = cmdGet.ExecuteReader();
                if (reader.Read())
                {
                    //MessageBox.Show(reader[0].ToString());
                    IDcount = (int)(reader[0]);
                    reader.Close();

                }*/

                if (checkAdmin.Checked == true)
                    admin = "Admin";
                else
                    admin = "Student";

                SqlCommand sqlCmd = new SqlCommand("RegAdd", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Fname", txtFname.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Lname", txtLname.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@State", txtState.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@ZIP", txtZIP.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Type", admin);


                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Register is confimred");
                ClearTextBoxes();
            }

        }

        void ClearTextBoxes()
        {
            txtFname.Text = txtLname.Text = txtAddress.Text = txtPassword.Text = 
            txtCity.Text = txtEmail.Text = txtState.Text = txtZIP.Text = "";
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

