using System;

namespace MerchandiseService.Application
{
    public interface IClock
    {
        DateTime GetCurrentTimeUtc();
    }

    public class Clock : IClock
    {
        public DateTime GetCurrentTimeUtc()
        {
            return DateTime.UtcNow;
        }
    }
}