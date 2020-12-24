using System.ComponentModel.DataAnnotations;

namespace TesteApp.Attributes
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (bool)value;
        }
    }
}
