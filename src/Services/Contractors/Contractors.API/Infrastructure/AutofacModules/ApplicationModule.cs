using Autofac;
using ERPAdmin.Services.Contractors.API.Application.Queries;
using ERPAdmin.Services.Contractors.Domain.AggregatesModel.BuyerAggregate;
using ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate;
using ERPAdmin.Services.Contractors.Infrastructure.Repositories;

namespace ERPAdmin.Services.Contractors.API.Infrastructure.AutofacModules
{

    public class ApplicationModule
        :Autofac.Module
    {

        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => new ContractorQueries(QueriesConnectionString))
                .As<IContractorQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BuyerRepository>()
                .As<IBuyerRepository<Buyer>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ContractorRepository>()
                .As<IContractorRepository<Contractor>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RequestManager>()
               .As<IRequestManager>()
               .InstancePerLifetimeScope();
        }
    }
}
