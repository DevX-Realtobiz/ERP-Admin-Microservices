using System;
using ERPAdmin.Services.Contractors.Domain.SeedWork;

namespace ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate
{
    public class ContractorItem
        : Entity
    {
        // DDD Patterns comment
        // Using private fields, allowed since EF Core 1.1, is a much better encapsulation
        // aligned with DDD Aggregates and Domain Entities (Instead of properties and property collections)
        private string  _productName;
        private string  _pictureUrl;
        private int     _ContractorId;
        private decimal _unitPrice;
        private decimal _discount;
        private int     _units;

        public int ProductId { get; private set; }

        protected ContractorItem() { }

        public ContractorItem(int productId, string productName, decimal unitPrice, decimal discount, string PictureUrl, int units = 1)
        {
            if (units <= 0)
            {
                throw new ArgumentNullException("Invalid number of units");
            }

            if ((unitPrice * units) < discount)
            {
                throw new ArgumentException("The total of Contractor item is lower than applied discount");
            }

            ProductId = productId;

            _productName = productName;
            _unitPrice = unitPrice;
            _discount = discount;
            _units = units;
            _pictureUrl = PictureUrl;
        }

        public void SetPictureUri(string pictureUri)
        {
            if (!String.IsNullOrWhiteSpace(pictureUri))
            {
                _pictureUrl = pictureUri;
            }
        }

        public decimal GetCurrentDiscount()
        {
            return _discount;
        }

        public void SetNewDiscount(decimal discount)
        {
            if (discount < 0)
            {
                throw new ArgumentException("Discount is not valid");
            }

            _discount = discount;
        }

        public void AddUnits(int units)
        {
            if (units < 0)
            {
                throw new ArgumentException("Invalid units");
            }

            _units += units;
        }
    }
}
