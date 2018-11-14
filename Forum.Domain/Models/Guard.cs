using Framework.Core.Exceptions;

namespace Forum.Domain.Models
{
    public class Guard
    {
        public static void AgainsNullOrEmptyString(string data)
        {
            if (string.IsNullOrEmpty(data))
                throw new RequiredDataIsNullOrEmptyException();
        }
    }
}
