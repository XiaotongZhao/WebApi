using Infrastructure.Common.Authorization;
using Infrastructure.Common.Authorization.service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : BaseController
    {
        private readonly IAuthenticateService authService;

        public AuthenticateController(IAuthenticateService authService)
        {
            this.authService = authService;
        }
        [AllowAnonymous]
        [HttpPost, Route("request")]
        public IActionResult RequestToken(TokenRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token;
            if (authService.IsAuthenticated(request, out token))
            {
                return Ok(token);
            }

            return BadRequest("Invalid Request");
        }
    }
}