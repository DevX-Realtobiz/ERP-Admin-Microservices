namespace ERPAdmin.Services.Common.Infrastructure
{
    public interface IEventBus
    {
        void Subscribe<T>(IIntegrationEventHandler<T> handler) where T: IntegrationEventBase;
        void Unsubscribe<T>(IIntegrationEventHandler<T> handler) where T : IntegrationEventBase;
        void Publish(IntegrationEventBase @event);
    }
}
