using CustomerService.Domain.Filter;
using System;


namespace CustomerService.Domain.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
