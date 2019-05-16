using System.Collections.Generic;
using System.Text.RegularExpressions;
using GWebAPI.Error;

namespace GWebAPI.Models
{
    public class ErrorResponse
    {
        public ErrorModel error;

        public ErrorResponse (ErrorModel errorModel, string message)
        {
            error = errorModel;
            if (!string.IsNullOrEmpty(message)) {
                error.message = message;
            } else if (string.IsNullOrEmpty(error.message)) {
                error.message = Regex.Replace(errorModel.code, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
            }
        }

        public ErrorResponse (ErrorModel errorModel) : this(errorModel, string.Empty)
        {}

    }
}