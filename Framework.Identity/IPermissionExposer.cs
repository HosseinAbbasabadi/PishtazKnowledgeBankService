using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Identity
{
    public interface IPermissionExposer
    {
        Dictionary<string, List<Permission>> Expose();
    }
}
