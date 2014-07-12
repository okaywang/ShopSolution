using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace SE.BussinessLogic
{
    public class SkuCategorySearchCriteria : SearchCriteria<SkuCategory>
    {
        public string NamePart { get; set; }
    }
}
