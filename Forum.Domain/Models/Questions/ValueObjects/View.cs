using Forum.Domain.Models.Users;
using Framework.Domain;

namespace Forum.Domain.Models.Questions.ValueObjects
{
    public class View : ValueObjectBase
    {
        public UserId Viewer { get; private set; }

        public View(UserId viewer)
        {
            Viewer = viewer;
        }
        protected View()
        {
        }
    }
}