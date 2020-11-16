using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteriumMiddleware.Models
{
    public class AccountStandingOrdersRequest
    {
        public AccountStandingOrder[] results { get; set; }
        public string status { get; set; }
    }

    public class AccountStandingOrder
    {
        public string frequency { get; set; }
        public string status { get; set; }
        public DateTime timestamp { get; set; }
        public string currency { get; set; }
        public AccountStandingOrderMeta meta { get; set; }
        public DateTime next_payment_date { get; set; }
        public float next_payment_amount { get; set; }
        public DateTime first_payment_date { get; set; }
        public float first_payment_amount { get; set; }
        public DateTime final_payment_date { get; set; }
        public float final_payment_amount { get; set; }
        public string reference { get; set; }
        public string payee { get; set; }
    }

    public class AccountStandingOrderMeta
    {
        public string provider_account_id { get; set; }
        public string provider_standing_order_id { get; set; }
    }

}
