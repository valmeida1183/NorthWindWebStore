using NorthWind.Domain.Entities;
using NorthWind.Domain.Interfaces.Specification;

namespace NorthWind.Domain.Specifications.Categories
{
    // Essa validação é só um exemplo de como a entidade se auto-valida. Pois na verdade a validação de consistência
    // de formulário (campos mandatórios) deve ser feita na camada de aplicação.
    public class CategoryShouldHaveName : ISpecification<Category>
    {
        public bool IsSatisfiedBy(Category entity)
        {
            return !string.IsNullOrWhiteSpace(entity.CategoryName);
        }
    }
}
