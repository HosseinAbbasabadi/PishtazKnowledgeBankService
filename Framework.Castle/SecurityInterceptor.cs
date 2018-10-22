using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using Framework.Identity;

namespace Framework.Castle
{
    public class SecurityInterceptor : IInterceptor
    {
        public static Dictionary<string, List<Permission>> Permissions;

        public SecurityInterceptor(IEnumerable<IPermissionExposer> permissionExposers)
        {
            foreach (var exposer in permissionExposers)
            {
                var exposed = exposer.Expose();
                foreach (var item in exposed)
                {
                    if (Permissions.ContainsKey(item.Key))
                        Permissions[item.Key].AddRange(item.Value);
                    else
                        Permissions.Add(item.Key, item.Value);
                }
            }
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
        }
    }
}