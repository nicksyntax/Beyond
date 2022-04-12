using Beyond.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeyondWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        ProductsBusiness products = new ProductsBusiness();

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public JsonResult GetProducts()
        {
            var jsonResult = string.Empty;
            try
            {
                var apiRresult = products.GetAllProducts();
                return new JsonResult(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    Result = apiRresult
                }); ;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new JsonResult(null)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            finally { }
        }
    }
}
