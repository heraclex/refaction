using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using refactor_me.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using RefactorMe.Services.Models;
using System.Collections.Generic;
using refactor_me.Models;

namespace RefactorMe.ApiTest
{
    [TestClass]
    public class ProductControllerTest : BaseControllerTest
    {
        [TestMethod]
        public void TestGetAllProducts()
        {
            // Agrange
            var controller = new ProductsController(this.mockService.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.Get();
            // Assert
            Assert.IsNotNull(response);
            
            Assert.IsTrue(response.TryGetContentValue(out ProductsReturn productReturn));

            var products = productReturn.Items as List<ProductModel>;
            Assert.AreEqual(TestingDataDource.ProductModelList.Count, products.Count);
            Assert.AreEqual(TestingDataDource.ProductModelList[0].Name, products[0].Name);
        }
    }
}
