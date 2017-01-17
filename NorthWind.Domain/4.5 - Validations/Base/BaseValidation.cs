using NorthWind.Domain.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthWind.Domain.ValueObjects;

namespace NorthWind.Domain.Validations.Base
{
    public abstract class BaseValidation<TEntity> : IBaseValidation<TEntity> where TEntity : class
    {
        private readonly Dictionary<string, IRule<TEntity>> validations = new Dictionary<string, IRule<TEntity>>();

        protected virtual void AddRule(string ruleName, IRule<TEntity> rule)
        {
            validations.Add(ruleName, rule);
        }

        protected virtual void RemoveRule(string ruleName)
        {
            validations.Remove(ruleName);
        }

        public ValidationResult Validate(TEntity entity)
        {
            var result = new ValidationResult();
            foreach (var item in validations.Keys)
            {
                var rule = validations[item];
                if (!rule.Validate(entity))
                {
                    result.AddError(new ValidationError(rule.ErrorMessage));
                }
            }

            return result;
        }

        protected IRule<TEntity> GetRule(string ruleName)
        {
            IRule<TEntity> rule;
            validations.TryGetValue(ruleName, out rule);
            return rule;
        }
    }
}
