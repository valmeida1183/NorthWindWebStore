using NorthWind.Domain.Interfaces.Repository;
using NorthWind.Domain.Interfaces.Specification;
using NorthWind.Domain.Entities;
using System.Linq;

namespace NorthWind.Domain.Specifications.Categories
{
    public class CategoryWithUniqueName : ISpecification<Category>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryWithUniqueName(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public bool IsSatisfiedBy(Category entity)
        {
            // Retorna falso se já existir uma categoria com o mesmo nome.
            return !categoryRepository.Search(c => c.CategoryName == entity.CategoryName).Any();
        }
    }
}
