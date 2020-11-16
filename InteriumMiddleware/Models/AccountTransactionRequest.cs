using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteriumMiddleware.Models
{
    public class AccountTransactionRequest
    {
        public AccountTransaction[] results { get; set; }
        public string status { get; set; }
    }

    public class AccountTransaction
    {
        public DateTime timestamp { get; set; }
        public string description { get; set; }
        public string transaction_type { get; set; }
        public string transaction_category { get; set; }
        public string[] transaction_classification { get; set; }
        public float amount { get; set; }
        public string currency { get; set; }
        public string transaction_id { get; set; }
        public Running_Balance running_balance { get; set; }
        public Meta meta { get; set; }
    }

    public class Running_Balance
    {
        public string currency { get; set; }
        public float amount { get; set; }
    }

    public class Meta
    {
        public string provider_transaction_category { get; set; }
    }



    public class PendingTransactionRequest
    {
        public AccountTransaction[] results { get; set; }
        public string status { get; set; }
    }


}
