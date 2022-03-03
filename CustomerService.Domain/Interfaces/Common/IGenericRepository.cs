using CustomerService.Domain.Filter;
using CustomerService.Domain.Services;
using CustomerService.Domain.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Domain.Interfaces.Common
{
    public interface IGenericRepository<T> where T : class 
    {
        Task AddAsync(T entity);

        Task<T> GetByIdAsync(Guid id);
        void Update(T entity);
        void Delete(T entity);

        Task<int> SaveChangesAsync();

        Task<PagedResponse<List<T>>> GetAllAsync([FromQuery] PaginationFilter filter, string route, IUriService uriService);
    }
   
}
