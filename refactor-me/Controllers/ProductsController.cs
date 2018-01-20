using System;
using System.Net;
using System.Web.Http;
using refactor_me.Models;
using RefactorMe.Services;
using System.Collections.Generic;

namespace refactor_me.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IEnumerable<string> Get()
        {
            var prods = this.productService.GetAllProducts();

            return new string[] { "value1", "value2" };

            
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
