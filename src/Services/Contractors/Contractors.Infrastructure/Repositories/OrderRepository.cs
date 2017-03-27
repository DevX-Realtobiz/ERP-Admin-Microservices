using System;
using ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate;
using ERPAdmin.Services.Contractors.Domain.SeedWork;

namespace ERPAdmin.Services.Contractors.Infrastructure.Repositories
{
    public class ContractorRepository
        : IContractorRepository<Contractor> 
    {
        private readonly ContractorsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public ContractorRepository(ContractorsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Contractor Add(Contractor Contractor)
        {
            return _context.Contractors.Add(Contractor)
                .Entity;
        }
    }
}
