using MasterCRM.Domain.Entities;
using MasterCRM.Domain.Entities.Orders;
using MasterCRM.Domain.Interfaces;

namespace MasterCRM.Infrastructure.Services.Emails;

public class EmailTemplateService : IEmailTemplateService
{
    public string GetMasterOrderCreatedTemplate(Order order, Client client)
    {
        return $$"""
                 <!DOCTYPE html>
                 <html>
                 <head>
                     <meta charset='UTF-8'>
                     <style>
                         body { font-family: Arial, sans-serif; }
                     </style>
                 </head>
                 <body>
                     <p>Доброго дня, {{order.Master.GetFullName()}}.</p>
                     <p>Пользователь {{client.GetFullName()}} оставил заявку на заказ.</p>
                     {{(string.IsNullOrWhiteSpace(order.Comment) ? $"<p>Комментарий к заказу - {order.Comment}.</p>" : "")}}
                     <p>Контактные данные пользователя для связи: {{client.Phone}}, {{client.Email}}.</p>
                     <p>С уважением,<br>
                     МастерскаЯ</p>
                 </body>
                 </html>
                 """;
    }

    public string GetClientOrderCreatedTemplate(Order order, Client client)
    {
        return $$"""
                 <!DOCTYPE html>
                 <html>
                 <head>
                     <meta charset='UTF-8'>
                     <style>
                         body { font-family: Arial, sans-serif; }
                     </style>
                 </head>
                 <body>
                     <p>Доброго дня, {{client.GetFullName()}}.</p>
                     <p>Ваш заказ успешно оформлен и отправлен мастеру.</p>
                     <p>О переходе товара на следующую стадию вы узнаете в письме, которое придет на эту же почту.</p>
                     <p>Контактные данные мастера для связи: {{order.Master.PhoneNumber}}, {{order.Master.Email}}.</p>
                     <p>С уважением,<br>
                     МастерскаЯ</p>
                 </body>
                 </html>
                 """;
    }

    public string GetOrderStageChangedTemplate(Order order, string newStage)
    {
        return $$"""
                 <!DOCTYPE html>
                 <html>
                 <head>
                     <meta charset='UTF-8'>
                     <style>
                         body { font-family: Arial, sans-serif; }
                     </style>
                 </head>
                 <body>
                     <p>Доброго дня, {{order.Client.GetFullName()}}.</p>
                     <p>Ваш заказ от {{order.CreatedAt:dd.MM.yyyy}} перешел на следующую стадию «{{newStage}}».</p>
                     <p>Контактные данные мастера для связи: {{order.Master.PhoneNumber}}, {{order.Master.Email}}.</p>
                     <p>С уважением,<br>
                     МастерскаЯ</p>
                 </body>
                 </html>
                 """;
    }
}