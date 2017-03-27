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
           
        }
    }
}
