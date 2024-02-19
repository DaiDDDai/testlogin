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

namespace 登入
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
            string username = textBox1.Text;
            string password = textBox2.Text;
            string connectionString = "Data Source=DESKTOP-RDBCCLG\\SQLEXPRESS;Initial Catalog = membersystem;Integrated Security=True";

            if (username == "" || password == "")
            {
                MessageBox.Show("錯誤：欄位空白，請填入帳號密碼");
                return; // 在這裡添加 return，以避免執行後續的程式碼
            }
            else
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // 打開連接
                    connection.Open();

                    string query = "SELECT * FROM member1 WHERE username = @username AND password = @password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 檢查是否有符合的結果
                            if (reader.HasRows)
                            {
                                // 有符合的結果，表示帳號密碼正確
                                MessageBox.Show("登入成功");
                                this.Hide();
                                Form2 form2 = new Form2(username);
                                form2.Show(); ;
                            }
                            else
                            {
                                // 沒有符合的結果，表示帳號密碼錯誤
                                MessageBox.Show("錯誤：帳號或密碼錯誤");
                            }
                        }
                    }
                }
        }
    }
}