using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Application.Validation
{
    public class ValidationAppResult
    {
        private readonly List<ValidationAppError> errorList = new List<ValidationAppError>();

        public string Message { get; set; }
        public bool IsValid {
            get { return errorList.Count == 0; }
            set
            {
                var b = value;
            }
        }
        public ICollection<ValidationAppError> Erros { get { return this.errorList; } }
    }
}
