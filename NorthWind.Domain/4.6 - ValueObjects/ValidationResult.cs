using System.Collections.Generic;
using System.Linq;

namespace NorthWind.Domain.ValueObjects
{
    public class ValidationResult
    {
        private readonly List<ValidationError> errorList = new List<ValidationError>();
        public string Message { get; set; }
        public bool IsValid { get { return errorList.Count == 0; } }
        public IEnumerable<ValidationError> Errors { get { return errorList; } }

        public void AddError(ValidationError erro)
        {
            errorList.Add(erro);
        }

        public void AddError(params ValidationResult[] validationResult)
        {
            if (validationResult == null)
            {
                return;
            }

            foreach(var validation in validationResult.Where(result => result != null))
                errorList.AddRange(validation.Errors);
        }

        public void RemoveError(ValidationError error)
        {
            if (errorList.Contains(error))
            {
                errorList.Remove(error);
            }
        }
    }
}
