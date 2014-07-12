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
    public class CommunityBussinessLogic : BussinessLogicBase<Community>
    {
        public CommunityBussinessLogic(EfRepository<Community> communityRepository)
            : base(communityRepository)
        {

        }

        public PagedList<Community> Search(CommunitySearchCriteria criteria)
        {
            if (criteria.OrderByFields.Count == 0)
            {
                criteria.OrderByFields.Add(new OrderByField<Community>(i => i.Id, SortOrder.Descending));
            }

            if (criteria.PagingRequest == null)
            {
                criteria.PagingRequest = new PagingRequest(0, int.MaxValue);
            }

            var query = PrimaryRepository.Table;
            
            if (criteria.ProviceId.HasValue)
            {
                query = query.Where(i => i.ChinaCounty.ChinaCity.ChinaProvince.Id == criteria.ProviceId.Value);
            }
            if (criteria.CityId.HasValue)
            {
                query = query.Where(i => i.ChinaCounty.ChinaCity.Id == criteria.CityId.Value);
            }
            if (criteria.CountyId.HasValue)
            {
                query = query.Where(i => i.CountyId == criteria.CountyId.Value);
            }
            if (!string.IsNullOrEmpty(criteria.FirstLetter))
            {
                query = query.Where(i=>i.FirstLetter == criteria.FirstLetter);
            }


            query = query.OrderBy<Community>(criteria.OrderByFields);

            var result = new PagedList<Community>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }

    }

}
