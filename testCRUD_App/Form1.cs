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

namespace testCRUD_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             SqlConnection con = new  SqlConnection("Data Source=ISMAIL-RAJU\\SQLEXPRESS;Initial Catalog=rajutest;Integrated Security=True");

            con.Open();
            SqlCommand cmd = new SqlCommand("insert into UserTab values( @ID, @Name , @Age )",con);
            cmd.Parameters.AddWithValue("@ID",int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age",  double.Parse( textBox3.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully saved");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ISMAIL-RAJU\\SQLEXPRESS;Initial Catalog=rajutest;Integrated Security=True");

            con.Open();
            SqlCommand cmd = new SqlCommand("update  UserTab set Name=@Name , Age=@Age where ID= @ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ISMAIL-RAJU\\SQLEXPRESS;Initial Catalog=rajutest;Integrated Security=True");

            con.Open();
            SqlCommand cmd = new SqlCommand("delete from UserTab   where ID= @ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
          

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection("Data Source=ISMAIL-RAJU\\SQLEXPRESS;Initial Catalog=rajutest;Integrated Security=True");

            con.Open();
            SqlCommand cmd;
            if ( textBox1.Text == "")
            {
                  cmd = new SqlCommand("select * from UserTab ", con);
            }
            else { 
             cmd = new SqlCommand("select * from UserTab where ID=@ID ", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            //cmd.ExecuteNonQuery();
            //con.Close();
            //MessageBox.Show("Successfully Deleted");

        }
    }
}
