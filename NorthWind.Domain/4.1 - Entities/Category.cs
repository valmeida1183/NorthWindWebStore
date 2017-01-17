using NorthWind.Domain.Interfaces.Validation;
using System.Collections.Generic;
using System;
using NorthWind.Domain.ValueObjects;
using NorthWind.Domain.Validations.Categories;

namespace NorthWind.Domain.Entities
{
    public class Category: ISelfValidator
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public ValidationResult ValidationResult  { get; set; }

        public bool IsValid()
        {
            ValidationResult = new CategoryIsConsistent().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
