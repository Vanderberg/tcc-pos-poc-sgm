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

        Task<T> CompleteFindByIdAsync(int id);

        Task<int> InsertAsync(T obj, string recurso = "");        

        Task<bool> UpdateAsync(int id, T obj, string recurso = "");

        Task<bool> DeleteAsync(int id, string recurso = "");
        
    }
}