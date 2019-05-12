using System;

namespace GWebAPI.Helpers
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class EmailAttribute : Attribute {
        
        public string RegexPattern {get; private set;}

        public EmailAttribute ()
        {
            RegexPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        }
        
    }
}