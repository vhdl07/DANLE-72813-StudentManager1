using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StudentManager
{
    public partial class Form1 : Form
    {
        List<Student> students = new List<Student>();

        public Form1()
        {
            InitializeComponent();
            dgvStudents.AutoGenerateColumns = true;
        }
        private void DisplayStudents()
        {
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = students;
        }

        //Nút Add 
        private void btnAdd_Click(object sender, EventArgs e)
        {
         
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                    string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtClass.Text) ||
                    string.IsNullOrWhiteSpace(txtGrade.Text))
                
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (!double.TryParse(txtGrade.Text, out double grade))
            {
                MessageBox.Show("Điểm phải là số!");
                return;
            }
            Student s = new Student

            {
                Id = txtId.Text,
                Name = txtName.Text,
                Class = txtClass.Text,
                Grade = grade 
            };

            students.Add(s);
            DisplayStudents();
            MessageBox.Show("Đã thêm sinh viên!");
        }
        //Nút Update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var student = students.FirstOrDefault(x => x.Id == txtId.Text);
            if (student != null)
            {
                if (!double.TryParse(txtGrade.Text, out double grade))
                {  MessageBox.Show("Điểm phải là số!");
                    return;
                }

                student.Name = txtName.Text;
                student.Class = txtClass.Text;
                student.Grade = grade;
                DisplayStudents();
                MessageBox.Show("Cập nhật thành công!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên để cập nhật!");
            }
        }
        //Nút Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var student = students.FirstOrDefault(x => x.Id == txtId.Text);
            if (student != null)
            {
                students.Remove(student);
                DisplayStudents();
                MessageBox.Show("Đã xóa sinh viên!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên để xóa!");
            }
        }

    }
}
