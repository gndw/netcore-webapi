using System;
using System.Reflection;
using GWebAPI.Error;

namespace GWebAPI.Helpers
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class RequiredAttribute : Attribute, IRequestValidationAttribute
    {
        public bool IsValidRequest(object value, PropertyInfo prop, out ErrorModel error)
        {
            if (value == null)
            {
                error = ErrorCode.RequestFieldUnspecified;
                error.message = string.Format("Field {0} is required", prop.Name);
                error.target = prop.Name;
                return false;
            }
            else
            {
                error = null;
                return true;
            }
            
        }
    }
}