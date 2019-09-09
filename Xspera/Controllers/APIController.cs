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
        public ActionResult Get(int brandId = 0,int pageNo = 1 ,int pageSize  = 10)
        {
            var data = _productService.GetListProduct(brandId, pageNo, pageSize );
            if (data == null)
            {
                throw new Exception("Not found");
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
            if (data.Values == null)
            {
                throw new Exception(data.Keys.FirstOrDefault());
            }
            return Ok(data.Values);
        }

        // POST api/values
        [HttpPost("addingreview")]
        public ActionResult Post([FromBody] ReviewRequest requestData)
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
    }
}