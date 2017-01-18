using NorthWind.Application.Interfaces;
using System.Dynamic;
using NorthWind.Domain.Interfaces.Service;
using NorthWind.Infra.Data.Interface;
using NorthWind.Domain.Entities;
using AutoMapper;
using NorthWind.Application.DynamicMapper;
using System.Collections.Generic;

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

            //var category = categoryService.GetById(id);
            //dynamic expando = DynamicMap.ToExpandoObj(category);
            //return expando;
        }

        public ExpandoObject Add(ExpandoObject category)
        {
            BeginTransaction();
            
            var entity = DynamicMap.ToEntity<Category>(category);
            
            dynamic expando = new ExpandoObject();
            expando.category = categoryService.Add(entity);

            if (expando.category.ValidationResult.IsValid)
            {
                Commit();
            }
            
            return expando;
        }

        public ExpandoObject Update(ExpandoObject category)
        {
            BeginTransaction();

            var entity = DynamicMap.ToEntity<Category>(category);
            dynamic expando = new ExpandoObject();
            expando.category = categoryService.Update(entity);

            if (expando.category.ValidationResult.IsValid)
            {
                Commit();
            }
            
            return expando;
        }

        public bool Remove(int id)
        {
            BeginTransaction();
            var category = categoryService.GetById(id);

            if (category == null)
            {
                return false;
            }

            categoryService.Remove(category);

            Commit();
            return true;
        }
    }
}
