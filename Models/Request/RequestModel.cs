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
            ErrorCode code = ErrorCode.None;
            string msg = string.Empty;

            IEnumerable<PropertyInfo> props = this.GetType().GetProperties()
                .Where(prop => prop.GetCustomAttributes(typeof(RequiredRequestAttribute),false).Length > 0);
            
            bool invalid = false;
            foreach (PropertyInfo prop in props)
            {
                object value = prop.GetValue(this);
                if (value == null) {
                    code = ErrorCode.RequestFieldRequired;
                    msg += string.Format("Field {0} is required. ", prop.Name);
                    invalid = true;
                }
            }

            return new ValidationModel() {
                IsValid = !invalid,
                Code = code.ToString(),
                Message = msg
            };
        }
    }
}