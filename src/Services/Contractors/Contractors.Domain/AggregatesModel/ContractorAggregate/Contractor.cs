using System;
using System.Collections.Generic;
using System.Linq;
using ERPAdmin.Services.Contractors.Domain.AggregatesModel.BuyerAggregate;
using ERPAdmin.Services.Contractors.Domain.SeedWork;

namespace ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate
{
    public class Contractor
        : Entity, IAggregateRoot
    {
        // DDD Patterns comment
        // Using private fields, allowed since EF Core 1.1, is a much better encapsulation
        // aligned with DDD Aggregates and Domain Entities (Instead of properties and property collections)
        private DateTime _ContractorDate;

        public Address Address { get; private set; }

        public Buyer Buyer { get; private set; }
        private int _buyerId;

        public ContractorStatus ContractorStatus { get; private set; }
        private int _ContractorStatusId;


        // DDD Patterns comment
        // Using a private collection field, better for DDD Aggregate's encapsulation
        // so ContractorItems cannot be added from "outside the AggregateRoot" directly to the collection,
        // but only through the method ContractorAggrergateRoot.AddContractorItem() which includes behaviour.
        private readonly List<ContractorItem> _ContractorItems;

        public IEnumerable<ContractorItem> ContractorItems => _ContractorItems.AsReadOnly();
        // Using List<>.AsReadOnly() 
        // This will create a read only wrapper around the private list so is protected against "external updates".
        // It's much cheaper than .ToList() because it will not have to copy all items in a new collection. (Just one heap alloc for the wrapper instance)
        //https://msdn.microsoft.com/en-us/library/e78dcd75(v=vs.110).aspx 

        public PaymentMethod PaymentMethod { get; private set; }
        private int _paymentMethodId;

        protected Contractor() { }

        public Contractor(int buyerId, int paymentMethodId, Address address)
        {
            _ContractorItems = new List<ContractorItem>();
            _buyerId = buyerId;
            _paymentMethodId = paymentMethodId;
            _ContractorStatusId = ContractorStatus.InProcess.Id;
            _ContractorDate = DateTime.UtcNow;
            Address = address;
        }

        // DDD Patterns comment
        // This Contractor AggregateRoot's method "AddContractoritem()" should be the only way to add Items to the Contractor,
        // so any behavior (discounts, etc.) and validations are controlled by the AggregateRoot 
        // in Contractor to maintain consistency between the whole Aggregate. 
        public void AddContractorItem(int productId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units = 1)
        {
            var existingContractorForProduct = _ContractorItems.Where(o => o.ProductId == productId)
                .SingleOrDefault();

            if (existingContractorForProduct != null)
            {
                //if previous line exist modify it with higher discount  and units..

                if (discount > existingContractorForProduct.GetCurrentDiscount())
                {
                    existingContractorForProduct.SetNewDiscount(discount);
                    existingContractorForProduct.AddUnits(units);
                }
            }
            else
            {
                //add validated new Contractor item

                var ContractorItem = new ContractorItem(productId, productName, unitPrice, discount, pictureUrl, units);

                _ContractorItems.Add(ContractorItem);
            }
        }
    }
}
