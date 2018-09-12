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
namespace _12._09
{
    public partial class Form1 : Form
    {

        string cs = @"Data Source = COMP506\SQLEXPRESS; Initial Catalog=PublishingHouse; Integrated Security = true;";
        SqlConnection con = null;
       
        public Form1()
        {
            InitializeComponent();
     
        }


        private async Task FillView()
        {

            using (con = new SqlConnection(cs))
            {

                await con.OpenAsync();
                string sql = "waitfor delay '00:00:01';";
                sql += textBox1.Text;
                SqlCommand com = new SqlCommand(sql, con);
                DataTable table = new DataTable();
                SqlDataReader reader = await com.ExecuteReaderAsync();
                int line = 0;
                do
                {



                    while (await reader.ReadAsync())
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                table.Columns.Add(reader.GetName(i));
                            }
                            line++;
                        }
                        DataRow row = table.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[i] = reader[i];

                        }
                        table.Rows.Add(row);
                    }

                } while (await reader.NextResultAsync());
                      dataGridView1.DataSource = null;
                dataGridView1.DataSource = table;

               

            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "select * from Book")
            {

                using (con = new SqlConnection(cs))
                {

                    await con.OpenAsync();


                    SqlCommand com = new SqlCommand("select CONCAT(Firstname,lastname) from Authors", con);
                    //com.Parameters.AddWithValue("@name",)

                    SqlDataReader reader = await com.ExecuteReaderAsync();
                    await FillView();

                    while (await reader.ReadAsync())
                        comboBox1.Items.Add(reader[0]);


                    com.CommandText = "";
                }
            }
            else
            {
                comboBox1.Items.Clear();

                await FillView();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (con = new SqlConnection(cs))
            {

                con.Open();

                SqlCommand com = new SqlCommand("select SUM(DrawingOfBook) from Book join Authors on Authors.IDAuthor = Book.IDAuthor and CONCAT(Firstname,lastname)=@name", con);
                com.Parameters.AddWithValue("@name", comboBox1.SelectedItem.ToString());

             
                string str =  com.ExecuteScalar().ToString();

                label2.Text = str;
              
            }



        
        }
    }
}
