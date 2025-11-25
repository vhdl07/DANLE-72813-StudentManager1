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
        private void button1_Click(object sender, EventArgs e)
        {
         
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text))
                
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (!double.TryParse(textBox4.Text, out double grade))
            {
                MessageBox.Show("Điểm phải là số!");
                return;
            }
            Student s = new Student

            {
                Id = textBox1.Text,
                Name = textBox2.Text,
                Class = textBox3.Text,
                Grade = double.TryParse(textBox4.Text, out double g) ? g : 0
            };

            students.Add(s);
            MessageBox.Show("Đã thêm sinh viên!");
            DisplayStudents();
        }
        //Nút Update
        private void button2_Click(object sender, EventArgs e)
        {
            var student = students.FirstOrDefault(x => x.Id == textBox1.Text);
            if (student != null)
            {
                if (!double.TryParse(textBox4.Text, out double grade))
                {  MessageBox.Show("Điểm phải là số!");
                    return;
                }

                student.Name = textBox2.Text;
                student.Class = textBox3.Text;
                student.Grade = double.TryParse(textBox4.Text, out double g) ? g : 0;
                MessageBox.Show("Cập nhật thành công!");
                DisplayStudents();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên để cập nhật!");
            }
        }
        //Nút Delete
        private void button3_Click(object sender, EventArgs e)
        {
            var student = students.FirstOrDefault(x => x.Id == textBox1.Text);
            if (student != null)
            {
                students.Remove(student);
                MessageBox.Show("Đã xóa sinh viên!");
                DisplayStudents();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên!");
            }
        }

    }
}
