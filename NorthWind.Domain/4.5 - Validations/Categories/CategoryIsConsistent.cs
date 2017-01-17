using NorthWind.Domain.Entities;
using NorthWind.Domain.Specifications.Categories;
using NorthWind.Domain.Validations.Base;

namespace NorthWind.Domain.Validations.Categories
{
    public class CategoryIsConsistent : BaseValidation<Category>
    {
        
        public CategoryIsConsistent()
        {
            var categoryShouldHaveName = new CategoryShouldHaveName ();

            base.AddRule("CategoryShouldHaveName", new Rule<Category>(categoryShouldHaveName, "This category should have a name"));
        }
    }
}
