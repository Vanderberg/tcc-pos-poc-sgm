using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGM.Web.Application.Services
{
    public interface IGenericService<T>
    {
        void SetUrl(string url);
        string GetUrl();

        void SetToken(string token);

        Task<IEnumerable<T>> FindAllAsync(string recurso = "");
        
        Task<T> FindByIdAsync(Guid id, string recurso = "");
        Task<T> VotarByIdAsync(Guid id, string recurso = "");

        Task<T> CompleteFindByIdAsync(Guid id);

        Task<int> InsertAsync(T obj, string recurso = "");        

        Task<bool> UpdateAsync(Guid id, T obj, string recurso = "");

        Task<bool> DeleteAsync(Guid id, string recurso = "");
        
    }
}