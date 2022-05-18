using Microservice.Test.Application.Common.Interfaces;

namespace Microservice.Test.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}