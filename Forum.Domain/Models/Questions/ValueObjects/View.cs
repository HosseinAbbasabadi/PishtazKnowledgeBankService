using Forum.Domain.Models.Users;
using Framework.Domain;

namespace Forum.Domain.Models.Questions.ValueObjects
{
    public class View : ValueObjectBase
    {
        public UserId Viewer { get; private set; }

        protected View()
        {
        }

        public View(UserId viewer)
        {
            Viewer = viewer;
        }
    }
}