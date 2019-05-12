using System;

namespace GWebAPI.Helpers
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class RequiredAttribute : Attribute {}
}