using Application.BlogApplication.Event;
using Infrastructure.EventBus.EventBus.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Config.EventBus
{
    public class EventBusConfig
    {
        public static IEventBus ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<BlogIntegrationEvent, BlogIntegrationEventHandler>();
            return eventBus;
        }
    }
}
