using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Domain.Interfaces.Validation
{
    // A palavra chave "In" na declaração do tipo genérico significa que é uma contravariante. https://msdn.microsoft.com/en-us/library/dd469484.aspx 
    public interface IRule<in TEntity>
    {
        string ErrorMessage { get; }
        bool Validate(TEntity entity);
    }
}
