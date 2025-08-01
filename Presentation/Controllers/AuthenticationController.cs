using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Service.Abstractions;
using Shared.DTOs;

namespace Presentation.Controllers
{
	[Route("api/authentication")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IServiceManager _service;
		public AuthenticationController(IServiceManager service)
		{
			_service = service;
		}

		[ServiceFilter(typeof(ValidationFilterAttribute))]
		public async Task<IActionResult> Register([FromBody] UserForRegistrationDto userForRegistration)
		{
			var result = await _service.AuthenticationService.RegisterUser(userForRegistration);
			if (!result.Succeeded)
			{
				foreach(var error in result.Errors)
				{
					ModelState.TryAddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);

			}
			return StatusCode(201);
		}
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto user)
		{
			if(!await _service.AuthenticationService.ValidateUser(user))
				return Unauthorized();
			
			return Ok(new
			{
				Token = await _service.AuthenticationService.CreateToken()
			});
		}
	}
}
