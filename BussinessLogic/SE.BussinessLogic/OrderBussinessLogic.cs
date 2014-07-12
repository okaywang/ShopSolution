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
    public class OrderBussinessLogic : BussinessLogicBase<OrderHead>
    {    
        public OrderBussinessLogic(EfRepository<OrderHead> OrderHeadRepository)
            : base(OrderHeadRepository)
        {
          
        }
        public PagedList<OrderHead> Search(OrderSearchCriteria criteria)
        {
            if (criteria.OrderByFields.Count == 0)
            {
                criteria.OrderByFields.Add(new OrderByField<OrderHead>(i => i.Id, SortOrder.Descending));
            }
            if (criteria.PagingRequest == null)
            {
                criteria.PagingRequest = new PagingRequest(0, int.MaxValue);
            }
            var query = PrimaryRepository.Table.Where(i => i.CustomerId == criteria.CustomerId);
            if (criteria.StartOrderTime.HasValue)
            {
                query = query.Where(i => i.TransactionDateTime >= criteria.StartOrderTime);
            }
            if (criteria.EndOrderTime.HasValue)
            {
                query = query.Where(i => i.TransactionDateTime <= criteria.EndOrderTime);
            }
            query = query.OrderBy<OrderHead>(criteria.OrderByFields);
            var result = new PagedList<OrderHead>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }

    }
}
