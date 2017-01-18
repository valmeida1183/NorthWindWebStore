using NorthWind.Domain.Entities;
using NorthWind.Domain.Interfaces.Repository;
using NorthWind.Domain.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Domain.Specifications.Categories
{
    public class CategoryWithValidID : ISpecification<Category>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryWithValidID(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public bool IsSatisfiedBy(Category entity)
        {            
            return categoryRepository.GetById(entity.CategoryId, true) != null;
            //return true;
        }
    }
}
