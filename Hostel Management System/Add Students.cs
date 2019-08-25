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
    public partial class Add_Students : Form
    {
        public Add_Students()
        {
            InitializeComponent();
        }
        Business_Logic bl = new Business_Logic();
        private void button1_Click(object sender, EventArgs e)
        {
            int res = bl.Add_Student(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Text, textBox7.Text,textBox6.Text, richTextBox1.Text);            
            MessageBox.Show("Student Details Registered Success");

            Add_Students add = new Add_Students();
            add.Show();
            this.Hide();

        }
    }
}
