using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Orders;

namespace MasterCRM.Domain.Interfaces;

public interface IEmailTemplateService
{
    string GetMasterOrderCreatedTemplate(Order order, Client client);
    string GetClientOrderCreatedTemplate(Order order, Client client);
    string GetOrderStageChangedTemplate(Order order, string newStage);
}