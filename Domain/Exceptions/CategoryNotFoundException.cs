namespace Domain.Exceptions
{
	public sealed class CategoryNotFoundException : NotFoundException
	{
		public CategoryNotFoundException(Guid id)
			: base($"The category with id: {id} doesn't exist in the database.")
		{
		}
		public CategoryNotFoundException(string name)
			: base($"The category with name: {name} doesn't exist in the database.")
		{
		}
	}
}
