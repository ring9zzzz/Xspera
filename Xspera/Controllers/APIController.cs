using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Xspera.BAL.Services;
using Xspera.Core.Models;

namespace Xspera.Controllers
{
    [Route("xpera/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private IProductService _productService;
        private IReviewService _reviewService;

        public APIController(IProductService productService, IReviewService reviewService)
        {
            _productService = productService;
            _reviewService = reviewService;
        }

        // GET api/values
        [HttpGet()]
        public ActionResult GetListProduct(int brandId = 0,int pageNo = 1 ,int pageSize  = 10)
        {
            var data = _productService.GetListProduct(brandId, pageNo, pageSize );
            if (!data.Any())
            {
                return NotFound("Not found");
            }
            return Ok(data);
        }

        [HttpGet("getprodbyid")]
        public ActionResult GetById(int productId)
        {
            if (productId == 0)
            {
                throw new Exception("request parameter incorrect.");
            }
            var data = _productService.GetProduct(productId);
            if (data.Values.FirstOrDefault() == null)
            {
                return NotFound();
            }
            return Ok(data.Values);
        }

        [HttpPost("addingreview")]
        public ActionResult AddingReview([FromBody] ReviewRequest requestData)
        {
            if (requestData.ProductId == 0 || requestData.Rating == 0 || requestData.Comment == null || string.IsNullOrWhiteSpace(requestData.Email))
            {
                throw new Exception("request parameter incorrect.");
            }
            var data = _reviewService.AddingReview(requestData);
            if (data.ContainsKey(false))
            {
                throw new Exception(data.Values.FirstOrDefault());
            }
            return Ok(data.Keys.FirstOrDefault());
        }
        [HttpPost("createprod")]
        public ActionResult CreateProduct([FromBody] ProductRequest requestData)
        {
            //because availableStatus we use int instead of int? so we don't need set this data to request because its always 0 if we don't set it 
            if (string.IsNullOrWhiteSpace(requestData.Name) || requestData.BrandId == 0 || requestData.UserId == 0 || requestData.Price == 0)
            {
                throw new Exception("request parameter incorrect.");
            }
            var data = _productService.CreateProduct(requestData);
            if (data.ContainsKey(false))
            {
                throw new Exception(data.Values.FirstOrDefault());
            }
            return Ok(data.Values.FirstOrDefault());
        }
    }
}