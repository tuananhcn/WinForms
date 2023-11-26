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
    public partial class Form8 : Form
    {
        int _idLopHoc;
        public Form8(int idLopHoc)
        {
            InitializeComponent();
            _idLopHoc = idLopHoc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateLichHoc();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            
        }
        void UpdateLichHoc()
        {
            try
            {
                string strConnection = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();
                string strCommand = "UPDATE [dbo].[lop] SET[ngaybatdau] = @ngaybatdau" +
                                    " WHERE id = @idlop"; ;
                SqlConnection myConnection = new SqlConnection(strConnection);
                myConnection.Open();
                //Command Select
                SqlCommand myCommand = new SqlCommand(strCommand, myConnection);
                //Truyền tham số
                myCommand.Parameters.AddWithValue("@idlop", this._idLopHoc);
                myCommand.Parameters.AddWithValue("@ngaybatdau", this.dateTimePicker1.Value);
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
    }
}
