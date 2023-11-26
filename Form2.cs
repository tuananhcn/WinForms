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
    public partial class Form2 : Form
    {
        int _quyenhan;
        string _tendangnhap;
        public delegate void ShowForm1Delegate();
        public ShowForm1Delegate ShowForm1;
        public Form2(int quyenhan, string tendangnhap)
        {
            _quyenhan = quyenhan;
            InitializeComponent();
            _tendangnhap = tendangnhap;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowForm1.Invoke();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.label3.Text = "Xin chào, " + _tendangnhap;
            string strConnection = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();
            string strCommand = "Select id, ten from LOP";
            SqlConnection myConnection = new SqlConnection(strConnection);
            SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(myCommand);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            this.comboBox1.DataSource = dt;
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DisplayMember = "ten";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lichhoc Lichhoc = new Lichhoc((int)this.comboBox1.SelectedValue, _quyenhan);
            Lichhoc.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 Diemso = new Form4((int)this.comboBox1.SelectedValue,_quyenhan);
            Diemso.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 Diemdanh = new Form5((int)this.comboBox1.SelectedValue, _quyenhan);
            Diemdanh.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
