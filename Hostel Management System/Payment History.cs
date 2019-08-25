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
    public partial class Payment_History : Form
    {
        private string stdid;

        public Payment_History()
        {
            InitializeComponent();
        }
        List<PaymentsClass> payment = new List<PaymentsClass>();
        public Payment_History(string studentid)
        {
            // TODO: Complete member initialization
            stdid = studentid;
            InitializeComponent();
            get();
        }
        Business_Logic bl = new Business_Logic();
        public void get()
        {
            DataTable dt;
            dt = bl.PaymentHistory(stdid);
            foreach (DataRow dr in dt.Rows)
            {                
                payment.Add(new PaymentsClass(dr["StudentId"].ToString(), dr["Amount"].ToString(), dr["Date"].ToString()));
                //dataGridView1.DataSource = dt;
            }
            var query = from pay in payment
                        where pay.StudentId == stdid
                        orderby pay.StudentId
                        select pay;
            
            foreach (PaymentsClass a in query)
            {                
                listBox1.Items.Add(a.ToString());
            }
        }

        private void Payment_History_Load(object sender, EventArgs e)
        {

        }
    }
}
