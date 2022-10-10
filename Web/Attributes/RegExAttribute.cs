using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Web.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RegExAttribute : ValidationAttribute, IClientModelValidator
    {
        public string Pattern { get; set; }
        public RegexOptions Options { get; set; }

        public RegExAttribute(string pattern) : this(pattern, RegexOptions.None) { }

        public RegExAttribute(string pattern, RegexOptions options)
        {
            Pattern = pattern;
            Options = options;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-regex", ErrorMessage);
            context.Attributes.Add("data-val-regex-pattern", Pattern);
        }

        public override bool IsValid(object value)
        {
            return Regex.IsMatch(value.ToString(), Pattern, Options);
        }
    }
}
