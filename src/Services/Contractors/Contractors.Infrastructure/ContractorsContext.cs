using System;
using ERPAdmin.Services.Contractors.Domain.AggregatesModel.BuyerAggregate;
using ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate;
using ERPAdmin.Services.Contractors.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERPAdmin.Services.Contractors.Infrastructure
{
    public class ContractorsContext
      : DbContext,IUnitOfWork

    {
        const string DEFAULT_SCHEMA = "Contractoring";

        public DbSet<Contractor> Contractors { get; set; }

        public DbSet<ContractorItem> ContractorItems { get; set; }

        public DbSet<PaymentMethod> Payments { get; set; }

        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<CardType> CardTypes { get; set; }

        public DbSet<ContractorStatus> ContractorStatus { get; set; }

        public ContractorsContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ClientRequest>(ConfigureRequests);
            modelBuilder.Entity<Address>(ConfigureAddress);
            modelBuilder.Entity<PaymentMethod>(ConfigurePayment);
            modelBuilder.Entity<Contractor>(ConfigureContractor);
            modelBuilder.Entity<ContractorItem>(ConfigureContractorItems);
            modelBuilder.Entity<CardType>(ConfigureCardTypes);
            modelBuilder.Entity<ContractorStatus>(ConfigureContractorStatus);
            modelBuilder.Entity<Buyer>(ConfigureBuyer);
        }

        private void ConfigureRequests(EntityTypeBuilder<ClientRequest> requestConfiguration)
        {
            requestConfiguration.ToTable("requests", DEFAULT_SCHEMA);
            requestConfiguration.HasKey(cr => cr.Id);
            requestConfiguration.Property(cr => cr.Name).IsRequired();
            requestConfiguration.Property(cr => cr.Time).IsRequired();
        }

        void ConfigureAddress(EntityTypeBuilder<Address> addressConfiguration)
        {
            addressConfiguration.ToTable("address", DEFAULT_SCHEMA);

            addressConfiguration.Property<int>("Id")
                .IsRequired();

            addressConfiguration.HasKey("Id");
        }

        void ConfigureBuyer(EntityTypeBuilder<Buyer> buyerConfiguration)
        {
            buyerConfiguration.ToTable("buyers", DEFAULT_SCHEMA);

            buyerConfiguration.HasKey(b => b.Id);

            buyerConfiguration.Property(b => b.Id)
                .ForSqlServerUseSequenceHiLo("buyerseq", DEFAULT_SCHEMA);

            buyerConfiguration.Property(b=>b.IdentityGuid)
                .HasMaxLength(200)
                .IsRequired();

            buyerConfiguration.HasIndex("IdentityGuid")
              .IsUnique(true);

            buyerConfiguration.HasMany(b => b.PaymentMethods)
               .WithOne()
               .HasForeignKey("BuyerId")
               .OnDelete(DeleteBehavior.Cascade);

            var navigation = buyerConfiguration.Metadata.FindNavigation(nameof(Buyer.PaymentMethods));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        void ConfigurePayment(EntityTypeBuilder<PaymentMethod> paymentConfiguration)
        {
            paymentConfiguration.ToTable("paymentmethods", DEFAULT_SCHEMA);

            paymentConfiguration.HasKey(b => b.Id);

            paymentConfiguration.Property(b => b.Id)
                .ForSqlServerUseSequenceHiLo("paymentseq", DEFAULT_SCHEMA);

            paymentConfiguration.Property<int>("BuyerId")
                .IsRequired();

            paymentConfiguration.Property<string>("CardHolderName")
                .HasMaxLength(200)
                .IsRequired();

            paymentConfiguration.Property<string>("Alias")
                .HasMaxLength(200)
                .IsRequired();

            paymentConfiguration.Property<string>("CardNumber")
                .HasMaxLength(25)
                .IsRequired();

            paymentConfiguration.Property<DateTime>("Expiration")
                .IsRequired();

            paymentConfiguration.Property<int>("CardTypeId")
                .IsRequired();

            paymentConfiguration.HasOne(p => p.CardType)
                .WithMany()
                .HasForeignKey("CardTypeId");
        }

        void ConfigureContractor(EntityTypeBuilder<Contractor> ContractorConfiguration)
        {
            ContractorConfiguration.ToTable("Contractors", DEFAULT_SCHEMA);

            ContractorConfiguration.HasKey(o => o.Id);

            ContractorConfiguration.Property(o => o.Id)
                .ForSqlServerUseSequenceHiLo("Contractorseq", DEFAULT_SCHEMA);

            ContractorConfiguration.Property<DateTime>("ContractorDate").IsRequired();
            ContractorConfiguration.Property<int>("BuyerId").IsRequired();
            ContractorConfiguration.Property<int>("ContractorStatusId").IsRequired();
            ContractorConfiguration.Property<int>("PaymentMethodId").IsRequired();

            var navigation = ContractorConfiguration.Metadata.FindNavigation(nameof(Contractor.ContractorItems));
            // DDD Patterns comment:
            //Set as Field (New since EF 1.1) to access the ContractorItem collection property through its field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            ContractorConfiguration.HasOne(o => o.PaymentMethod)
                .WithMany()
                .HasForeignKey("PaymentMethodId")
                .OnDelete(DeleteBehavior.Restrict);

            ContractorConfiguration.HasOne(o => o.Buyer)
                .WithMany()
                .HasForeignKey("BuyerId");

            ContractorConfiguration.HasOne(o => o.ContractorStatus)
                .WithMany()
                .HasForeignKey("ContractorStatusId");
        }

        void ConfigureContractorItems(EntityTypeBuilder<ContractorItem> ContractorItemConfiguration)
        {
            ContractorItemConfiguration.ToTable("ContractorItems", DEFAULT_SCHEMA);

            ContractorItemConfiguration.HasKey(o => o.Id);

            ContractorItemConfiguration.Property(o => o.Id)
                .ForSqlServerUseSequenceHiLo("Contractoritemseq");

            ContractorItemConfiguration.Property<int>("ContractorId")
                .IsRequired();

            ContractorItemConfiguration.Property<decimal>("Discount")
                .IsRequired();

            ContractorItemConfiguration.Property<int>("ProductId")
                .IsRequired();

            ContractorItemConfiguration.Property<string>("ProductName")
                .IsRequired();

            ContractorItemConfiguration.Property<decimal>("UnitPrice")
                .IsRequired();

            ContractorItemConfiguration.Property<int>("Units")
                .IsRequired();

            ContractorItemConfiguration.Property<string>("PictureUrl")
                .IsRequired(false);
        }

        void ConfigureContractorStatus(EntityTypeBuilder<ContractorStatus> ContractorStatusConfiguration)
        {
            ContractorStatusConfiguration.ToTable("Contractorstatus", DEFAULT_SCHEMA);

            ContractorStatusConfiguration.HasKey(o => o.Id);

            ContractorStatusConfiguration.Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            ContractorStatusConfiguration.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }

        void ConfigureCardTypes(EntityTypeBuilder<CardType> cardTypesConfiguration)
        {
            cardTypesConfiguration.ToTable("cardtypes", DEFAULT_SCHEMA);

            cardTypesConfiguration.HasKey(ct => ct.Id);

            cardTypesConfiguration.Property(ct => ct.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            cardTypesConfiguration.Property(ct => ct.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
