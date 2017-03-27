namespace ERPAdmin.Services.Contractors.API.Application.Queries
{
    using System.Threading.Tasks;

    public interface IContractorQueries
    {
        Task<dynamic> GetContractor(int id);

        Task<dynamic> GetContractors();

        Task<dynamic> GetCardTypes();
    }
}
