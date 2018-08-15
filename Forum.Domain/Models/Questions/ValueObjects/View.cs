using Framework.Domain;

namespace Forum.Domain.Models.Questions.ValueObjects
{
    public class View : ValueObjectBase
    {
        public long Viewer { get; private set; }

        protected View()
        {
        }

        public View(long viewer)
        {
            Viewer = viewer;
        }
    }
}