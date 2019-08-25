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
    public partial class Student_Payment : Form
    {        
        public Student_Payment()
        {
            InitializeComponent();
        }
        private string stdid;
        public Student_Payment(string studentid)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            stdid = studentid;
        }
        Business_Logic bl = new Business_Logic();

        private void btnpay_Click(object sender, EventArgs e)
        {
            int i = bl.Payment(textBox1.Text, textBox8.Text, DateTime.Now.ToString("dd-MM-yyyy"));
            MessageBox.Show("Payment Completed");
            int remaining = bl.dueamount(Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox8.Text));
            MessageBox.Show("Remaining Amount " + remaining);
        }

        private void Student_Payment_Load(object sender, EventArgs e)
        {
            DataTable dt;
            dt = bl.GetStudentDetails(stdid);
            if (dt.Rows.Count != 0)
            {
                textBox1.Text = dt.Rows[0]["StudentId"].ToString();
                textBox2.Text = dt.Rows[0]["Firstname"].ToString();                
                textBox5.Text = dt.Rows[0]["Total"].ToString();
                textBox6.Text = dt.Rows[0]["Paid"].ToString();
                textBox7.Text = dt.Rows[0]["Due"].ToString();
            }
            else
                MessageBox.Show("Invalid Student ID");
        }
    }
}
