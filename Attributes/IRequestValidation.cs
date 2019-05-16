using System;
using System.Reflection;
using GWebAPI.Error;

namespace GWebAPI.Helpers
{
    public interface IRequestValidationAttribute
    {
        bool IsValidRequest (object value, PropertyInfo prop, out ErrorModel error);
    }
}