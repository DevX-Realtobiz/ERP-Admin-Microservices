using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ERPAdmin.Services.Contractors.Infrastructure;

namespace ERPAdmin.Services.Contractors.API.Migrations
{
    [DbContext(typeof(ContractorsContext))]
    partial class ContractorsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            //modelBuilder
            //    .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
            //    .HasAnnotation("SqlServer:Sequence:.contractoritemseq", "'contractoritemseq', '', '1', '10', '', '', 'Int64', 'False'")
            //    .HasAnnotation("SqlServer:Sequence:Contractors.buyerseq", "'buyerseq', 'Contractors', '1', '10', '', '', 'Int64', 'False'")
            //    .HasAnnotation("SqlServer:Sequence:Contractors.contractorseq", "'contractorseq', 'Contractors', '1', '10', '', '', 'Int64', 'False'")
            //    .HasAnnotation("SqlServer:Sequence:Contractors.paymentseq", "'paymentseq', 'Contractors', '1', '10', '', '', 'Int64', 'False'")
            //    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //modelBuilder.Entity("ERPAdmin.Services.Contractors.Domain.AggregatesModel.BuyerAggregate.Buyer", b =>
            //{
            //    b.Property<int>("Id")
            //        .ValueGeneratedOnAdd()
            //        .HasAnnotation("SqlServer:HiLoSequenceName", "buyerseq")
            //        .HasAnnotation("SqlServer:HiLoSequenceSchema", "Contractors")
            //        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

            //    b.Property<string>("IdentityGuid")
            //        .IsRequired()
            //        .HasMaxLength(200);

            //    b.HasKey("Id");

            //    b.HasIndex("IdentityGuid")
            //        .IsUnique();

            //    b.ToTable("buyers", "Contractors");
            //});

            //modelBuilder.Entity("ERPAdmin.Services.Contractors.Domain.AggregatesModel.BuyerAggregate.CardType", b =>
            //{
            //    b.Property<int>("Id")
            //        .HasDefaultValue(1);

            //    b.Property<string>("Name")
            //        .IsRequired()
            //        .HasMaxLength(200);

            //    b.HasKey("Id");

            //    b.ToTable("cardtypes", "Contractors");
            //});

            //modelBuilder.Entity("ERPAdmin.Services.Contractors.Domain.AggregatesModel.BuyerAggregate.PaymentMethod", b =>
            //{
            //    b.Property<int>("Id")
            //        .ValueGeneratedOnAdd()
            //        .HasAnnotation("SqlServer:HiLoSequenceName", "paymentseq")
            //        .HasAnnotation("SqlServer:HiLoSequenceSchema", "Contractors")
            //        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

            //    b.Property<string>("Alias")
            //        .IsRequired()
            //        .HasMaxLength(200);

            //    b.Property<int>("BuyerId");

            //    b.Property<string>("CardHolderName")
            //        .IsRequired()
            //        .HasMaxLength(200);

            //    b.Property<string>("CardNumber")
            //        .IsRequired()
            //        .HasMaxLength(25);

            //    b.Property<int>("CardTypeId");

            //    b.Property<DateTime>("Expiration");

            //    b.HasKey("Id");

            //    b.HasIndex("BuyerId");

            //    b.HasIndex("CardTypeId");

            //    b.ToTable("paymentmethods", "Contractors");
            //});

            //modelBuilder.Entity("ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate.Address", b =>
            //{
            //    b.Property<int>("Id")
            //        .ValueGeneratedOnAdd();

            //    b.Property<string>("City");

            //    b.Property<string>("Country");

            //    b.Property<string>("State");

            //    b.Property<string>("Street");

            //    b.Property<string>("ZipCode");

            //    b.HasKey("Id");

            //    b.ToTable("address", "Contractors");
            //});

            //modelBuilder.Entity("ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate.Contractor", b =>
            //{
            //    b.Property<int>("Id")
            //        .ValueGeneratedOnAdd()
            //        .HasAnnotation("SqlServer:HiLoSequenceName", "orderseq")
            //        .HasAnnotation("SqlServer:HiLoSequenceSchema", "Contractors")
            //        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

            //    b.Property<int?>("AddressId");

            //    b.Property<int>("BuyerId");

            //    b.Property<DateTime>("ContractorDate");

            //    b.Property<int>("ContractorStatusId");

            //    b.Property<int>("PaymentMethodId");

            //    b.HasKey("Id");

            //    b.HasIndex("AddressId");

            //    b.HasIndex("BuyerId");

            //    b.HasIndex("ContractorStatusId");

            //    b.HasIndex("PaymentMethodId");

            //    b.ToTable("contractors", "Contractors");
            //});

            //modelBuilder.Entity("ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate.ContractorItem", b =>
            //{
            //    b.Property<int>("Id")
            //        .ValueGeneratedOnAdd()
            //        .HasAnnotation("SqlServer:HiLoSequenceName", "contractoritemseq")
            //        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

            //    b.Property<decimal>("Discount");

            //    b.Property<int>("ContractorId");

            //    b.Property<string>("PictureUrl");

            //    b.Property<int>("ProductId");

            //    b.Property<string>("ProductName")
            //        .IsRequired();

            //    b.Property<decimal>("UnitPrice");

            //    b.Property<int>("Units");

            //    b.HasKey("Id");

            //    b.HasIndex("ContractorId");

            //    b.ToTable("contractorItems", "Contractors");
            //});

            //modelBuilder.Entity("ERPAdmin.Services.Contractors.Domain.AggregatesModel.OrderAggregate.OrderStatus", b =>
            //{
            //    b.Property<int>("Id")
            //        .HasDefaultValue(1);

            //    b.Property<string>("Name")
            //        .IsRequired()
            //        .HasMaxLength(200);

            //    b.HasKey("Id");

            //    b.ToTable("contractorstatus", "Contractors");
            //});

            //modelBuilder.Entity("Contractors.Infrastructure.ClientRequest", b =>
            //{
            //    b.Property<Guid>("Id")
            //        .ValueGeneratedOnAdd();

            //    b.Property<string>("Name")
            //        .IsRequired();

            //    b.Property<DateTime>("Time");

            //    b.HasKey("Id");

            //    b.ToTable("requests", "Contractors");
            //});

            //modelBuilder.Entity("ERPAdmin.Services.Contractors.Domain.AggregatesModel.BuyerAggregate.PaymentMethod", b =>
            //{
            //    b.HasOne("ERPAdmin.Services.Contractors.Domain.AggregatesModel.BuyerAggregate.Buyer")
            //        .WithMany("PaymentMethods")
            //        .HasForeignKey("BuyerId")
            //        .OnDelete(DeleteBehavior.Cascade);

            //    b.HasOne("ERPAdmin.Services.Contractors.Domain.AggregatesModel.BuyerAggregate.CardType", "CardType")
            //        .WithMany()
            //        .HasForeignKey("CardTypeId")
            //        .OnDelete(DeleteBehavior.Cascade);
            //});

            //modelBuilder.Entity("ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate.Contractor", b =>
            //{
            //    b.HasOne("ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate.Address", "Address")
            //        .WithMany()
            //        .HasForeignKey("AddressId");

            //    b.HasOne("ERPAdmin.Services.Contractors.Domain.AggregatesModel.BuyerAggregate.Buyer", "Buyer")
            //        .WithMany()
            //        .HasForeignKey("BuyerId")
            //        .OnDelete(DeleteBehavior.Cascade);

            //    b.HasOne("ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate.ContractorStatus", "ContractorStatus")
            //        .WithMany()
            //        .HasForeignKey("ContractorStatusId")
            //        .OnDelete(DeleteBehavior.Cascade);

            //    b.HasOne("ERPAdmin.Services.Contractors.Domain.AggregatesModel.BuyerAggregate.PaymentMethod", "PaymentMethod")
            //        .WithMany()
            //        .HasForeignKey("PaymentMethodId");
            //});

            //modelBuilder.Entity("ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate.ContractorItem", b =>
            //{
            //    b.HasOne("ERPAdmin.Services.Contractors.Domain.AggregatesModel.ContractorAggregate.Contractor")
            //        .WithMany("ContractorItems")
            //        .HasForeignKey("ContractorId")
            //        .OnDelete(DeleteBehavior.Cascade);
            //});
        }
    }
}
