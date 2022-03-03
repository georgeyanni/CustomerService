using CustomerService.Data.Helper;
using CustomerService.Domain.Filter;
using CustomerService.Domain.Interfaces.Common;
using CustomerService.Domain.Services;
using CustomerService.Domain.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PagedResponse<List<T>>> GetAllAsync([FromQuery] PaginationFilter filter, string route, IUriService uriService)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var pagedData = await _context.Set<T>()
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToListAsync();

            var totalRecords = await _context.Set<T>().CountAsync();

            var pagedReponse = PaginationHelper.CreatePagedReponse<T>(pagedData, validFilter, totalRecords, uriService, route);

            return pagedReponse;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
          
            return await _context.Set<T>().FindAsync(id);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
