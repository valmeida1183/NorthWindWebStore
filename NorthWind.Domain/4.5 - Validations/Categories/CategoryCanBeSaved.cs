using NorthWind.Domain.Entities;
using NorthWind.Domain.Interfaces.Repository;
using NorthWind.Domain.Specifications.Categories;
using NorthWind.Domain.Validations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Domain.Validations.Categories
{
    public class CategoryCanBeSaved : BaseValidation<Category>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryCanBeSaved(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;

            var categoryValidID = new CategoryWithValidID(this.categoryRepository);

            base.AddRule("CategoryValidID", new Rule<Category>(categoryValidID, "Cannot save this category because Id do not exits"));
        }
    }
}
