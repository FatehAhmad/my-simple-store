using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GetProductsMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace GetProductsMVC.Controllers
{
    public class ProductsController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public ProductsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            //GetToken();
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

            Authentication authentication = JsonConvert.DeserializeObject<Authentication>(str.Result);

            return authentication.access_token;
        }


        // GET: Products
        public async Task<ActionResult> Index()
        {
            var token = await GetToken();
            var client = _httpClientFactory.CreateClient("simplestore");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var res = await client.GetAsync(client.BaseAddress + "v1/products");
            var str = res.Content.ReadAsStringAsync();
            var pros = str.Result;

            ResponseObject products = JsonConvert.DeserializeObject<ResponseObject>(str.Result);

            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}