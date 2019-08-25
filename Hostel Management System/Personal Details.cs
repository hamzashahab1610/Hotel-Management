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
    public partial class Personal_Details : Form
    {
        private string stdid;

        public Personal_Details()
        {
            InitializeComponent();
        }
        Business_Logic bl = new Business_Logic();
        public Personal_Details(string studentid)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            stdid = studentid;
            studentDetails();
        }

        public void studentDetails()
        {
            DataTable dt;
            dt = bl.GetStudentDetails(stdid);
            if (dt.Rows.Count != 0)
            {
                textBox1.Text = dt.Rows[0]["StudentId"].ToString();
                textBox2.Text = dt.Rows[0]["Firstname"].ToString();
                textBox3.Text = dt.Rows[0]["Lastname"].ToString();
                textBox4.Text = dt.Rows[0]["Mobile"].ToString();
                textBox5.Text = dt.Rows[0]["EmailId"].ToString();
                dateTimePicker1.Text = dt.Rows[0]["DOJ"].ToString();
                textBox6.Text = dt.Rows[0]["Password"].ToString();
                richTextBox1.Text = dt.Rows[0]["Address"].ToString();
                textBox7.Text = dt.Rows[0]["Total"].ToString();
                textBox8.Text = dt.Rows[0]["Paid"].ToString();
                textBox9.Text = dt.Rows[0]["Due"].ToString();
            }
            else
                MessageBox.Show("Invalid Student ID");
        }

        private void Personal_Details_Load(object sender, EventArgs e)
        {

        }
    }
}
