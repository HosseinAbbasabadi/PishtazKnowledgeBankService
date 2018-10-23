using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;
using Framework.Identity;

namespace Framework.Castle
{
    public class SecurityInterceptor : IInterceptor
    {
        public static Dictionary<string, List<Permission>> Permissions = new Dictionary<string, List<Permission>>();
        private readonly IClaimHelper _claimHelper;

        public SecurityInterceptor(IEnumerable<IPermissionExposer> permissionExposers, IClaimHelper claimHelper)
        {
            _claimHelper = claimHelper;
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
            var currentUserRoles = _claimHelper.GetCurrentUserRoles();
            var methodPermissions = GetMethodPermissions(invocation.Method).ToList();
            if (MethodHasNotAnyAttributes(methodPermissions))
            {
                invocation.Proceed();
                return;
            }

            if (UserHasPermissionToProcessThisMethod(currentUserRoles, methodPermissions)) invocation.Proceed();
            else throw new UnauthorizedAccessException();
        }

        //private static bool UserHasPermissionToProcessThisMethod(List<string> currentUserRoles,
        //    List<long> methodPermissions)
        //{
        //    var result = false;
        //    var myPermissionList = Permissions.Where(x=>x.Key == )
        //    foreach (var role in currentUserRoles)
        //    {
        //        foreach (var methodPermission in methodPermissions)
        //        {
        //            foreach (var permission in Permissions)
        //            {
        //                if (permission.Value.Any(x => x.Code == methodPermission))
        //                {
        //                    result = true;
        //                    break;
        //                }
        //            }

        //            if (result)
        //                break;
        //        }

        //        if (result)
        //            break;
        //    }

        //    return result;
        //}
        private static bool UserHasPermissionToProcessThisMethod(List<string> currentUserRoles,
            List<long> methodPermissions)
        {
            var myPermissions = FindMyInPermissionsDictionary(currentUserRoles);

            var result = false;
            foreach (var myPermission in myPermissions)
            {
                foreach (var methodPermission in methodPermissions)
                {
                    if (myPermission.Value.Any(x => x.Code == methodPermission))
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        private static Dictionary<string, List<Permission>> FindMyInPermissionsDictionary(List<string> currentUserRoles)
        {
            var myPermissions = new Dictionary<string, List<Permission>>();
            foreach (var role in currentUserRoles)
            {
                foreach (var permission in Permissions)
                {
                    if (permission.Key == role)
                        myPermissions.Add(permission.Key, permission.Value);
                }
            }

            return myPermissions;
        }

        private static bool MethodHasNotAnyAttributes(IEnumerable<long> methodPermissions)
        {
            return !methodPermissions.Any();
        }

        private static IEnumerable<long> GetMethodPermissions(ICustomAttributeProvider method)
        {
            var attribute =
                method.GetCustomAttributes(typeof(HasPermissionAttribute), true)
                    .OfType<HasPermissionAttribute>()
                    .ToList();
            return attribute.Select(a => a.Code).ToList();
        }
    }
}