namespace GWebAPI.Error
{
    public static class ErrorCode
    {
        // Request
        public static ErrorModel RequestFieldUnspecified = new ErrorModel {code = nameof(RequestFieldUnspecified), servercode = 2001 };
        public static ErrorModel InvalidRequestValue = new ErrorModel {code = nameof(InvalidRequestValue), servercode = 2002 };
        public static ErrorModel RequestInternalErrorModel = new ErrorModel {code = nameof(RequestInternalErrorModel), servercode = 2003 };
        public static ErrorModel InvalidEmailFormat = new ErrorModel {code = nameof(InvalidEmailFormat), servercode = 2004 };
        public static ErrorModel InvalidRequest = new ErrorModel {code = nameof(InvalidRequest), servercode = 2005 };

        // Login Register Logout
        public static ErrorModel InvalidUsernameOrPassword = new ErrorModel {code = nameof(InvalidUsernameOrPassword), servercode = 3001 };
        public static ErrorModel UsernameAlreadyTaken = new ErrorModel {code = nameof(UsernameAlreadyTaken), servercode = 3002 };
        public static ErrorModel EmailAlreadyUsed = new ErrorModel {code = nameof(EmailAlreadyUsed), servercode = 3003 };
    }
}