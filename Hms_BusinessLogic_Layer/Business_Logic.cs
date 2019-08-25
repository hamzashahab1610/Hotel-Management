using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hms_DataAccess_Layer;
using System.Data;
using System.Data.SqlClient;
namespace Hms_BusinessLogic_Layer
{
    public class Business_Logic : PaymentsClass
    {
        Data_Access da = new Data_Access();

        public int total { get; private set; }
        public int paid { get; private set; }
        public int due { get; private set; }

        public int Add_Student(string studentid, string fname, string lname, string mobile, string email, string doj, string fee, string pwd, string add)
        {
            return da.Add_Student(studentid, fname, lname, mobile, email, doj, fee, pwd, add);
        }

        public DataTable students()
        {
            DataTable dt;
            return dt = da.students();
        }

        public int Update_Student(string studentid, string fname, string lname, string mobile, string email, string doj,string fee, string add)
        {            
            return da.Update_Student(studentid, fname, lname, mobile, email, doj, fee, add);         
        }

        public int Delete_Student(string stdid)
        {
            return da.Delete_Student(stdid);
        }

        public DataTable GetAmount(string stdid)
        {            
            return da.GetAmount(stdid);
        }

        public int Payment(string stdid,string amount, string date)
        {            
            return da.Payment(stdid, amount, date);
        }

        public override int dueamount(int totalamount, int payamount)
        {
            total = totalamount;
            paid = payamount;
            due = totalamount - payamount;
            return due;
        }

        public DataTable PaymentDetails()
        {
            DataTable dt = new DataTable();           
            return dt = da.PaymentDetails();
            //List<PaymentsClass> pa = new List<PaymentsClass>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    PaymentsClass p = new PaymentsClass();
            //    p.StudentId = dr["StudentId"].ToString();
            //    p.Amount = dr["Amount"].ToString();
            //    p.Date = dr["Date"].ToString();
            //    pa.Add(p);
            //}
            //return pa;
        }

        public DataTable Student_login(string stdid, string password)
        {
            return da.Student_login(stdid, password);
        }

        public DataTable GetStudentDetails(string stdid)
        {            
            return da.GetStudentDetails(stdid);
        }

        public DataTable PaymentHistory(string stdid)
        {
            DataTable dt = new DataTable();
            dt = da.PaymentHistory(stdid);
            return dt;
            
        }
    }
}
