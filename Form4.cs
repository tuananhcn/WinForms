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
    public partial class Form4 : Form
    {
        int _idlop;
        string _quyenhan;
        public Diemso selectedDiemSo;
        public Form4(int idlop, string quyenhan)
        {
            InitializeComponent();
            _idlop = idlop;
            _quyenhan = quyenhan;
        }
        private void LoadDSSV()
        {
            string strConnection = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();
            string strCommand = "select DIEMSO.iddssv,TAIKHOAN.ten, TAIKHOAN.ngaythangnamsinh, TAIKHOAN.gioitinh, TAIKHOAN.diachi, DIEMSO.diem1, DIEMSO.diem2, DIEMSO.diem3 from LOP, DANHSACHSINHVIEN, DIEMSO, TAIKHOAN where LOP.id = DANHSACHSINHVIEN.idlop AND DANHSACHSINHVIEN.idtaikhoan = TAIKHOAN.id AND DIEMSO.iddssv = DANHSACHSINHVIEN.iddssv AND DANHSACHSINHVIEN.idlop = @idlop";
            SqlConnection myConnection = new SqlConnection(strConnection);
            SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
            myCommand.Parameters.AddWithValue("@idlop", _idlop);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(myCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(selectedDiemSo != null)
            {
                Form3 suaForm = new Form3(selectedDiemSo);
                suaForm.ShowDialog();
                LoadDSSV();
            }
            else
            {
                MessageBox.Show("Can chon ban ghi de sua? ", "Huong dan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            LoadDSSV();
        }
        private void RetrieveCurrentRow(DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
            /*this.Text = dr.Cells["OrderID"].Value.ToString();*/
            selectedDiemSo = new Diemso();
            selectedDiemSo.iddssv = int.Parse(dr.Cells["iddssv"].Value.ToString());
            selectedDiemSo.hovaten = dr.Cells["ten"].Value.ToString();
            selectedDiemSo.diem1 = float.Parse(dr.Cells["diem1"].Value.ToString());
            selectedDiemSo.diem2 = float.Parse(dr.Cells["diem2"].Value.ToString());
            selectedDiemSo.diem3 = float.Parse(dr.Cells["diem3"].Value.ToString());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RetrieveCurrentRow(e);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            RetrieveCurrentRow(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 themSV = new Form6(_idlop);
            themSV.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
