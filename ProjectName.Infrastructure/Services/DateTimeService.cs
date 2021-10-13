using ProjectName.Application.Common.Interfaces;
using System;

namespace ProjectName.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
