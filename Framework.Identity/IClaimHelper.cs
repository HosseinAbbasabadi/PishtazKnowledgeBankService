using System.Collections.Generic;

namespace Framework.Identity
{
    public interface IClaimHelper
    {
        long GetCurrentUserId();
        List<string> GetCurrentUserRoles();
    }
}
