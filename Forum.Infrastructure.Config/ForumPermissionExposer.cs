using System.Collections.Generic;
using Framework.Identity;

namespace Forum.Infrastructure.Config
{
    public class ForumPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<Permission>> Expose()
        {
            return new Dictionary<string, List<Permission>>
            {
                {
                    "VerifierExpert",
                    new List<Permission>
                    {
                        new Permission(1001, "VerifyQuestion")
                    }
                }
            };
        }
    }
}