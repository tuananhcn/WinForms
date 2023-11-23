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
    public partial class Form6 : Form
    {
        int _idlop;

        public Form6(int idlop)
        {
            InitializeComponent();
            _idlop = idlop;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string strConnection = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();
                string strCommand = "Insert into [dbo].[DANHSACHSINHVIEN] values (@idlop,@idtaikhoan,@iddssv) ";
                SqlConnection myConnection = new SqlConnection(strConnection);
                myConnection.Open();
                //Command Select
                SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
                //Truyền tham số
                myCommand.Parameters.AddWithValue("@idlop", _idlop);
                myCommand.Parameters.AddWithValue("@idtaikhoan", this.textBox1.Text);
                myCommand.Parameters.AddWithValue("@iddssv", this.textBox2.Text);
                //Thực thi câu lệnh
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
