using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopHive.API.Errors;

namespace ShopHive.API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseAPIController
    {
        
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
