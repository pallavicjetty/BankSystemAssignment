using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSystemAssignment.Model
{
    public class UserModel
    {
        public int userId { get; set; }
        public string userName { get; set; } 
    }
    public class UserAccount
    {
        public int accountId { get; set; }
        public int userId { get; set; }
        public double money { get; set; }
    }

}
