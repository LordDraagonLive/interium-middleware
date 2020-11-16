using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InteriumMiddleware.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace InteriumMiddleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCredentialsController : ControllerBase
    {
        private readonly UserCredentialsContext _context;

        public UserCredentialsController(UserCredentialsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// ExchangeAuthCode returns the completed userCredential back
        /// </summary>
        /// <param name="userCredential"></param>
        /// <returns></returns>
        private async Task<UserCredential> ExchangeAuthCode(UserCredential userCredential)
        {
            string apiResponse;
            AuthTokenResponse jsonResponse;

            AuthExchange authExchangeData = new AuthExchange();
            authExchangeData.grant_type = "authorization_code";
            authExchangeData.client_id = userCredential.CredentialsId;
            authExchangeData.client_secret = userCredential.ClientCredentials.ClientSecret;
            authExchangeData.redirect_uri = userCredential.ClientCredentials.RedirectUri;
            authExchangeData.code = userCredential.ExchangeCode;

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(authExchangeData), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://auth.truelayer-sandbox.com/connect/token", content))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    jsonResponse = JsonConvert.DeserializeObject<AuthTokenResponse>(apiResponse);
                    userCredential.AccessToken = jsonResponse.access_token;
                    userCredential.ExpirationDate = jsonResponse.expires_in.ToString();
                    userCredential.RefreshToken = jsonResponse.refresh_token;

                }
            }
            return userCredential;
        }


        /// <summary>
        /// RefreshToken returns the new token
        /// </summary>
        /// <param name="userCredential"></param>
        /// <returns></returns>
        // GET: api/UserCredentials/RefreshToken
        [HttpGet("RefreshToken")]
        public async Task<ActionResult<Dictionary<string, string>>> RefreshToken(string refreshToken, string clientId, string clientSecret)
        {
            string apiResponse;
            Dictionary<string, string> jsonResponse;

            AuthExchange authExchangeData = new AuthExchange();
            authExchangeData.grant_type = "refresh_token";
            authExchangeData.client_id = clientId;
            authExchangeData.client_secret = clientSecret;
            authExchangeData.refresh_token = refreshToken;

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(authExchangeData), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://auth.truelayer-sandbox.com/connect/token", content))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    jsonResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(apiResponse);

                }
            }
            return jsonResponse;
        }

        // GET: api/UserCredentials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCredential>>> GetUserCredential()
        {
            return await _context.UserCredential.ToListAsync();
        }

        //// GET: api/UserCredentials/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserCredential>> GetUserCredential(Guid id)
        //{
        //    var userCredential = await _context.UserCredential.FindAsync(id);

        //    if (userCredential == null)
        //    {
        //        return NotFound();
        //    }

        //    return userCredential;
        //}

        // PUT: api/UserCredentials/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUserCredential(Guid id, UserCredential userCredential)
        //{
        //    if (id != userCredential.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(userCredential).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserCredentialExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/UserCredentials
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserCredential>> PostUserCredential(UserCredential userCredential)
        {
            // Set Token
            userCredential = await ExchangeAuthCode(userCredential);

            //if (_context.UserCredential.Find(userCredential.ClientCredentials.ClientId) == null)
            //{
            //    _context.UserCredential.Add(userCredential);
            //    await _context.SaveChangesAsync();
            //    return CreatedAtAction("GetUserCredential", new { id = userCredential.Id }, userCredential);
            //}
            //else
            //{
            //    throw new 
            //}
            _context.UserCredential.Add(userCredential);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUserCredential", new { id = userCredential.Id }, userCredential);

        }

        // DELETE: api/UserCredentials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserCredential>> DeleteUserCredential(Guid id)
        {
            var userCredential = await _context.UserCredential.FindAsync(id);
            if (userCredential == null)
            {
                return NotFound();
            }

            _context.UserCredential.Remove(userCredential);
            await _context.SaveChangesAsync();

            return userCredential;
        }

        //private bool UserCredentialExists(Guid id)
        //{
        //    return _context.UserCredential.Any(e => e.Id == id);
        //}
    }
}
