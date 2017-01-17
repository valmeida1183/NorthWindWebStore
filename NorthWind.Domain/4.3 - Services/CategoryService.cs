using NorthWind.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthWind.Domain.Entities;
using NorthWind.Domain.Interfaces.Repository;
using NorthWind.Domain.Validations.Categories;

namespace NorthWind.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        
        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return categoryRepository.GetById(id);
        }

        public Category Add(Category category)
        {
            // Domain rules validation
            if (!category.IsValid())
            {
                return category;
            }

            category.ValidationResult = new CategoryCanBeAdded(categoryRepository).Validate(category);
            if (!category.ValidationResult.IsValid)
            {
                return category;
            }

            category.ValidationResult.Message = "Category added with success";
            return categoryRepository.Add(category);
        }

        public Category Update(Category category)
        {
            return categoryRepository.Update(category);
        }

        public void Remove(Category category)
        {
            categoryRepository.Remove(category);
        }


    }
}
