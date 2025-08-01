namespace Service.Abstractions
{
	public interface IServiceManager
	{
		ICategoryService CategoryService { get; }
		IAuthenticationService AuthenticationService { get; }
	}
}
