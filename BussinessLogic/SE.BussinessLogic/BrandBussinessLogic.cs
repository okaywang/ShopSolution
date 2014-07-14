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
    public class BrandBussinessLogic : BussinessLogicBase<Brand>
    {
        public BrandBussinessLogic(EfRepository<Brand> brandRepository)
            : base(brandRepository)
        {

        }

        public PagedList<Brand> Search(BrandSearchCriteria criteria)
        {
            if (criteria.OrderByFields.Count == 0)
            {
                criteria.OrderByFields.Add(new OrderByField<Brand>(i => i.Id, SortOrder.Descending));
            }

            if (criteria.PagingRequest == null)
            {
                criteria.PagingRequest = new PagingRequest(0, int.MaxValue);
            }

            var query = PrimaryRepository.Table;
            
            
            if (!string.IsNullOrEmpty(criteria.NamePart))
            {
                query = query.Where(i => i.Name == criteria.NamePart);
            }

            query = query.OrderBy<Brand>(criteria.OrderByFields);

            var result = new PagedList<Brand>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }

    }

}
