using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms_BusinessLogic_Layer
{
   public class PaymentsClass
    {
        public string StudentId { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }

        public PaymentsClass(string StudentId1, string Amount1, string Date1)
        {
            StudentId = StudentId1;
            Amount = Amount1;
            Date = Date1;
        }
        public PaymentsClass()
        {

        }
        public virtual int dueamount(int totalamount, int payamount)
        {
            return 0;
        }
        public override string ToString()
        {
            return "StudentId: " + StudentId + "   Amount: " + Amount + "   Date: " + Date;
        }
    }
}
