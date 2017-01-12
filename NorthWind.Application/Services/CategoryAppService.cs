using NorthWind.Application.Interfaces;
using System.Dynamic;
using NorthWind.Domain.Interfaces.Service;
using NorthWind.Infra.Data.Interface;
using NorthWind.Domain.Entities;
using AutoMapper;

namespace NorthWind.Application.Services
{
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly ICategoryService categoryService;
        public CategoryAppService(ICategoryService categoryService, IUnitOfWork uow) : base(uow)
        {
            this.categoryService = categoryService;
        }
                
        public ExpandoObject GetAll()
        {
            dynamic expando = new ExpandoObject();
            expando.categories = categoryService.GetAll();
                        
            return expando;
        }

        public ExpandoObject GetById(int id)
        {
            dynamic expando = new ExpandoObject();
            expando.category = categoryService.GetById(id);

            return expando;
        }

        public ExpandoObject Add(ExpandoObject category)
        {
            BeginTransaction();
            
            var entity = DynamicMapper.DynamicToEntity.ToEntity<Category>(category);

            if (string.IsNullOrEmpty(entity.CategoryName)) // change to validation concern pattern
            {
                return null;
            }
            
            dynamic expando = new ExpandoObject();
            expando.category = categoryService.Add(entity);

            Commit();
            //var id = expando.category.CategoryId;

            return expando;
        }
    }
}
