using E_Commerce.Application.Common;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIBaseController : ControllerBase
    {
        public ActionResult<T> ToActionResult<T>(Result result)
        {
            if (result.IsSuccess)
            {
                return new ObjectResult(result);
            }
            else
            {
                return new ObjectResult(result.Errors);
            }

        }
        public ActionResult<T> ToActionResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                return new OkObjectResult(result.Data);

            }
            else
            {
                return ToProblem(result.Errors);
            }



        }

        protected static ObjectResult ToProblem(IReadOnlyList<Error> errors)
        {
            var firstError = errors[0];

            var statusCode = firstError.ErrorType switch
            {
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.UnAuthorized => StatusCodes.Status401Unauthorized,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Forbidden => StatusCodes.Status403Forbidden,
                _ => StatusCodes.Status500InternalServerError,

            };

            var problems = new ProblemDetails
            {
                Detail = firstError.Description,
                Title = firstError.Code,
                Status = statusCode,
                Extensions = { ["Errors"] = errors }

            };

            return new ObjectResult(problems) { StatusCode = statusCode };

        }

        protected string GetEmailFromClaimsPrincipal()
        
          => User.FindFirstValue(ClaimTypes.Email) ?? throw new UnauthorizedAccessException("User email not found");


          

    }
}
