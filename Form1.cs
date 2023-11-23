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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            string strConnection = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();
            string strCommand = "SELECT * from [dbo].[TAIKHOAN] WHERE [tendangnhap] = @tendangnhap AND [matkhau] = @matkhau";
            SqlConnection myConnection = new SqlConnection(strConnection);
            myConnection.Open();
            //Command Select
            SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
            //Truyền tham số
            myCommand.Parameters.AddWithValue("@tendangnhap", this.textBox1.Text);
            myCommand.Parameters.AddWithValue("@matkhau", this.textBox2.Text);
                //Thực thi câu lệnh
            SqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {

                        Form2 Trangchu = new Form2(myReader["quyenhan"].ToString());
                        Trangchu.ShowForm1 += ShowForm1Method;
                        this.Hide();
                        Trangchu.Show();
                    }
                }
                else
                    throw new Exception("Ten dang nhap hoac mat khau sai");
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowForm1Method()
        {
            // Hiển thị lại Form1
            this.Show();
        }
    }
}
