using System;
using System.Collections.Generic;
using System.Linq;
using ERPAdmin.Services.Contractors.Domain.SeedWork;

namespace ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate
{
    public class ContractorStatus
        : Enumeration
    {
        public static ContractorStatus InProcess = new ContractorStatus(1, nameof(InProcess).ToLowerInvariant());
        public static ContractorStatus Shipped = new ContractorStatus(2, nameof(Shipped).ToLowerInvariant());
        public static ContractorStatus Canceled = new ContractorStatus(3, nameof(Canceled).ToLowerInvariant());

        protected ContractorStatus()
        {
        }

        public ContractorStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<ContractorStatus> List()
        {
            return new[] { InProcess, Shipped, Canceled };
        }

        public static ContractorStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new ArgumentException($"Possible values for ContractorStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static ContractorStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new ArgumentException($"Possible values for ContractorStatus: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
