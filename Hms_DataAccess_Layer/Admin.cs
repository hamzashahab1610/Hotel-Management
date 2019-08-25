using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms_DataAccess_Layer
{
    interface Admin
    {
        int Add_Student(string studentid, string fname, string lname, string mobile, string email, string doj, string fee, string pwd, string add);
    }
}
