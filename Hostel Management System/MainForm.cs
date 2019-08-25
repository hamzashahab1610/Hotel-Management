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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void addStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Students addstd=new Add_Students();
            addstd.MdiParent = this;
            addstd.Show();
            addstd.Activate();
        }

        private void viewStudentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Student_Details viewstd = new View_Student_Details();
            viewstd.MdiParent = this;
            viewstd.Show();
            viewstd.Activate();
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payments pay = new Payments();
            pay.MdiParent = this;
            pay.Show();
            pay.Activate();
        }

        private void viewPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Payment_Details viewpay = new View_Payment_Details();
            viewpay.MdiParent = this;
            viewpay.Show();
            viewpay.Activate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
