using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using GWebAPI.Error;
using GWebAPI.Helpers;

namespace GWebAPI.Models
{
    public abstract class RequestModel
    {
        private bool _validated;
        private ErrorModel _error;

        public bool IsValidRequest ()
        {
            if (!_validated) Validate();
            return _error == null;
        }

        public ErrorModel Error(bool forceValidate = false)
        {
            if (forceValidate || !_validated) Validate();
            return _error;
        }

        private void Validate ()
        {
            IEnumerable<PropertyInfo> props = this.GetType().GetProperties();
            List<ErrorModel> errors = new List<ErrorModel>();

            foreach (var prop in props)
            {
                IEnumerable<Attribute> attrs = prop.GetCustomAttributes<Attribute>();
                foreach (var att in attrs)
                {
                    if (att is IRequestValidationAttribute)
                    {
                        IRequestValidationAttribute rva = att as IRequestValidationAttribute;
                        ErrorModel error;
                        if (!rva.IsValidRequest(prop.GetValue(this), prop, out error))
                        {
                            errors.Add(error);
                        }
                    }
                }
            }
            
            _validated = true;
            if (errors.Count > 0)
            {
                _error = ErrorCode.InvalidRequest;
                _error.details = errors.ToArray();
            }
            else
            {
                _error = null;
            }
        }
    }
}