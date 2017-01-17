using NorthWind.Domain.Entities;
using NorthWind.Domain.Interfaces.Repository;
using NorthWind.Domain.Validations.Base;
using NorthWind.Domain.Specifications.Categories;

namespace NorthWind.Domain.Validations.Categories
{
    public class CategoryCanBeAdded : BaseValidation<Category>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryCanBeAdded(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;

            var categoryUniqueName = new CategoryWithUniqueName(this.categoryRepository);

            base.AddRule("CategoryNameDuplicate", new Rule<Category>(categoryUniqueName, "This category name already exists"));
        }
    }
}
