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
    public partial class Lichhoc : Form
    {
        private int _idLopHoc;
        public Lichhoc(int idLopHoc)
        {
            InitializeComponent();
            _idLopHoc = idLopHoc;
            LoadLichHoc();
        }
        private void LoadLichHoc()
        {
            string strConnection = System.Configuration.ConfigurationSettings.AppSettings["MyCNN"].ToString();
            string query = "SELECT lop.ngaybatdau, khoahoc.sobuoihoc, lichhoc.*, taikhoan.ten, lop.diachi, khoahoc.tenkhoahoc FROM lop INNER JOIN lichhoc on lop.id = lichhoc.idlophoc INNER JOIN khoahoc on lop.idkhoahoc = khoahoc.idkhoahoc inner join Taikhoan on lop.idgiangvien = taikhoan.id";
            using (SqlConnection connection = new SqlConnection(strConnection))
            {
                string[] arrDayOfWeek = new string[] { "chunhat", "thu2", "thu3", "thu4", "thu5", "thu6", "thu7" };
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idLopHoc", _idLopHoc);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["ngaybatdau"].GetType() == typeof(DBNull))
                    {
                        continue;
                    }
                    string[] activeLearnDays = new string[7];
                    for (int i = 0; i < 7; i++)
                    {
                        activeLearnDays[i] = reader[arrDayOfWeek[i]].GetType() != typeof(DBNull) ? reader[arrDayOfWeek[i]].ToString() : "";
                    }
                    string[] arrLearnedDays = calcLearnedDate(reader["ngaybatdau"].ToString(), Convert.ToInt32(reader["sobuoihoc"]), activeLearnDays);
                    
                    for (int i = 0; i < arrLearnedDays.Length; i++)
                    {

                        string[] row = new string[] { arrLearnedDays[i], reader["tenkhoahoc"].ToString(), reader["ten"].ToString(), reader["diachi"].ToString() };
                        this.dataGridView1.Rows.Add(row);
                    }
                }
                connection.Close();
            }
        }
        public static string[] calcLearnedDate(string classStartDay, int numberOfLearnedDays, string[] activeLearnDays)
        {
            DateTime startDate = DateTime.Parse(classStartDay);
            DateTime currentDate = DateTime.Today;
            DateTime endDate;
            int learnedDays = 0;
            string[] arrLearnedDays = new string[0];
            var listLearnedDays = arrLearnedDays.ToList();
            for (endDate = startDate; learnedDays < numberOfLearnedDays; endDate = endDate.AddDays(1))
            {
                if (activeLearnDays[(int)endDate.DayOfWeek] != "")
                {
                    learnedDays++;
                    if (currentDate.Date <= endDate.Date)
                    {
                        listLearnedDays.Add(endDate.ToString("yyyy-MM-dd " + activeLearnDays[(int)endDate.DayOfWeek]));
                    }
                }
            }
            return listLearnedDays.ToArray();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
