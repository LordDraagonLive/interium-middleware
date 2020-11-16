using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteriumMiddleware.Models
{
    public class AccountDirectDebitRequest
    {
        public DirectDebit[] results { get; set; }
        public string status { get; set; }
    }

    public class DirectDebit
    {
        public string direct_debit_id { get; set; }
        public DateTime timestamp { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public float previous_payment_amount { get; set; }
        public string currency { get; set; }
        public DirectDebitMeta meta { get; set; }
        public DateTime previous_payment_timestamp { get; set; }
    }

    public class DirectDebitMeta
    {
        public string provider_account_id { get; set; }
        public string provider_mandate_identification { get; set; }
    }

}
