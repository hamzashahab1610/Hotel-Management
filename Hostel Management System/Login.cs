using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hms_BusinessLogic_Layer;

namespace Hostel_Management_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Business_Logic bl = new Business_Logic();
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "--Select--")
                MessageBox.Show("Please Select Type");

            else if (comboBox1.SelectedItem == "Admin" && textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                MainForm admin = new MainForm();
                admin.Show();
                admin.Activate();
                this.Hide();
            }
            else if (comboBox1.Text == "Student")
            {
                DataTable dt;
                dt = bl.Student_login(textBox1.Text, textBox2.Text);
                if (dt.Rows.Count != 0)
                {
                    Student_Main_Form student = new Student_Main_Form(textBox1.Text);
                    student.Show();
                    student.Activate();
                    this.Hide();
                }
                else
                    MessageBox.Show("Invalid Credensials");
            }
            else
                MessageBox.Show("Invalid Credensials");            
        }
    }
}
