using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InteriumMiddleware.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Server.IIS;

namespace InteriumMiddleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AccountsContext _context;

        public AccountsController(AccountsContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            string token = Request.Headers["Token"];
            return await GetAllAccounts(token);
        }

        private async Task<ActionResult<IEnumerable<Account>>> GetAllAccounts(string token)
        {

            string url = "https://api.truelayer-sandbox.com/data/v1/accounts";
            List<Account> accounts = null;
            //AccountsRequest accountsResponse = null;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var resData = await response.Content.ReadAsStringAsync();
                    var accountsResponse = JsonConvert.DeserializeObject<AccountsRequest>(resData);
                    accounts = accountsResponse.results.ToList();
                }
                else
                {
                    return BadRequest(response.ReasonPhrase);
                }

            }

            return accounts;
        }


        // GET: api/Accounts/GetAccountBalance
        //[HttpGet("{id}")]
        [HttpGet("GetAccountBalance")]
        public async Task<ActionResult<AccountBalance[]>> GetAccountBalance(string id, string token)
        {
            //acc No = 56c7b029e0f8ec5a2334fb0ffc2fface
            // 


            //var account = await _context.Account.FindAsync(id);

            //if (account == null)
            //{
            //    return NotFound();
            //}

            //return account;
            string url = $"https://api.truelayer-sandbox.com/data/v1/accounts/{id}/balance";

            AccountBalance[] accountBalance = null;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var resData = await response.Content.ReadAsStringAsync();
                    var accountsResponse = JsonConvert.DeserializeObject<AccountBalanceRequest>(resData);
                    accountBalance = accountsResponse.results;
                }
                else
                {
                    return BadRequest(response.ReasonPhrase);
                }

            }
            return accountBalance;

        }


        // GET: api/Accounts/GetAccountTransactions
        [HttpGet("GetAccountTransactions")]
        public async Task<ActionResult<AccountTransaction[]>> GetAccountTransactions(string id, string token)
        {
            string url = $"https://api.truelayer-sandbox.com/data/v1/accounts/{id}/transactions";

            AccountTransaction[] accountTransactions = null;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var resData = await response.Content.ReadAsStringAsync();
                    var accountsResponse = JsonConvert.DeserializeObject<AccountTransactionRequest>(resData);
                    accountTransactions = accountsResponse.results;
                }
                else
                {
                    return BadRequest(response.ReasonPhrase);
                }

            }
            return accountTransactions;

        }

        // GET: api/Accounts/GetPendingTransactions
        [HttpGet("GetPendingTransactions")]
        public async Task<ActionResult<AccountTransaction[]>> GetPendingTransactions(string id, string token)
        {
            string url = $"https://api.truelayer-sandbox.com/data/v1/accounts/{id}/transactions/pending";

            AccountTransaction[] accountTransactions = null;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var resData = await response.Content.ReadAsStringAsync();
                    var accountsResponse = JsonConvert.DeserializeObject<PendingTransactionRequest>(resData);
                    accountTransactions = accountsResponse.results;
                }
                else
                {
                    return BadRequest(response.ReasonPhrase);
                }

            }
            return accountTransactions;

        }


        // GET: api/Accounts/GetDirectDebits
        [HttpGet("GetDirectDebits")]
        public async Task<ActionResult<DirectDebit[]>> GetDirectDebits(string id, string token)
        {
            string url = $"https://api.truelayer-sandbox.com/data/v1/accounts/{id}/direct_debits";

            DirectDebit[] directDebits = null;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var resData = await response.Content.ReadAsStringAsync();
                    var accountsResponse = JsonConvert.DeserializeObject<AccountDirectDebitRequest>(resData);
                    directDebits = accountsResponse.results;
                }
                else
                {
                    return BadRequest(response.ReasonPhrase);
                }

            }
            return directDebits;

        }

        // GET: api/Accounts/GetStandingOrders
        [HttpGet("GetStandingOrders")]
        public async Task<ActionResult<AccountStandingOrder[]>> GetStandingOrders(string id, string token)
        {
            string url = $"https://api.truelayer-sandbox.com/data/v1/accounts/{id}/standing_orders";

            AccountStandingOrder[] standingOrders = null;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var resData = await response.Content.ReadAsStringAsync();
                    var accountsResponse = JsonConvert.DeserializeObject<AccountStandingOrdersRequest>(resData);
                    standingOrders = accountsResponse.results;
                }
                else
                {
                    return BadRequest(response.ReasonPhrase);
                }

            }
            return standingOrders;

        }


        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(string id)
        {
            var account = await _context.Account.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(string id, Account account)
        {
            if (id != account.account_id)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Accounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
            _context.Account.Add(account);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AccountExists(account.account_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAccount", new { id = account.account_id }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Account>> DeleteAccount(string id)
        {
            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Account.Remove(account);
            await _context.SaveChangesAsync();

            return account;
        }

        private bool AccountExists(string id)
        {
            return _context.Account.Any(e => e.account_id == id);
        }
    }
}
