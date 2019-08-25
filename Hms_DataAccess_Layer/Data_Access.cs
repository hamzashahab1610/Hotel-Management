using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Hms_DataAccess_Layer
{
    public class Data_Access: Admin
    {
        SqlConnection myconnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        SqlCommand mycommand = new SqlCommand();

        public int Add_Student(string studentid, string fname, string lname, string mobile, string email, string doj, string fee, string pwd, string add)
        {
            if (myconnection.State == ConnectionState.Open)
                myconnection.Close();
            myconnection.Open();
            mycommand.CommandType = CommandType.Text;
            string s="insert into Student values('" + studentid + "','" + fname + "','" + lname + "','" + mobile + "','" + email + "','" + doj + "','" + fee + "','" + pwd + "','" + add + "')";
            s+="insert into FeeDetails values('" + studentid + "','" + fee + "','0','" + fee + "')";
            mycommand.CommandText = s;
            mycommand.Connection = myconnection;
            return mycommand.ExecuteNonQuery();
        }

        public DataTable students()
        {
            if (myconnection.State == ConnectionState.Open)
                myconnection.Close();
            myconnection.Open();
            mycommand.CommandType = CommandType.Text;
            string s = "select StudentId,Firstname,Lastname,Mobile,EmailId,DOJ,Fee,Address from Student";
            mycommand.CommandText = s;
            mycommand.Connection = myconnection;
            SqlDataAdapter sda = new SqlDataAdapter(mycommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public int Update_Student(string studentid, string fname, string lname, string mobile, string email, string doj,string fee, string add)
        {
            if (myconnection.State == ConnectionState.Open)
                myconnection.Close();
            myconnection.Open();
            mycommand.CommandType = CommandType.Text;
            string s = "update Student set Firstname='"+fname+"',Lastname='"+lname+"',Mobile='"+mobile+"' ,EmailId='"+email+"' ,DOJ='"+doj+"',Fee='"+fee+"', Address='"+add+"' where StudentId='"+studentid+"'";
            s += "update FeeDetails set Total='"+fee+"', Due='"+fee+"' where StudentId='"+studentid+"'";
            mycommand.CommandText = s;
            mycommand.Connection = myconnection;
            return mycommand.ExecuteNonQuery();
        }

        public int Delete_Student(string stdid)
        {
            if (myconnection.State == ConnectionState.Open)
                myconnection.Close();
            myconnection.Open();
            mycommand.CommandType = CommandType.Text;
            string s = "delete from Student where StudentId='" + stdid + "'";            
            mycommand.CommandText = s;
            mycommand.Connection = myconnection;
            return mycommand.ExecuteNonQuery();
        }

        public DataTable GetAmount(string stdid)
        {
            if (myconnection.State == ConnectionState.Open)
                myconnection.Close();
            myconnection.Open();
            mycommand.CommandType = CommandType.Text;
            string s = "select FeeDetails.Total,FeeDetails.Paid,FeeDetails.Due,Student.Firstname from FeeDetails inner join Student on FeeDetails.StudentId=Student.StudentId where FeeDetails.StudentId='" + stdid + "'";
            mycommand.CommandText = s;
            mycommand.Connection = myconnection;
            SqlDataAdapter sda = new SqlDataAdapter(mycommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public int Payment(string stdid, string amount, string date)
        {
            if (myconnection.State == ConnectionState.Open)
                myconnection.Close();
            myconnection.Open();
            mycommand.CommandType = CommandType.Text;
            string s = "update FeeDetails set Paid+='"+amount+"',Due-='"+amount+"' where StudentId='"+stdid+"'";
            s += "insert into Payments values('" + stdid + "','" + amount + "','" + date + "')";
            mycommand.CommandText = s;
            mycommand.Connection = myconnection;
            return mycommand.ExecuteNonQuery();
        }

        public DataTable PaymentDetails()
        {
            if (myconnection.State == ConnectionState.Open)
                myconnection.Close();
            myconnection.Open();
            mycommand.CommandType = CommandType.Text;
            string s = "select * from Payments";
            mycommand.CommandText = s;
            mycommand.Connection = myconnection;
            SqlDataAdapter sda = new SqlDataAdapter(mycommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Student_login(string stdid, string password)
        {
            if (myconnection.State == ConnectionState.Open)
                myconnection.Close();
            myconnection.Open();
            mycommand.CommandType = CommandType.Text;
            string s = "select StudentId,Password from Student where StudentId='" + stdid + "' and Password='" + password + "'";
            mycommand.CommandText = s;
            mycommand.Connection = myconnection;
            SqlDataAdapter sda = new SqlDataAdapter(mycommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable GetStudentDetails(string stdid)
        {
            if (myconnection.State == ConnectionState.Open)
                myconnection.Close();
            myconnection.Open();
            mycommand.CommandType = CommandType.Text;
            string s = "select Student.StudentId,Firstname,Lastname,Mobile,EmailId,DOJ,Password,Address,Total,Paid,Due from Student inner join FeeDetails on Student.StudentId=FeeDetails.StudentId where Student.StudentId='" + stdid + "'";
            mycommand.CommandText = s;
            mycommand.Connection = myconnection;
            SqlDataAdapter sda = new SqlDataAdapter(mycommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable PaymentHistory(string stdid)
        {
            if (myconnection.State == ConnectionState.Open)
                myconnection.Close();
            myconnection.Open();
            mycommand.CommandType = CommandType.Text;
            string s = "select * from Payments where StudentId='" + stdid + "'";
            mycommand.CommandText = s;
            mycommand.Connection = myconnection;
            SqlDataAdapter sda = new SqlDataAdapter(mycommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}
