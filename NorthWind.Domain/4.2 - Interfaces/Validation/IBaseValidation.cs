using NorthWind.Domain.ValueObjects;

namespace NorthWind.Domain.Interfaces.Validation
{
    public interface IBaseValidation<in TEntity>
    {
        ValidationResult Validate(TEntity entity);
    }
}
