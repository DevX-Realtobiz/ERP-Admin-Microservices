using System;

namespace ERPAdmin.Services.Common.Infrastructure
{
    public class IntegrationEventBase
    {
        public IntegrationEventBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id  { get; private set; }
    }
}
