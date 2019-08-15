using System.Collections;
using System.Linq;
using System.Web.Mvc;

namespace JXTNext.Sitefinity.SalarySurvey.Helpers
{
    public class FormHelper
    {
        public const string GenericErrorKey = "";
        public const string GenericErrorMessage = "There are a few input errors. Please refer to the red highlighted areas and amend your input.";
        public const string RequiredFieldMessage = "This field is required";
        public const string InvalidValueMessage = "The field value is invalid";

        public static Hashtable ModelStateErrors(ModelStateDictionary modelState)
        {
            var errors = new Hashtable();

            foreach (var pair in modelState)
            {
                if (pair.Value.Errors.Count > 0)
                {
                    errors[pair.Key] = pair.Value.Errors.Select(error => error.ErrorMessage).ToList();
                }
            }

            return errors;
        }
    }
}
