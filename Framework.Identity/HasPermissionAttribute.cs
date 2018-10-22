using System;

namespace Framework.Identity
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HasPermissionAttribute : Attribute
    {
        public long Code { get; set; }

        public HasPermissionAttribute(long code)
        {
            Code = code;
        }
    }
}