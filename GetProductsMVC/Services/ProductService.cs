using GetProductsMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;


namespace GetProductsMVC.Services
{
    public interface IProductService
    {
        Task<ResponseObject<List<Product>>> GetAsync();
    }

    public class ProductService : IProductService
    {
        private IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _context;
        private readonly IAuthService _authService;


        public ProductService(IHttpClientFactory httpClientFactory, IHttpContextAccessor context, IAuthService authService)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
            _authService = authService;
        }

        //get products
        public async Task<ResponseObject<List<Product>>> GetAsync()
        {
            //create client and add request headers
            //TODO:  only create client if its not already created
            var simpleStoreClient = _httpClientFactory.CreateClient("simplestore");
            simpleStoreClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + await _authService.GetToken(false));

            //make request to the get products endpoint
            var res = await simpleStoreClient.GetAsync(simpleStoreClient.BaseAddress + "v1/products");

            if (res.StatusCode == HttpStatusCode.OK)
            {
                var responseObject = JsonConvert.DeserializeObject<ResponseObject<List<Product>>>(res.Content.ReadAsStringAsync().Result);
                //optionaly log the additional properties on the responseObject below

                //return status code to frontend
                responseObject.StatusCode = res.StatusCode.ToString();

                //return result
                return responseObject;
            }
            //if token is expired
            else if (res.StatusCode == HttpStatusCode.Unauthorized)
            {
                //remove previous token
                simpleStoreClient.DefaultRequestHeaders.Remove("Authorization");

                //add new token
                simpleStoreClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + await _authService.GetToken(true));

                //make another request with new token
                var res1 = await simpleStoreClient.GetAsync(simpleStoreClient.BaseAddress + "v1/products");

                var response = JsonConvert.DeserializeObject<ResponseObject<List<Product>>>(res1.Content.ReadAsStringAsync().Result);
                //optionaly log the additional properties on the responseObject below

                //return status code to frontend
                response.StatusCode = res1.StatusCode.ToString();

                //return result
                return response;
            }
            else
            {
                return new ResponseObject<List<Product>>() { StatusCode = res.StatusCode.ToString() };
            }
        }
    }



}
