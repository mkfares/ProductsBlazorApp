using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;

namespace ProductsBlazorApp.Components
{
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
            if (value.Contains('@'))
            {
                validationErrorMessage = null;
                result = value;
                return true;
            }
            else
            {
                validationErrorMessage = string.Format(ParsingErrorMessage, FieldIdentifier.FieldName);
                result = default;
                return false;
            }
        }

        protected override string FormatValueAsString(string value)
        {
            return value;
        }
    }
}
