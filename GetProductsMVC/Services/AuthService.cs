using GetProductsMVC.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetProductsMVC.Services
{
    public interface IAuthService
    {
        Task<string> GetToken(bool tokenExpired);
    }
    public class AuthService : IAuthService
    {
        private IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _context;

        public AuthService(IHttpClientFactory httpClientFactory, IHttpContextAccessor context)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
        }

        public async Task<string> GetToken(bool tokenExpired)
        {
            if (_context.HttpContext.Session.GetString("token") != null && tokenExpired == false)
            {
                return _context.HttpContext.Session.GetString("token");
            }

            var authClient = _httpClientFactory.CreateClient("Auth");

            var dict = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", "cl_$xVN8s0YxxxA4A676jFy4wsCXBG9xsR5AMx3Vs" },
                { "client_secret", "1InM0IdOV0OeIYw05bYPuqk504GcDL4z2MjFERUXF3f1AUyW4mQt9WTbz9voFTZe" }
            };
            var res = await authClient.PostAsync(authClient.BaseAddress, new FormUrlEncodedContent(dict));

            if (res.StatusCode == HttpStatusCode.OK)
            {
                var authentication = JsonConvert.DeserializeObject<Authentication>(res.Content.ReadAsStringAsync().Result);

                _context.HttpContext.Session.SetString("token", authentication.Access_Token);

                return authentication.Access_Token;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
