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
    public partial class View_Student_Details : Form
    {
        public View_Student_Details()
        {
            InitializeComponent();
            groupBox1.Visible = false;
            get();
        }
        Business_Logic bl = new Business_Logic();
        public void get()
        {            
            DataTable dt;
            dt = bl.students();
            if (dt.Rows.Count != 0)
            {
                dataGridView1.DataSource = dt;
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            int i = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            int res = bl.Delete_Student(textBox1.Text);
            MessageBox.Show("Student Details Deleted Success"+res);
            groupBox1.Visible = false;
            get();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            int res = bl.Update_Student(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Text, textBox6.Text, richTextBox1.Text);            
            MessageBox.Show("Student Details Updated Success");
            groupBox1.Visible = false;
            get();
        }
    }
}
