using System;
using System.Threading.Tasks;

namespace ERPAdmin.Services.Contractors.Infrastructure.Repositories
{
    public interface IRequestManager
    {
        Task<bool> ExistAsync(Guid id);
        Task CreateRequestForCommandAsync<T>(Guid id);
    }
}
