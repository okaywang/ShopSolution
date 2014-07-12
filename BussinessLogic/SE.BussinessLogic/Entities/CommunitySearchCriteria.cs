using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace SE.BussinessLogic
{
    public class CommunitySearchCriteria : SearchCriteria<Community>
    {
        public int? ProviceId { get; set; }

        public int? CityId { get; set; }

        public int? CountyId { get; set; }

        public string FirstLetter { get; set; }
    }
}
