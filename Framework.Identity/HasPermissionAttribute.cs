using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Identity
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HasPermissionAttribute : Attribute
    {
        public Enum Permission { get; private set; }

        public HasPermissionAttribute(object value)
        {
            if (value.GetType().IsEnum)
                Permission = (Enum) value;
            else
                throw new Exception();
        }
    }
}