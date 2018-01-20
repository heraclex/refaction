using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RefactorMe.Services;
using RefactorMe.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.ApiTest
{
    [TestClass]
    public abstract class BaseControllerTest
    {
        protected Mock<IProductService> mockService;

        [TestInitialize]
        public virtual void Setup()
        {
            this.mockService = new Mock<IProductService>();

            var products = TestingDataDource.ProductModelList;

            // Mock get all product Method on Service
            mockService.Setup(m => m.GetAllProducts()).Returns(() => {                
                return products;
            });

            // Mock Search product Method on Service
            mockService.Setup(m => m.FindProductsByName(It.IsAny<string>())).Returns((string filterCriteria) => {
                if (string.IsNullOrEmpty(filterCriteria))
                {
                    return products;
                }

                return products.Where(x => x.Name.Contains(filterCriteria)).ToList();
            });

            // Mock inSert product on Service
            mockService.Setup(m => m.InsertProduct(It.IsAny<ProductModel>())).Returns((ProductModel m) =>
            {
                if (m.Id == Guid.Empty)
                    m.Id = Guid.NewGuid();
                return m;
            });

            // Mock IsProductExist Method on Service
            mockService.Setup(m => m.IsProductExist(It.IsAny<Guid>())).Returns((Guid id) =>
            {
                return TestingDataDource.ProductModelList.Any(x => x.Id == id);
            });

            // Mock GetProduct By Id Method on Service
            mockService.Setup(m => m.GetProductById(It.IsAny<Guid>())).Returns((Guid id) =>
            {
                return TestingDataDource.ProductModelList.FirstOrDefault(x => x.Id == id);
            });

            // Mock DeleteProduct By Id Method on Service
            mockService.Setup(m => m.DeleteProduct(It.IsAny<Guid>())).Verifiable();
        }
    }
}
