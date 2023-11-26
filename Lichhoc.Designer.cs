namespace WindowsFormsApp2
{
    partial class Lichhoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Ngaygio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Khoahoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiangVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ngaygio,
            this.Khoahoc,
            this.GiangVien,
            this.diachi});
            this.dataGridView1.Location = new System.Drawing.Point(115, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(554, 366);
            this.dataGridView1.TabIndex = 2;
            // 
            // Ngaygio
            // 
            this.Ngaygio.HeaderText = "Ngày giờ";
            this.Ngaygio.MinimumWidth = 6;
            this.Ngaygio.Name = "Ngaygio";
            this.Ngaygio.Width = 125;
            // 
            // Khoahoc
            // 
            this.Khoahoc.HeaderText = "Khóa học";
            this.Khoahoc.MinimumWidth = 6;
            this.Khoahoc.Name = "Khoahoc";
            this.Khoahoc.Width = 125;
            // 
            // GiangVien
            // 
            this.GiangVien.HeaderText = "Giảng viên";
            this.GiangVien.MinimumWidth = 6;
            this.GiangVien.Name = "GiangVien";
            this.GiangVien.Width = 125;
            // 
            // diachi
            // 
            this.diachi.HeaderText = "Địa chỉ";
            this.diachi.MinimumWidth = 6;
            this.diachi.Name = "diachi";
            this.diachi.Width = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "Sửa lịch học";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Lichhoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Lichhoc";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaygio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Khoahoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiangVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachi;
        private System.Windows.Forms.Button button1;
    }
}