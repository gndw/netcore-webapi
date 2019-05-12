using System;

namespace GWebAPI.Helpers
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class LengthAttribute : Attribute
    {
        public int Min {get; private set;}
        public int Max {get; private set;}

        public LengthAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}