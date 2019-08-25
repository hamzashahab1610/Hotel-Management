using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System
{
    public partial class Student_Main_Form : Form
    {
        string studentid;

        public Student_Main_Form()
        {
            InitializeComponent();
        }

        public Student_Main_Form(string p)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            studentid = p;
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personal_Details details = new Personal_Details(studentid);
            details.MdiParent = this;
            details.Show();
            details.Activate();
        }

        private void paymentHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_History payment = new Payment_History(studentid);
            payment.MdiParent = this;
            payment.Show();
            payment.Activate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_Payment spayment = new Student_Payment(studentid);
            spayment.MdiParent = this;
            spayment.Show();
            spayment.Activate();
        }
    }
}
