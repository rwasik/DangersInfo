using System;
using AutoMapper;

namespace DangersInfo.Services.Mapping
{
    public class UnixTimeStampFormatter : IValueConverter<string, DateTime>
    {
        public DateTime Convert(string unixTimeStamp, ResolutionContext context)
        {
            var initialDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return initialDate.AddMilliseconds(double.Parse(unixTimeStamp)).ToLocalTime();
        }
    }    
}
