using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace SE.BussinessLogic
{
    public class OrderSearchCriteria : SearchCriteria<OrderHead>
    {
        public DateTime? StartOrderTime { get; set; }
        public DateTime? EndOrderTime { get; set; }
        public int CustomerId { get; set; }
       
    }
}
