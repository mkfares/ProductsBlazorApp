using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace ProductsBlazorApp.Components
{
    // checks the email with regular expression in the form sam@example.com
    // [EmailAddress] checks only the existance of the @ symbol in the string
    public class InputEmail : InputBase<string>
    {
        [Parameter] public string ParsingErrorMessage { get; set; } = "The {0} field must be an email.";

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "input");            
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddAttribute(2, "class", CssClass);
            builder.AddAttribute(3, "value", BindConverter.FormatValue(CurrentValueAsString));
            builder.AddAttribute(4, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, CurrentValueAsString));
            builder.CloseElement();
        }

        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
        {
            if (value == null || IsEmailValid(value))
            {
                validationErrorMessage = null;
                result = value;
                return true;
            }
            else
            {
                validationErrorMessage = string.Format(ParsingErrorMessage, FieldIdentifier.FieldName);
                result = value;
                return false;
            }
        }

        // Check whether email is valid using regular expressions
        bool IsEmailValid(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }
}
