using FotoVista.Domain.Constants;

namespace FotoVista.Service.Helpers;

public class TimeHelper
{
    public static DateTime GetDateTime()
    {
        var datetime = DateTime.UtcNow;
        datetime.AddHours(TimeConstants.UTC);
        return datetime;
    }
}