using ERPAdmin.Services.Contractors.Domain.SeedWork;

namespace ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate
{
    //This is just the RepositoryContracts or Interface defined at the Domain Layer
    //as requisite for the Contractor Aggregate

    public interface IContractorRepository<T> : IRepository<T> where T : IAggregateRoot
    {
        Contractor Add(Contractor Contractor);
    }
}
