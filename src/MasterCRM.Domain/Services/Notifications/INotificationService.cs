using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Orders;

namespace MasterCRM.Domain.Services.Notifications;

public interface INotificationService
{
    public Task NotifyMasterOrderCreated(Order order, Client client);

    public Task NotifyClientOrderCreated(Order order, Client client);

    public Task NotifyOrderStageChangedAsync(Order order, string newStage);
}