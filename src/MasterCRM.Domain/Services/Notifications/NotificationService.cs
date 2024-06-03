using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Orders;
using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Domain.Services.Notifications;

public class NotificationService(
        IEmailTemplateService emailTemplateService, IEmailSender emailSender) : INotificationService
{
    public async Task NotifyMasterOrderCreated(Order order, Client client)
    {
        if (order.Master.Email != null)
        {
            var message = emailTemplateService.GetMasterOrderCreatedTemplate(order, client);
            await emailSender.SendEmailAsync(order.Master.Email, "У вас новый заказ!", message);
        }
    }

    public async Task NotifyClientOrderCreated(Order order, Client client)
    {
        var message = emailTemplateService.GetClientOrderCreatedTemplate(order, client);
        await emailSender.SendEmailAsync(client.Email, "Ваш заказ оформлен", message);
    }
    
    public async Task NotifyOrderStageChangedAsync(Order order, string newStage)
    {
        var message = emailTemplateService.GetOrderStageChangedTemplate(order, newStage);
        await emailSender.SendEmailAsync(order.Client.Email, "Ваш заказ перешел на следующую стадию!", message);
    }
}