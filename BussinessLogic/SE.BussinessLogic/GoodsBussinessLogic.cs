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
    public class GoodsBussinessLogic : BussinessLogicBase<Sku>
    {
        private EfRepository<SkuCategory> _categoryRepository;
        private EfRepository<SkuType> _typeRepository;
        public GoodsBussinessLogic(EfRepository<Sku> primaryRepository, EfRepository<SkuCategory> categoryRepository, EfRepository<SkuType> typeRepository)
            : base(primaryRepository)
        {
            _categoryRepository = categoryRepository;
            _typeRepository = typeRepository;
        }
        /// <summary>
        /// 获取商品分类
        /// </summary>
        public PagedList<SkuCategory> GetSkuCategory(SkuCategorySearchCriteria criteria)
        {
            var query = _categoryRepository.Table;
            if (!string.IsNullOrEmpty(criteria.NamePart))
            {
                query = query.Where(p => p.Name.Contains(criteria.NamePart));
            }

            if (criteria.OrderByFields.Count == 0)
            {
                criteria.OrderByFields.Add(new OrderByField<SkuCategory>(i => i.Id, SortOrder.Descending));
            }
            if (criteria.PagingRequest == null)
            {
                criteria.PagingRequest = new PagingRequest(0, int.MaxValue);
            }

            query = query.OrderBy<SkuCategory>(criteria.OrderByFields);

            var result = new PagedList<SkuCategory>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }
        /// <summary>
        /// 获取商品类型
        /// </summary>
        public PagedList<SkuType> GetSkuType(SkuTypeSearchCriteria criteria)
        {
            var query = _typeRepository.Table;
            if (criteria.SkuCategoryId.HasValue)
            {
                query = query.Where(p => p.SkuCategoryId == criteria.SkuCategoryId);
            }
            if (!string.IsNullOrEmpty(criteria.NamePart))
            {
                query = query.Where(p => p.Name.Contains(criteria.NamePart));
            }

            if (criteria.OrderByFields.Count == 0)
            {
                criteria.OrderByFields.Add(new OrderByField<SkuType>(i => i.Id, SortOrder.Descending));
            }
            if (criteria.PagingRequest == null)
            {
                criteria.PagingRequest = new PagingRequest(0, int.MaxValue);
            }

            query = query.OrderBy<SkuType>(criteria.OrderByFields);

            var result = new PagedList<SkuType>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }


    }
}
