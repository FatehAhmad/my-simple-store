using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using GetProductsMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GetProductsMVC.Controllers
{
    public class AuthController : Controller
    {
        private IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _context;


        public AuthController(IHttpClientFactory httpClientFactory, IHttpContextAccessor context)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<string> GetToken()
        {
            var client = _httpClientFactory.CreateClient("Auth");

            var dict = new Dictionary<string, string>();
            dict.Add("grant_type", "client_credentials");
            dict.Add("client_id", "cl_$xVN8s0YxxxA4A676jFy4wsCXBG9xsR5AMx3Vs");
            dict.Add("client_secret", "1InM0IdOV0OeIYw05bYPuqk504GcDL4z2MjFERUXF3f1AUyW4mQt9WTbz9voFTZe");


            var res = await client.PostAsync(client.BaseAddress, new FormUrlEncodedContent(dict));
            var str = res.Content.ReadAsStringAsync();

            var authentication = JsonConvert.DeserializeObject<Authentication>(str.Result);


            _context.HttpContext.Session.SetString("token", authentication.Access_Token);

            var token = HttpContext.Session.GetString("UserId");



            //write token to cookie
            //AuthenticationProperties options = new AuthenticationProperties();

            //options.IsPersistent = true;
            //options.ExpiresUtc = DateTime.UtcNow.AddSeconds(authentication.Expires_In);

            //var claims = new[]
            //{
            //    new Claim("AcessToken", string.Format("Bearer {0}", authentication.Access_Token)),
            //};
            //ClaimsIdentity identity = new ClaimsIdentity(claims, "ApplicationCookie");
            //ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            //await AuthenticationHttpContextExtensions.SignInAsync(_context.HttpContext, principal);

            ////var a = await AuthenticationHttpContextExtensions.AuthenticateAsync.SignIn(options, identity);

            ////await HttpContext.Authentication.SignInAsync("CookieAuthentication", principal);







            return authentication.Access_Token;
        }
    }
}