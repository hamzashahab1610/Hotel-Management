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
    public partial class View_Payment_Details : Form
    {
        public View_Payment_Details()
        {
            InitializeComponent();
        }

        private void View_Payment_Details_Load(object sender, EventArgs e)
        {
            List<PaymentsClass> payment = new List<PaymentsClass>();
            Business_Logic bl = new Business_Logic();
            //dataGridView1.DataSource = bl.PaymentDetails();
            DataTable dt;
            dt = bl.PaymentDetails();
            foreach (DataRow dr in dt.Rows)
            {
                payment.Add(new PaymentsClass(dr["StudentId"].ToString(), dr["Amount"].ToString(), dr["Date"].ToString()));
                //dataGridView1.DataSource = dt;
            }
            var query = from pay in payment                        
                        orderby pay.StudentId
                        select pay;

            foreach (PaymentsClass a in query)
            {
                listBox1.Items.Add(a.ToString());
            }
        }
    }
}
