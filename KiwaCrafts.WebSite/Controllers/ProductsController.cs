using KiwaCrafts.WebSite.Models;
using KiwaCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KiwaCrafts.WebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public JsonFileProductService ProductService { get; set; }

        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        //[HttpPatch]
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery] string ProductId, 
            [FromQuery] int Rating)
        { 
            ProductService.AddRating(ProductId, Rating);
            return Ok();
        }
    }
}
