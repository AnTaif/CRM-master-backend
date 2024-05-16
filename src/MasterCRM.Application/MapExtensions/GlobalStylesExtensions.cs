using MasterCRM.Application.Services.Websites.Constructor;
using MasterCRM.Domain.Entities.Websites;

namespace MasterCRM.Application.MapExtensions;

public static class GlobalStylesExtensions
{
    public static GlobalStylesDto ToDto(this GlobalStyles globalStyles)
    {
        return new GlobalStylesDto
        {
            FontFamily = globalStyles.FontFamily,
            BackgroundColor = globalStyles.BackgroundColor,
            H1Color = globalStyles.H1Color,
            PColor = globalStyles.PColor,
            ButtonColor = globalStyles.ButtonColor
        };
    }
}