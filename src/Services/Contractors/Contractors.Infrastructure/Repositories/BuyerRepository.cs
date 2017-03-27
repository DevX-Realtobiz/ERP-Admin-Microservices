using System;
using System.Linq;
using System.Threading.Tasks;
using ERPAdmin.Services.Contractors.Domain.AggregatesModel.BuyerAggregate;
using ERPAdmin.Services.Contractors.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace ERPAdmin.Services.Contractors.Infrastructure.Repositories
{
    public class BuyerRepository
        : IBuyerRepository<Buyer>
    {
        private readonly ContractorsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public BuyerRepository(ContractorsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Buyer Add(Buyer buyer)
        {
            if (buyer.IsTransient())
            {
                return _context.Buyers
                    .Add(buyer)
                    .Entity;
            }
            else
            {
                return buyer;
            }
            
        }

        public async Task<Buyer> FindAsync(string identity)
        {
            var buyer = await _context.Buyers
                .Include(b => b.PaymentMethods)
                .Where(b => b.IdentityGuid == identity)
                .SingleOrDefaultAsync();

            return buyer;
        }
    }
}
