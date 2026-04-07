using System.Security.Claims;
using API.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class BuggyController : BaseAPIController
    {
        
        [HttpGet("unauthorized")]
        public ActionResult<string> GetUnauthorized()
        {
            return Unauthorized("You are not authorized to access this resource.");
        }

        [HttpGet("badrequest")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This is a bad request.");
        }


        [HttpGet("NotFound")]
        public ActionResult<string> GetNotFound()
        {
            return NotFound("The requested resource was not found.");
        }

        [HttpGet("internalerror")]
        public ActionResult<string> GetInternalError()
        {
            throw new Exception("This is an internal server error.");
        }

        [HttpPost("validationerror")]
        public ActionResult<string> GetValidationError(CreateProductDto product)
        {
            return Ok();
        }

        [Authorize]
        [HttpGet("secret")]
        public IActionResult GetSecret()
        {
            var name = User.FindFirst(ClaimTypes.Name)?.Value;
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok("Hello " + name + " with the id of " + id );

        }        
    }






}

