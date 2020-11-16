using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InteriumMiddleware.Models
{
    public class UserCredential
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public ClientCredential ClientCredentials { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string CredentialsId { get; set; }
        public string ExpirationDate { get; set; }
        public string ExchangeCode { get; set; }
    }

    public struct AuthExchange
    {
        public string grant_type;
        public string client_id;
        public string client_secret;
        public string redirect_uri;
        public string code;
        public string refresh_token;
    };

    public class AuthTokenResponse
    {
        public string access_token;
        public int expires_in;
        public string token_type;
        public string refresh_token;
        public string scope;
    }
}
