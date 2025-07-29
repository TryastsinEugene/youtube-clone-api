namespace Domain.Repositories
{
	public interface IRepositoryManager
	{
		ICategoryRepository Category { get; }
		Task SaveAsync();
	}
}
