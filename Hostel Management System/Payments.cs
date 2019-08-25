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
    public partial class Payments : Form
    {
        public Payments()
        {
            InitializeComponent();
        }
        Business_Logic bl = new Business_Logic();
        private void btnsearch_Click(object sender, EventArgs e)
        {
            DataTable dt;
            dt = bl.GetAmount(studentidtextbox.Text);
            if (dt.Rows.Count != 0)
            {                
                totalamouttextbox.Text = dt.Rows[0]["Total"].ToString();
                textBox6.Text = dt.Rows[0]["Paid"].ToString();
                textBox7.Text = dt.Rows[0]["Due"].ToString();
                textBox2.Text = dt.Rows[0]["Firstname"].ToString();
            }
            else
                MessageBox.Show("Invalid Student ID");
        }

        private void btnpay_Click(object sender, EventArgs e)
        {
            int i = bl.Payment(studentidtextbox.Text, textBox8.Text, DateTime.Now.ToString("dd-MM-yyyy"));
            MessageBox.Show("Payment Completed");
            int remaining = bl.dueamount(Convert.ToInt32(totalamouttextbox.Text), Convert.ToInt32(textBox8.Text));
            MessageBox.Show("Remaining Amount " + remaining);
        }

        
    }
}
