using Domain.Entities;
using Domain.Repositories;

namespace Persistance.Repositories
{
	public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
	{
		public CategoryRepository(RepositoryDbContext context) : base(context)
		{
		}

		public void CreateCategory(Category category) => Create(category);

		public IEnumerable<Category> GetAllCategories(bool trackChanges) =>
			FindAll(trackChanges)
				.OrderBy(c => c.Name)
				.ToList();

		public Category GetCategory(Guid categoryId, bool trackChanges) =>
			FindByCondition(c => c.Id.Equals(categoryId), trackChanges)
			.SingleOrDefault();

	}
	
}
