using System;
using System.Net;
using System.Web.Http;
using RefactorMe.Services;
using System.Collections.Generic;

namespace refactor_me.Controllers
{
    [RoutePrefix("api/products/{productId}/options")]
    public class ProductOptionsController : ApiController
    {
        private readonly IProductService productService;
        public ProductOptionsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IEnumerable<string> Get(int productId)
        {
            //var prods = this.productService.GetAllProductOptions(new Guid());

            return new string[] { "value1", "value2" };

            
        }

        // GET api/values/5
        public string Get(int productId, int id)
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
