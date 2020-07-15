using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Interfaces
{
    public interface IGenericIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}
