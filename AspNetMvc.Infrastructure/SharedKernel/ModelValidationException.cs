using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetMvc.Infrastructure.SharedKernel
{
    /// A base class for validation exception throw from a model. 
    public class ModelValidationException : Exception
    {
        /// <summary>
        /// IEnumerable
        /// using System.Collections.Generic;
        /// 
        /// ValidationResult
        /// using System.ComponentModel.DataAnnotations;
        /// </summary>        
        private readonly IEnumerable<ValidationResult> _validateionErrors;
       
        public ModelValidationException()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">The error message for this exception.</param>
        public ModelValidationException(string message) : base(message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">The error message for this exception.</param>
        /// <param name="innerException">The inner exception that is wrapped in this exception.</param>
        public ModelValidationException(string message, Exception innerException) : base(message, innerException)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">The error message for this exception.</param>
        /// <param name="innerException">The inner exception that is wrapped in this exception.</param>
        /// <param name="validationErrors">A collection of validation errors.</param>
        public ModelValidationException(string message, Exception innerException, IEnumerable<ValidationResult> validationErrors) : base(message, innerException)
        {
            _validateionErrors = validationErrors;
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="message">The error message for this exception</param>
        /// <param name="validationErrors">The inner exception that is wrapped in this exception</param>
        public ModelValidationException(string message, IEnumerable<ValidationResult> validationErrors) : base(message)
        {
            _validateionErrors = validationErrors;
        }

        /// <summary>
        /// A collection of validation errors for the entity that failed validation
        /// </summary>
        public IEnumerable<ValidationResult> ValidationErrors
        {
            get
            {
                return _validateionErrors;
            }
        }

        
    }
}
