using NorthWind.Domain.ValueObjects;

namespace NorthWind.Domain.Interfaces.Validation
{
    public interface ISelfValidator
    {
        bool IsValid();
        ValidationResult ValidationResult { get; }
    }
}
