using System;
using System.Reflection;
using System.Text.RegularExpressions;
using GWebAPI.Error;

namespace GWebAPI.Helpers
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class EmailAttribute : Attribute, IRequestValidationAttribute
    {
        private string _regexPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public bool IsValidRequest(object value, PropertyInfo prop, out ErrorModel error)
        {
            if (value is string)
            {
                string stringvalue = value as string;                
                Match match = Regex.Match(stringvalue, _regexPattern);
                if (!match.Success) {
                    error = ErrorCode.InvalidEmailFormat;
                    error.message = "Invalid Email Format";
                    error.target = prop.Name;
                    return false;
                }
            }

            error = null;
            return true;
        }
    }
}