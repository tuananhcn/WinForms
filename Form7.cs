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
    public partial class Form7 : Form
    {
        bool AddNew;
        diemdanh Diemdanh;
        public Form7(bool addNew, diemdanh diemdanh)
        {
            InitializeComponent();
            AddNew = addNew;
            Diemdanh = diemdanh;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            if (AddNew)
            {
                this.label1.Text = "Thêm mới";
            }
            else
            {
                this.label1.Text = "Sửa";
                this.textBox1.Text = Diemdanh.iddssv.ToString();
                this.dateTimePicker1.Text = this.Diemdanh.ngayvang.ToString();
                this.checkBox1.Checked = Diemdanh.cophep;
            }    
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void AddDiemDanh()
        {
            try
            {
                string strConnection = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();
                string strCommand = "Insert into diemdanh " + "values (@iddssv,@ngayvang,@cophep)";
                SqlConnection myConnection = new SqlConnection(strConnection);
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
                myCommand.Parameters.AddWithValue("@iddssv", this.textBox1.Text);
                myCommand.Parameters.AddWithValue("@ngayvang", this.dateTimePicker1.Value);
                myCommand.Parameters.AddWithValue("@cophep", this.checkBox1.Checked ? 1: 0);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show("Thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void UpdateDiemDanh()
        {
            try
            {
                string strConnection = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();
                string strCommand = "UPDATE [dbo].[diemdanh] SET[iddssv] = @iddssv, " +
                                    "[ngayvang] = @ngayvang, " +
                                    "[cophep] = @cophep" +
                                    " WHERE iddssv = @iddssv"; ;
                SqlConnection myConnection = new SqlConnection(strConnection);
                myConnection.Open();
                //Command Select
                SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
                //Truyền tham số
                myCommand.Parameters.AddWithValue("@iddssv", this.textBox1.Text);
                myCommand.Parameters.AddWithValue("@ngayvang", this.dateTimePicker1.Value);
                myCommand.Parameters.AddWithValue("@cophep", this.checkBox1.Checked ? 1 : 0);
                //Thực thi câu lệnh
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show("Thanh cong", "Thanh cong", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (AddNew)
                AddDiemDanh();
            else
                UpdateDiemDanh();
        }
    }
}
