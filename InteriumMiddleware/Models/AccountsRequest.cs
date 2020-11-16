using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InteriumMiddleware.Models
{

    public class AccountsRequest
    {
        public Account[] results { get; set; }
        public string status { get; set; }
    }

    public class Account
    {
        public DateTime update_timestamp { get; set; }
        [Key]
        public string account_id { get; set; }
        public string account_type { get; set; }
        public string display_name { get; set; }
        public string currency { get; set; }
        public Account_Number account_number { get; set; }
        public Provider provider { get; set; }
    }

    public class Account_Number
    {
        public string swift_bic { get; set; }
        [Key]
        public string number { get; set; }
        public string sort_code { get; set; }
    }

    public class Provider
    {
        public string display_name { get; set; }
        [Key]
        public string provider_id { get; set; }
        public string logo_uri { get; set; }
    }
}
