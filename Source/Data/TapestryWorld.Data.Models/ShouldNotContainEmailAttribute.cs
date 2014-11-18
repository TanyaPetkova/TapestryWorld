namespace TapestryWorld.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ShouldNotContainEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            if (valueAsString == null)
            {
                return false;   
            }

            return true;
        }
    }
}
