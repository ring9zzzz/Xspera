using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xspera.BAL.Services;
using Xspera.Controllers;
using Xspera.DAL.Entities;
using Xspera.DAL.Repositories;
using Xunit;

namespace Xspera.UnitTest.Controllers
{

    public class APIControllerTest
    {
        APIController _controller;
        IProductService _productService;
        IReviewService _reviewService;
        IConfiguration _configuration;

        public APIControllerTest()
        {
            var xsperaContext = new XsperaContext();
            _configuration = new ConfigurationBuilder()
            .SetBasePath(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\")))
            .AddJsonFile("appsettings.json")
            .Build();
            var repository = new MainRepository(xsperaContext, _configuration);
            _reviewService = new ReviewService(repository);
            _productService = new ProductService(repository);
            _controller = new APIController(_productService, _reviewService);
        }
        #region GetListProduct
        [Fact]
        public void GetListProduct_WhenCalled_ReturnsOkResult()
        {
            var result = _controller.GetListProduct();

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void GetListProduct_WhenCalledByBrandId_ReturnsExistedItem()
        {
            var brandId = 5;
            var okResult = _controller.GetListProduct(brandId) as OkObjectResult;

            var items = Assert.IsType<List<Product>>(okResult.Value);
            Assert.NotEmpty(items);
        }
        [Fact]
        public void GetListProduct_WhenCalledByNotExistBrandId_ReturnsNotFound()
        {
            var brandId = 9999;
            var result = _controller.GetListProduct(brandId);

            Assert.IsType<NotFoundObjectResult>(result);
        }
        #endregion
        #region GetById
        [Fact]
        public void GetById_WhenCalledById_ReturnsOkResult()
        {
            int Id = 1;
            var okResult = _controller.GetById(Id);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
        [Fact]
        public void GetById_WhenCalledById_ReturnsExistedItem()
        {
            int Id = 1;
            var okResult = _controller.GetById(Id) as OkObjectResult;
            Assert.NotNull(okResult.Value);
        }
        [Fact]
        public void GetById_WhenCalledByNotExistId_ReturnsNotFound()
        {
            int Id = 99999;
            var result = _controller.GetById(Id);

            Assert.IsType<NotFoundResult>(result);
        }
        #endregion
    }
}
