using System;
using System.Reflection;
using GWebAPI.Error;

namespace GWebAPI.Helpers
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class LengthAttribute : Attribute, IRequestValidationAttribute
    {
        public int Min {get; private set;}
        public int Max {get; private set;}

        public LengthAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public bool IsValidRequest(object value, PropertyInfo prop, out ErrorModel error)
        {
            if (value is string)
            {
                string stringvalue = value as string;
                if (stringvalue.Length < Min || stringvalue.Length > Max)
                {
                    error = ErrorCode.InvalidRequestValue;
                    error.message = string.Format("Field {0} must be between {1} to {2}", prop.Name, Min, Max);
                    error.target = prop.Name;
                    return false;
                }
            }

            error = null;
            return true;
        }
    }
}