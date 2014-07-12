using SE.DataAccess;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExpress.Core;

namespace SE.BussinessLogic
{
    public class OrderDeatailSearchCriteria : SearchCriteria<OrderBody>
    {
         public string OrderNumber { get; set; }
    }
}
