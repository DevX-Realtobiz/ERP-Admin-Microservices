namespace ERPAdmin.Services.Contractors.API.Application.Commands
{
    using Domain.AggregatesModel.BuyerAggregate;
    using Domain.AggregatesModel.ContractorAggregate;
    using MediatR;
    using ERPAdmin.Services.Contractors.API.Infrastructure.Services;
    using ERPAdmin.Services.Contractors.Infrastructure.Repositories;
    using System;
    using System.Threading.Tasks;


    public class CreateContractorCommandIdentifiedHandler : IdentifierCommandHandler<CreateContractorCommand, bool>
    {
        public CreateContractorCommandIdentifiedHandler(IMediator mediator, IRequestManager requestManager) : base(mediator, requestManager)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                // Ignore duplicate requests for creating Contractor.
        }
    }

    public class CreateContractorCommandHandler
        : IAsyncRequestHandler<CreateContractorCommand, bool>
    {
        private readonly IBuyerRepository<Buyer> _buyerRepository;
        private readonly IContractorRepository<Contractor> _ContractorRepository;
        private readonly IIdentityService _identityService;

        // Using DI to inject infrastructure persistence Repositories
        public CreateContractorCommandHandler(IBuyerRepository<Buyer> buyerRepository, IContractorRepository<Contractor> ContractorRepository, IIdentityService identityService)
        {
            _buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
            _ContractorRepository = ContractorRepository ?? throw new ArgumentNullException(nameof(ContractorRepository));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        public async Task<bool> Handle(CreateContractorCommand message)
        {
            // Add/Update the Buyer AggregateRoot
            // DDD patterns comment: Add child entities and value-objects through the Contractor Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate

            var cardTypeId = message.CardTypeId != 0 ? message.CardTypeId : 1;

            var buyerGuid = _identityService.GetUserIdentity();
            var buyer = await _buyerRepository.FindAsync(buyerGuid);

            if (buyer == null)
            {
                buyer = new Buyer(buyerGuid);
            }

            var payment = buyer.AddPaymentMethod(cardTypeId,
                $"Payment Method on {DateTime.UtcNow}",
                message.CardNumber,
                message.CardSecurityNumber,
                message.CardHolderName,
                message.CardExpiration);

            _buyerRepository.Add(buyer);

            await _buyerRepository.UnitOfWork
                .SaveChangesAsync();

            // Create the Contractor AggregateRoot
            // DDD patterns comment: Add child entities and value-objects through the Contractor Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate

            var Contractor = new Contractor(buyer.Id, payment.Id, new Address(message.Street, message.City, message.State, message.Country, message.ZipCode));

            foreach (var item in message.ContractorItems)
            {
                Contractor.AddContractorItem(item.ProductId, item.ProductName, item.UnitPrice, item.Discount, item.PictureUrl, item.Units);
            }

            _ContractorRepository.Add(Contractor);

            var result = await _ContractorRepository.UnitOfWork
                .SaveChangesAsync();

            return result > 0;

        }
    }
}
