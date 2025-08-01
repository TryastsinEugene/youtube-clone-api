using Microsoft.AspNetCore.Identity;
using Shared.DTOs;

namespace Service.Abstractions
{
	public interface IAuthenticationService
	{
		Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
		Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
		Task<string> CreateToken();
	}
}
