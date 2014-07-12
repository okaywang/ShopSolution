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
    public class ShopSearchCriteria : SearchCriteria<Shop>
    {
        public string Name { get; set; }

        public string NamePart { get; set; }

        public bool? IsIntegral { get; set; }

        #region Shop Status
        private ShopStatus? shopStatus;
        public ShopStatus? ShopStatus
        {
            get
            {
                return shopStatus;
            }
            set
            {
                shopStatus = value;
                if (shopStatus != null)
                {
                    if (shopStatus.Value == BussinessLogic.ShopStatus.Bussinessing)
                    {
                        this.CooperationStatus = ShopCooperationStatus.OpenShop;
                        this.IsBussinessing = true;
                    }
                    else if (shopStatus.Value == BussinessLogic.ShopStatus.Closed)
                    {
                        this.CooperationStatus = ShopCooperationStatus.CloseShop;
                    }
                    else if (shopStatus.Value == BussinessLogic.ShopStatus.StopBussinessing)
                    {
                        this.CooperationStatus = ShopCooperationStatus.OpenShop;
                        this.IsBussinessing = false;
                    }
                }
            }
        }
        #endregion

        internal ShopCooperationStatus? CooperationStatus { get; set; }

        internal bool? IsBussinessing { get; set; }

        public int? ProviceId { get; set; }

        public int? CityId { get; set; }

        public int? CountyId { get; set; }
    }

    public enum ShopStatus
    {
        [DisplayText("关店")]
        Closed,

        [DisplayText("营业中")]
        Bussinessing,

        [DisplayText("打烊")]
        StopBussinessing
    }
}
