namespace GWebAPI.Models
{
    public static class ErrorCode
    {
        // Request
        public const string RequestFieldUnspecified = nameof( RequestFieldUnspecified );
        public const string InvalidRequestValue = nameof( InvalidRequestValue );
        public const string RequestInternalError = nameof( RequestInternalError );
        public const string InvalidEmailFormat = nameof( InvalidEmailFormat );

        // Login Register Logout
        public const string InvalidUsernameOrPassword = nameof( InvalidUsernameOrPassword );
        public const string UsernameAlreadyTaken = nameof( UsernameAlreadyTaken );
        public const string EmailAlreadyTaken = nameof( EmailAlreadyTaken );
    }
}