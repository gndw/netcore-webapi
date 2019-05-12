using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GWebAPI.Helpers;

namespace GWebAPI.Models
{
    public abstract class RequestModel
    {
        public bool IsValidRequest ()
        {
            return Validate().IsValid;
        }

        public ValidationModel Validate ()
        {
            ValidationModel result;

            /// TO DO : CREATE DYNAMIC CHECK
            if (!IsValidFromNullProperty(out result)) return result;
            
            return result;
        }

        private bool IsValidFromNullProperty (out ValidationModel validation)
        {
            List<PropertyInfo> nullProperties = new List<PropertyInfo>();

            IEnumerable<PropertyInfo> props = this.GetType().GetProperties()
                .Where(prop => prop.GetCustomAttributes(typeof(RequiredRequestAttribute),false).Length > 0);
            
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
    }
}