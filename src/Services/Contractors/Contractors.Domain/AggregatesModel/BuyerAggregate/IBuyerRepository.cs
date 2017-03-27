﻿using System.Threading.Tasks;
using ERPAdmin.Services.Contractors.Domain.SeedWork;

namespace ERPAdmin.Services.Contractors.Domain.AggregatesModel.BuyerAggregate
{
    //This is just the RepositoryContracts or Interface defined at the Domain Layer
    //as requisite for the Buyer Aggregate

    public interface IBuyerRepository<T> : IRepository<T> where T : IAggregateRoot
    {
        Buyer Add(Buyer buyer);

        Task<Buyer> FindAsync(string BuyerIdentityGuid);
    }
}
