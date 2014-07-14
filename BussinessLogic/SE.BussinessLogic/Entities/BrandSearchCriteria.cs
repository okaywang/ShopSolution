using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace SE.BussinessLogic
{
    public class BrandSearchCriteria : SearchCriteria<Brand>
    {
        public string NamePart { get; set; }
    }
}
