using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace SE.BussinessLogic
{
    public class CustomerBussinessLogic : BussinessLogicBase<Customer>
    {
        public CustomerBussinessLogic(EfRepository<Customer> CustomerRepository)
            : base(CustomerRepository)
        {
            
        }

        public PagedList<Customer> Search(CustomerSearchCriteria criteria)
        {
            if (criteria.OrderByFields.Count == 0)
            {
                criteria.OrderByFields.Add(new OrderByField<Customer>(i => i.Id, SortOrder.Descending));
            }

            if (criteria.PagingRequest == null)
            {
                criteria.PagingRequest = new PagingRequest(0, int.MaxValue);
            }

            var query = PrimaryRepository.Table;

            if (!string.IsNullOrEmpty(criteria.PhonePart))
            {
                query = query.Where(i => i.PhoneNumber.Contains(criteria.PhonePart));
            }
            query = query.OrderBy<Customer>(criteria.OrderByFields);
            var result = new PagedList<Customer>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }

       
    }
}
