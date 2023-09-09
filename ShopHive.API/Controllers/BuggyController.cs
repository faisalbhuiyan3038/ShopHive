using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopHive.API.Data;
using Microsoft.EntityFrameworkCore;
using ShopHive.API.Errors;

namespace ShopHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseAPIController
    {
        private readonly ShopHiveDbContext _context;

        public BuggyController(ShopHiveDbContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(42);

            if(thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(42);

            var thingToReturn = thing.ToString();
            return Ok();
        }

        [HttpGet("badRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badRequest/{id}")]
        public ActionResult GetBadRequest2(int id)
        {
            return Ok();
        }
    }
}
