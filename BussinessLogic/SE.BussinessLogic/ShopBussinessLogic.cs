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
    public class ShopBussinessLogic : BussinessLogicBase<Shop>
    {
        //private EfRepository<Shop> _shopRepository;
        public ShopBussinessLogic(EfRepository<Shop> shopRepository)
            : base(shopRepository)
        {
            PrimaryRepository = shopRepository;
        }

        public PagedList<Shop> Search(ShopSearchCriteria criteria)
        {
            if (criteria.OrderByFields.Count == 0)
            {
                criteria.OrderByFields.Add(new OrderByField<Shop>(i => i.Id, SortOrder.Descending));
            }
            if (criteria.PagingRequest == null)
            {
                criteria.PagingRequest = new PagingRequest(0, int.MaxValue);
            }

            var query = PrimaryRepository.Table;
            if (!string.IsNullOrEmpty(criteria.Name))
            {
                query = query.Where(i => i.Name == criteria.Name);
            }
            if (!string.IsNullOrEmpty(criteria.NamePart))
            {
                query = query.Where(i => i.Name.Contains(criteria.NamePart));
            }
            if (criteria.CooperationStatus.HasValue)
            {
                query = query.Where(i => i.CooperationStatus == criteria.CooperationStatus.Value);
            }
            if (criteria.IsIntegral.HasValue)
            {
                query = query.Where(i => i.IsIntegral == criteria.IsIntegral.Value);
            }
            if (criteria.IsBussinessing.HasValue)
            {
                var currentTime = DateTime.Now.TimeOfDay;
                if (criteria.IsBussinessing.Value)
                {
                    query = query.Where(i => currentTime >= i.DailyOpeningTime && currentTime <= i.DailyClosingTime);
                }
                else
                {
                    query = query.Where(i => currentTime < i.DailyOpeningTime || currentTime > i.DailyClosingTime);
                }
            }

            #region By China Area
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
            #endregion

            query = query.OrderBy<Shop>(criteria.OrderByFields);

            var result = new PagedList<Shop>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }
    }

}
