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
                string insertStudentSql = "INSERT INTO [dbo].[DANHSACHSINHVIEN] VALUES (@idlop, @idtaikhoan, @iddssv)";
                string insertScoreSql = "INSERT INTO [DIEMSO] VALUES (@iddssv,0,0,0)";
                /*string insertAttendanceSql = "INSERT INTO [DIEMDANH] VALUES (@iddssv,0,0)";*/
                SqlConnection myConnection = new SqlConnection(strConnection);
                myConnection.Open();
                //Command Select
                using (SqlCommand myCommand = new SqlCommand(insertStudentSql, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@idlop", _idlop);
                    myCommand.Parameters.AddWithValue("@idtaikhoan", this.textBox1.Text);
                    myCommand.Parameters.AddWithValue("@iddssv", this.textBox2.Text);
                    myCommand.ExecuteNonQuery();
                }
                //Thực thi câu lệnh
                using (SqlCommand myCommand = new SqlCommand(insertScoreSql, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@iddssv", this.textBox2.Text);
                    myCommand.ExecuteNonQuery();

                }
                /*using (SqlCommand myCommand = new SqlCommand(insertAttendanceSql, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@iddssv", this.textBox2.Text);
                    myCommand.ExecuteNonQuery();

                }*/
                MessageBox.Show("Them thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();            
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
