using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Interfaces
{
    public interface IEventBus
    {
        void Publish(IntegrationEvent @event);

        void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        void SubscribeDynamic<TH>(string eventName)
            where TH : IGenericIntegrationEventHandler;

        void UnsubscribeDynamic<TH>(string eventName)
            where TH : IGenericIntegrationEventHandler;

        void Unsubscribe<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IntegrationEvent;
    }
}
