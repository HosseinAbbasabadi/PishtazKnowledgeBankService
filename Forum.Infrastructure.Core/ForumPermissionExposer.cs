using System.Collections.Generic;
using Framework.Identity;

namespace Forum.Infrastructure.Core
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
                        new Permission((long) VerifierExpertPermissions.VerifyQuestion, "VerifyQuestion"),
                        new Permission((long) VerifierExpertPermissions.ViewUnApprovedQuestions,
                            "ViewUnApprovedQuestions")
                    }
                }
            };
        }
    }
}