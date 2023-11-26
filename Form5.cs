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
    public partial class Form5 : Form
    {
        int _idlop;
        int _quyenhan;
        public diemdanh selectedDiemdanh;
        public Form5(int idlop, int quyenhan)
        {
            InitializeComponent();
            _idlop = idlop;
            _quyenhan = quyenhan;
        }
        private void LoadDSSV()
        {
            if (_quyenhan == 0)
            {
                this.button1.Visible = false;
                this.button2.Visible = false;
            }

            string strConnection = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();
            string strCommand = "select diemdanh.iddssv, ngayvang, cophep, ten, ngaythangnamsinh,gioitinh,diachi from diemdanh, DANHSACHSINHVIEN, taikhoan where diemdanh.iddssv = DANHSACHSINHVIEN.iddssv and TAIKHOAN.id = DANHSACHSINHVIEN.idtaikhoan and DANHSACHSINHVIEN.idlop = @idlop";
            SqlConnection myConnection = new SqlConnection(strConnection);
            SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
            myCommand.Parameters.AddWithValue("@idlop", _idlop);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(myCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            LoadDSSV();
        }
        private void RetrieveCurrentRow(DataGridViewCellEventArgs e)
        {
            try
            {
            DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
            /*this.Text = dr.Cells["OrderID"].Value.ToString();*/
            selectedDiemdanh = new diemdanh();
            selectedDiemdanh.iddssv = int.Parse(dr.Cells["iddssv"].Value.ToString());
            selectedDiemdanh.ngayvang = DateTime.Parse(dr.Cells["ngayvang"].Value.ToString());
            selectedDiemdanh.cophep = bool.Parse(dr.Cells["cophep"].Value.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RetrieveCurrentRow(e);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RetrieveCurrentRow(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 themSV = new Form7(true, selectedDiemdanh);
            themSV.ShowDialog();
            LoadDSSV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 suaSV = new Form7(false, selectedDiemdanh);
            suaSV.ShowDialog();
            LoadDSSV();
        }
    }
}
