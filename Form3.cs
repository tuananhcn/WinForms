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
    public partial class Form3 : Form
    {
        Diemso _selectedDiemSo;
        public Form3(Diemso selectedDiemSo)
        {
            InitializeComponent();
            _selectedDiemSo = new Diemso();
            _selectedDiemSo.iddssv = selectedDiemSo.iddssv;
            _selectedDiemSo.hovaten = selectedDiemSo.hovaten;
            _selectedDiemSo.diem1 = selectedDiemSo.diem1;
            _selectedDiemSo.diem2 = selectedDiemSo.diem2;
            _selectedDiemSo.diem3 = selectedDiemSo.diem3;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.label4.Text = _selectedDiemSo.iddssv.ToString();
            this.label5.Text = _selectedDiemSo.hovaten.ToString();
            this.textBox1.Text = _selectedDiemSo.diem1.ToString();
            this.textBox2.Text = _selectedDiemSo.diem2.ToString();
            this.textBox3.Text = _selectedDiemSo.diem3.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string strConnection = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();
                string strCommand = "UPDATE [dbo].[DIEMSO] SET[diem1] = @diem1, " +
                                    "[diem2] = @diem2, " +
                                    "[diem3] = @diem3" +
                                    " WHERE iddssv = @iddssv";
                SqlConnection myConnection = new SqlConnection(strConnection);
                myConnection.Open();
                //Command Select
                SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
                //Truyền tham số
                myCommand.Parameters.AddWithValue("@diem1", this.textBox1.Text.ToString());
                myCommand.Parameters.AddWithValue("@diem2", this.textBox2.Text.ToString());
                myCommand.Parameters.AddWithValue("@diem3", this.textBox3.Text.ToString());
                myCommand.Parameters.AddWithValue("@iddssv", this.label4.Text.ToString());
                //Thực thi câu lệnh
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Sua thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                myConnection.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
