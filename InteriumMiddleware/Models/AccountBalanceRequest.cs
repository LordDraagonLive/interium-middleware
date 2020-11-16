using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteriumMiddleware.Models
{
    public class AccountBalanceRequest
    {
        public AccountBalance[] results { get; set; }
        public string status { get; set; }
    }

    public class AccountBalance
    {
        public string currency { get; set; }
        public float available { get; set; }
        public float current { get; set; }
        public float overdraft { get; set; }
        public DateTime update_timestamp { get; set; }
    }
}
