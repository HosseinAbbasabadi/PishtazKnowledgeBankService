using Microsoft.Extensions.Options;

namespace Framework.Configuration
{
    public interface IFrameworkConfiguration
    {
        string GetNotificationUrl();
    }

    public class FrameworkConfiguration : IFrameworkConfiguration
    {
        private readonly IOptions<EndPoints> _endPoints;

        public FrameworkConfiguration(IOptions<EndPoints> endPoints)
        {
            _endPoints = endPoints;
        }

        public string GetNotificationUrl()
        {
            return _endPoints.Value.NotificationUrl;
        }
    }

    public class EndPoints
    {
        public string NotificationUrl { get; set; }
    }
}