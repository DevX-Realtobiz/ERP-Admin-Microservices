namespace ERPAdmin.Services.Contractors.API.Application.Queries
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System;
    using System.Dynamic;
    using System.Collections.Generic;

    public class ContractorQueries
        : IContractorQueries
    {
        private string _connectionString = string.Empty;

        public ContractorQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }


        public async Task<dynamic> GetContractor(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"select o.[Id] as Contractornumber,o.ContractorDate as date, os.Name as status, 
                        oi.ProductName as productname, oi.Units as units, oi.UnitPrice as unitprice, oi.PictureUrl as pictureurl, 
						a.Street as street, a.City as city, a.Country as country, a.State as state, a.ZipCode as zipcode
                        FROM Contractors.Contractors o
                        INNER JOIN Contractors.Address a ON o.AddressId = a.Id 
                        LEFT JOIN Contractors.Contractoritems oi ON o.Id = oi.Contractorid 
                        LEFT JOIN Contractors.Contractorstatus os on o.ContractorStatusId = os.Id
                        WHERE o.Id=@id"
                        , new { id }
                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapContractorItems(result);
            }
        }

        public async Task<dynamic> GetContractors()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<dynamic>(@"SELECT o.[Id] as Contractornumber,o.[ContractorDate] as [date],os.[Name] as [status],SUM(oi.units*oi.unitprice) as total
                     FROM [Contractors].[Contractors] o
                     LEFT JOIN[Contractors].[Contractoritems] oi ON  o.Id = oi.Contractorid 
                     LEFT JOIN[Contractors].[Contractorstatus] os on o.ContractorStatusId = os.Id
                     GROUP BY o.[Id], o.[ContractorDate], os.[Name]");
            }
        }

        public async Task<dynamic> GetCardTypes()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<dynamic>("SELECT * FROM Contractors.cardtypes");
            }
        }

        private dynamic MapContractorItems(dynamic result)
        {
            dynamic Contractor = new ExpandoObject();

            Contractor.Contractornumber = result[0].Contractornumber;
            Contractor.date = result[0].date;
            Contractor.status = result[0].status;
            Contractor.street = result[0].street;
            Contractor.city = result[0].city;
            Contractor.zipcode = result[0].zipcode;
            Contractor.country = result[0].country;

            Contractor.Contractoritems = new List<dynamic>();
            Contractor.total = 0;

            foreach (dynamic item in result)
            {
                dynamic Contractoritem = new ExpandoObject();
                Contractoritem.productname = item.productname;
                Contractoritem.units = item.units;
                Contractoritem.unitprice = item.unitprice;
                Contractoritem.pictureurl = item.pictureurl;

                Contractor.total += item.units * item.unitprice;
                Contractor.Contractoritems.Add(Contractoritem);
            }

            return Contractor;
        }
    }
}
