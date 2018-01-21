using Microsoft.VisualStudio.TestTools.UnitTesting;
using refactor_me.Controllers;
using RefactorMe.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;

namespace RefactorMe.ApiTest
{
    [TestClass]
    public class ProductControllerUrlTest : BaseControllerTest
    {
        [TestMethod]
        public void PostProductUrlReturnHeader()
        {
            // Arrange
            ProductsController controller = new ProductsController(this.mockService.Object);

            controller.Request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost/api/products")
            };
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary { { "controller", "products" } });

            // Act
            ProductModel product = TestingDataDource.ValidNewProductModel;

            var response = controller.Post(product);

            // Assert
            Assert.AreEqual("http://localhost/api/products/" + product.Id.ToString(), 
                response.Headers.Location.AbsoluteUri);
        }
    }
}
