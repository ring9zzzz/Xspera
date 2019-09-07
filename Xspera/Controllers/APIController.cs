using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Xspera.BAL.Services;
using Xspera.Core.Models;
using Xspera.DAL.Entities;
using System.Linq;
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
        public ActionResult Get(int brandId = 0)
        {
            var data = _productService.GetListProduct(brandId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet("getprodbyid")]
        public ActionResult GetById(int productId)
        {
            if (productId == 0)
            {
                return BadRequest("request parameter incorrect.");
            }
            var data = _productService.GetProduct(productId);
            if (data.Values == null)
            {
                return NotFound(data.Keys.FirstOrDefault());
            }
            return Ok(data.Values);
        }

        // POST api/values
        [HttpPost("addingreview")]
        public ActionResult Post([FromBody] ReviewRequest requestData)
        {
            if (requestData.ProductId == 0 || requestData.UserId == 0 || requestData.Rating == 0 || requestData.Comment == null || string.IsNullOrWhiteSpace(requestData.Email))
            {
                return BadRequest("request parameter incorrect.");
            }
            var data = _reviewService.AddingReview(requestData);
            if (data.ContainsKey(false))
            {
                return BadRequest(data.Values.FirstOrDefault());
            }
            return Ok(data.Keys.FirstOrDefault());
        }
    }
}