namespace ERPAdmin.Services.Contractors.API.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using ERPAdmin.Services.Contractors.Domain;
    using System.Linq;
    using System.Threading.Tasks;
    using ERPAdmin.Services.Contractors.Domain.AggregatesModel.BuyerAggregate;
    using ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate;
    using ERPAdmin.Services.Contractors.Infrastructure;

    public class ContractorsContextSeed
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            var context = (ContractorsContext)applicationBuilder
                .ApplicationServices.GetService(typeof(ContractorsContext));

            using (context)
            {
                // context.Database.Migrate();

                //if (!context.CardTypes.Any())
                //{
                //    context.CardTypes.Add(CardType.Amex);
                //    context.CardTypes.Add(CardType.Visa);
                //    context.CardTypes.Add(CardType.MasterCard);

                //    await context.SaveChangesAsync();
                //}

                //if (!context.ContractorStatus.Any())
                //{
                //    context.ContractorStatus.Add(ContractorStatus.Canceled);
                //    context.ContractorStatus.Add(ContractorStatus.InProcess);
                //    context.ContractorStatus.Add(ContractorStatus.Shipped);
                //}

                //await context.SaveChangesAsync();
            }
        }

    }
}
