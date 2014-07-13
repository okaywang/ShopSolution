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
    public class PersonBussinessLogic : BussinessLogicBase<AdminPerson>
    {
        public PersonBussinessLogic(EfRepository<AdminPerson> personRepository)
            : base(personRepository)
        {
        }

        public PagedList<AdminPerson> Search(PersonSearchCriteria criteria)
        {
            if (criteria.OrderByFields.Count == 0)
            {
                criteria.OrderByFields.Add(new OrderByField<AdminPerson>(i => i.Id, SortOrder.Descending));
            }
            if (criteria.PagingRequest == null)
            {
                criteria.PagingRequest = new PagingRequest(0, int.MaxValue);
            }

            var query = PrimaryRepository.Table;
            if (!string.IsNullOrEmpty(criteria.NamePart))
            {
                query = query.Where(i => i.Name.Contains(criteria.NamePart));
            } 
            query = query.OrderBy<AdminPerson>(criteria.OrderByFields);
            var result = new PagedList<AdminPerson>(query, criteria.PagingRequest.PageIndex, criteria.PagingRequest.PageSize);
            return result;
        }
    }

}
