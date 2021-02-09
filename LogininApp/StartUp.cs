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
    public partial class StartUp : Form
    {
        SqlConnection sqlcon = new SqlConnection();
        public StartUp()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {


            SqlConnection sqlcon = new SqlConnection(); //enter propertie of DB here

            sqlcon.ConnectionString =
                    "Data Source=DESKTOP-GJ2VEDA\\MSSQLSERVER02;" +
                    "Initial Catalog=Library;" +
                    "Integrated Security=True";
            sqlcon.Open();
            SqlCommand cmdCheckLogin = sqlcon.CreateCommand();

            UserEditTable frm = new UserEditTable();
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminLogin frm = new AdminLogin();
            frm.ShowDialog();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StartUp_Load(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(); //enter propertie of DB here

            try
            {
                sqlcon.ConnectionString =
                        "Data Source=DESKTOP-GJ2VEDA\\MSSQLSERVER02;" +
                        "Initial Catalog=Library;" +
                        "Integrated Security=True";
                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Books";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                sqlcon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(); //enter propertie of DB here

            try
            {
                sqlcon.ConnectionString =
                        "Data Source=DESKTOP-GJ2VEDA\\MSSQLSERVER02;" +
                        "Initial Catalog=Library;" +
                        "Integrated Security=True";
                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Books where name like('%" + boxSearch.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void boxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(); //enter propertie of DB here

            try
            {
                sqlcon.ConnectionString =
                        "Data Source=DESKTOP-GJ2VEDA\\MSSQLSERVER02;" +
                        "Initial Catalog=Library;" +
                        "Integrated Security=True";
                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Books where name like('%" + boxSearch.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sqlcon.ConnectionString =
                        "Data Source=DESKTOP-GJ2VEDA\\MSSQLSERVER02;" +
                        "Initial Catalog=Library;" +
                        "Integrated Security=True";
                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Books where Auther like('%" + boxAuthor.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
    }
}
