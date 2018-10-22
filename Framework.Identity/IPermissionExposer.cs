using System.Collections.Generic;

namespace Framework.Identity
{
    public interface IPermissionExposer
    {
        Dictionary<string, List<Permission>> Expose();
    }
}