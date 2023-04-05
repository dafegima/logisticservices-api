namespace LogisticService.Domain.Exceptions.Models
{
    public class CustomValidation
    {
        public string Field { get; set; }
        public string[] Errors { get; set; }
    }
}