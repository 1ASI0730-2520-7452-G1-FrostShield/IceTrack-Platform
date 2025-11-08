using Cortex.Mediator.Notifications;
using IceTrackPlatform.API.Shared.Domain.Model.Events;

namespace IceTrackPlatform.API.Shared.Application.Internal.EventHandlers;


public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}