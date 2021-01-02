using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystemAPI.Repos.Interfaces
{
    public interface IBaseRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task CreateNew(T data);
        Task UpdateData(T data);
        Task<int> Save();
    }
}
