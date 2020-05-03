using Infrastructure.EventBus.EventBus.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.BlogApplication.Event
{
    public class BlogIntegrationEventHandler : IIntegrationEventHandler<BlogIntegrationEvent>
    {
        private readonly ILogger<BlogIntegrationEventHandler> logger;

        public BlogIntegrationEventHandler(ILogger<BlogIntegrationEventHandler> logger)
        {
            this.logger = logger;
        }

        public Task Handle(BlogIntegrationEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
