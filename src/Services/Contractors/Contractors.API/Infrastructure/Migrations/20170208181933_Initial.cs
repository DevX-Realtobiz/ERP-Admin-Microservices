using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ERPAdmin.Services.Contractors.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Contractors");

            migrationBuilder.CreateSequence(
                name: "Contractoritemseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "buyerseq",
                schema: "Contractors",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Contractorseq",
                schema: "Contractors",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "paymentseq",
                schema: "Contractors",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "buyers",
                schema: "Contractors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IdentityGuid = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buyers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cardtypes",
                schema: "Contractors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cardtypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "address",
                schema: "Contractors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contractorstatus",
                schema: "Contractors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractorstatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "paymentmethods",
                schema: "Contractors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Alias = table.Column<string>(maxLength: 200, nullable: false),
                    BuyerId = table.Column<int>(nullable: false),
                    CardHolderName = table.Column<string>(maxLength: 200, nullable: false),
                    CardNumber = table.Column<string>(maxLength: 25, nullable: false),
                    CardTypeId = table.Column<int>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentmethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_paymentmethods_buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalSchema: "Contractors",
                        principalTable: "buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_paymentmethods_cardtypes_CardTypeId",
                        column: x => x.CardTypeId,
                        principalSchema: "Contractors",
                        principalTable: "cardtypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contractors",
                schema: "Contractors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    BuyerId = table.Column<int>(nullable: false),
                    ContractorDate = table.Column<DateTime>(nullable: false),
                    ContractorStatusId = table.Column<int>(nullable: false),
                    PaymentMethodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contractors_address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Contractors",
                        principalTable: "address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contractors_buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalSchema: "Contractors",
                        principalTable: "buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contractors_Contractorstatus_ContractorStatusId",
                        column: x => x.ContractorStatusId,
                        principalSchema: "Contractors",
                        principalTable: "Contractorstatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contractors_paymentmethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalSchema: "Contractors",
                        principalTable: "paymentmethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractorItems",
                schema: "Contractors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    ContractorId = table.Column<int>(nullable: false),
                    PictureUrl = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Units = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractorItems_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalSchema: "Contractors",
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_buyers_IdentityGuid",
                schema: "Contractors",
                table: "buyers",
                column: "IdentityGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_paymentmethods_BuyerId",
                schema: "Contractors",
                table: "paymentmethods",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_paymentmethods_CardTypeId",
                schema: "Contractors",
                table: "paymentmethods",
                column: "CardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_AddressId",
                schema: "Contractors",
                table: "Contractors",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_BuyerId",
                schema: "Contractors",
                table: "Contractors",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_ContractorStatusId",
                schema: "Contractors",
                table: "Contractors",
                column: "ContractorStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_PaymentMethodId",
                schema: "Contractors",
                table: "Contractors",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorItems_ContractorId",
                schema: "Contractors",
                table: "ContractorItems",
                column: "ContractorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractorItems",
                schema: "Contractors");

            migrationBuilder.DropTable(
                name: "Contractors",
                schema: "Contractors");

            migrationBuilder.DropTable(
                name: "address",
                schema: "Contractors");

            migrationBuilder.DropTable(
                name: "Contractorstatus",
                schema: "Contractors");

            migrationBuilder.DropTable(
                name: "paymentmethods",
                schema: "Contractors");

            migrationBuilder.DropTable(
                name: "buyers",
                schema: "Contractors");

            migrationBuilder.DropTable(
                name: "cardtypes",
                schema: "Contractors");

            migrationBuilder.DropSequence(
                name: "Contractoritemseq");

            migrationBuilder.DropSequence(
                name: "buyerseq",
                schema: "Contractors");

            migrationBuilder.DropSequence(
                name: "Contractorseq",
                schema: "Contractors");

            migrationBuilder.DropSequence(
                name: "paymentseq",
                schema: "Contractors");
        }
    }
}
