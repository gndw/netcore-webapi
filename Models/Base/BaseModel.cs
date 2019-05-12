using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using GWebAPI.Helpers;

namespace GWebAPI.Models
{
    public abstract class BaseModel
    {
        public bool IsValidRequest ()
        {
            return Validate().IsValid;
        }

        public ValidationModel Validate ()
        {
            ValidationModel result;

            /// TO DO : CREATE DYNAMIC CHECK
            if (!IsValidFromRequiredProperty(out result)) return result;
            if (!IsValidFromLengthProperty(out result)) return result;
            if (!IsValidFromEmailProperty(out result)) return result;
            
            return result;
        }

        private bool IsValidFromRequiredProperty (out ValidationModel validation)
        {
            List<PropertyInfo> nullProperties = new List<PropertyInfo>();

            IEnumerable<PropertyInfo> props = this.GetType().GetProperties()
                .Where(prop => prop.GetCustomAttributes(typeof(RequiredAttribute),false).Length > 0);
            
            bool valid = true;
            foreach (PropertyInfo prop in props)
            {
                object value = prop.GetValue(this);
                if (value == null) {
                    nullProperties.Add(prop);
                    valid = false;
                }
            }

            validation = new ValidationModel ()
            {
                IsValid = valid,
                Code = !valid ? ErrorCode.RequestFieldUnspecified : string.Empty,
                Message = !valid ? "These fields are required in request : " + string.Join(", ", nullProperties.Select(prop => prop.Name)) : string.Empty
            };

            return valid;
        }

        private bool IsValidFromLengthProperty (out ValidationModel validation)
        {
            List<string> msgs = new List<string>();

            IEnumerable<PropertyInfo> props = this.GetType().GetProperties()
                .Where(prop => prop.GetCustomAttributes(typeof(LengthAttribute),false).Length > 0);
            
            bool valid = true;
            foreach (PropertyInfo prop in props)
            {
                object value = prop.GetValue(this);
                if (value is string)
                {
                    string stringvalue = value as string;
                    LengthAttribute attr = prop.GetCustomAttribute(typeof(LengthAttribute),false) as LengthAttribute;
                    if (stringvalue.Length < attr.Min || stringvalue.Length > attr.Max)
                    {
                        msgs.Add(string.Format("Field {0} must be between {1} to {2}", prop.Name, attr.Min, attr.Max));
                        valid = false;
                    }
                }
            }

            validation = new ValidationModel ()
            {
                IsValid = valid,
                Code = !valid ? ErrorCode.InvalidRequestValue : string.Empty,
                Message = !valid ? string.Join(", ", msgs) : string.Empty
            };

            return valid;
        }

        private bool IsValidFromEmailProperty (out ValidationModel validation)
        {
            IEnumerable<PropertyInfo> props = this.GetType().GetProperties()
                .Where(prop => prop.GetCustomAttributes(typeof(EmailAttribute),false).Length > 0);
            
            bool valid = true;
            foreach (PropertyInfo prop in props)
            {
                object value = prop.GetValue(this);
                if (value is string)
                {
                    string stringvalue = value as string;
                    EmailAttribute attr = prop.GetCustomAttribute(typeof(EmailAttribute),false) as EmailAttribute;
                    
                    Match match = Regex.Match(stringvalue, attr.RegexPattern);
                    if (!match.Success) valid = false;
                }
            }

            validation = new ValidationModel ()
            {
                IsValid = valid,
                Code = !valid ? ErrorCode.InvalidEmailFormat : string.Empty,
                Message = !valid ? "Invalid Email Format" : string.Empty
            };

            return valid;
        }
    }
}