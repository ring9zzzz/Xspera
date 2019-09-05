using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Xspera.BAL.Services;
using Xspera.DAL.Entities;

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
            var data = _productService.GetProduct(brandId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        // POST api/values
        [HttpPost("addingreview")]
        public ActionResult Post([FromBody] Review requestData)
        {
            if (requestData.ProductId == 0 || requestData.UserId == 0 || requestData.Rating == 0 || requestData.Comment == null)
            {
                return BadRequest("request parameter incorrect.");
            }
            var data = _reviewService.AddingReview(requestData);
            if (data.ContainsKey(false))
            {
                return BadRequest(data.Values);
            }
            return Ok(data.Values);
        }
    }
}