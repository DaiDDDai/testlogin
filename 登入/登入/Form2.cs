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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace 登入
{
    public partial class Form2 : Form
    {
        public Form2(string username)
        {
            InitializeComponent();
            this.Text = "Form2";

            string connectionString = "Data Source=DESKTOP-RDBCCLG\\SQLEXPRESS;Initial Catalog = membersystem;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // 打開連接
                connection.Open();

                string query = "SELECT * FROM member1 WHERE username = @username ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // 檢查是否有符合的結果
                        if (reader.HasRows)
                        {
                            // 逐筆讀取結果
                            while (reader.Read())
                            {
                                // 使用索引或欄位名稱讀取資料
                                string name = reader["name"].ToString();
                                string phone = reader["phone"].ToString();
                                string gender = reader["gender"].ToString();
                                string address = reader["address"].ToString();
                                string mail = reader["mail"].ToString();

                                label2.Text = name;
                                label4.Text = phone;
                                label6.Text = gender;
                                label8.Text = address;
                                label10.Text = mail;
                            }
                        }
                        else
                        {
                            // 沒有符合的結果
                            MessageBox.Show("沒有結果");
                        }
                    }
                }
            }
        }
    }
}

