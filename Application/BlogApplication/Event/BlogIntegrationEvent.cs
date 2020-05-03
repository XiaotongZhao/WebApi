using Infrastructure.EventBus.EventBus.Events;

namespace Application.BlogApplication.Event
{
    public class BlogIntegrationEvent : IntegrationEvent
    {
        public string Name { get; set; }
    }
}
