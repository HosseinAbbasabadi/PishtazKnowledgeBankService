using Framework.Domain;

namespace Forum.Domain.Models.Questions
{
    public class View : ValueObjectBase
    {
        public long Viewer { get; private set; }

        public View(long viewer)
        {
            Viewer = viewer;
        }
    }
}