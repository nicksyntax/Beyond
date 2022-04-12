using Beyond.Business;
using BeyondWebApi.Models;
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
    public class PostController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        PostBusiness post = new PostBusiness();

        public PostController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public JsonResult GetPosts(PostModel Request)
        {
            var jsonResult = string.Empty;
            try
            {
                if (null == Request?.Keyword)
                {
                    return new JsonResult(null)
                    {
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                var apiRresult = post.CallExternalPostApi(Request.Keyword);
                return new JsonResult(new
                {
                    StatusCode = apiRresult?.StatusCode != null ? apiRresult.StatusCode : StatusCodes.Status400BadRequest,
                    Result = apiRresult?.result
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
