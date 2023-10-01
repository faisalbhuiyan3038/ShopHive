using Microsoft.AspNetCore.Mvc;
using ShopHive.API.Errors;

public static class ApiResponseExtensions
{
    public static IActionResult ToActionResult(this ApiResponse apiResponse)
    {
        var statusCode = apiResponse.StatusCode;

        if (statusCode == 200)
        {
            return new OkObjectResult(apiResponse);
        }
        else if (statusCode == 400)
        {
            return new BadRequestObjectResult(apiResponse);
        }
        else if (statusCode == 401)
        {
            return new UnauthorizedObjectResult(apiResponse);
        }
        else if (statusCode == 404)
        {
            return new NotFoundObjectResult(apiResponse);
        }
        else if (statusCode == 500)
        {
            return new ObjectResult(apiResponse)
            {
                StatusCode = 500
            };
        }
        else
        {
            return new ObjectResult(apiResponse)
            {
                StatusCode = statusCode
            };
        }
    }
}
