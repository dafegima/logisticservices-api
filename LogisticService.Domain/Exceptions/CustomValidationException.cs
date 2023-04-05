
using System.Text.Json;
using LogisticService.Domain.Exceptions.Models;

namespace LogisticService.Domain.Exceptions
{
    public class CustomValidationException: Exception
    {
        public CustomValidationException(List<CustomValidation> messages) 
            : base(JsonSerializer.Serialize(messages)) { }
    }
}