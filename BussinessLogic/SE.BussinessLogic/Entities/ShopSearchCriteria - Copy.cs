using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;
using SE.Common.Types;

namespace SE.BussinessLogic
{
    public class PersonSearchCriteria : SearchCriteria<AdminPerson>
    {  
        public string NamePart { get; set; } 
    } 
}
