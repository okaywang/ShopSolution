using SE.BussinessLogic;
using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExpress.Core;
using WebExpress.Core.Guards;
using WebExpress.Website.Exceptions;

namespace SE.Website.Models
{
    public class ShopListItemModel : ITranslatable<Shop, ShopListItemModel>
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public string Name { get; set; }

        public string CityName { get; set; }

        public ShopStatus ShopStatus { get; set; }

        public DateTime ShopOpenDateTime { get; set; }

        public DateTime? TemporaryClosingBeginDate { get; set; }

        public DateTime? TemporaryClosingEndDate { get; set; }

        public ShopListItemModel Translate(Shop from)
        {
            Guard.IsNotNull<DataNotExpectedException>(from.DailyOpeningTime);
            Guard.IsNotNull<DataNotExpectedException>(from.DailyClosingTime);

            this.Id = from.Id;
            this.AccountId = from.Id;
            this.Name = from.Name;
            if (from.ShopOpenDateTime.HasValue)
            {
                this.ShopOpenDateTime = from.ShopOpenDateTime.Value;
            }
            if (from.ChinaCounty != null)
            {
                this.CityName = from.ChinaCounty.ChinaCity.Name;
            }

            if (from.CooperationStatus == Common.Types.ShopCooperationStatus.CloseShop)
            {
                this.ShopStatus = BussinessLogic.ShopStatus.Closed;
            }
            else
            {
                if (DateTime.Now.TimeOfDay.WithinPeriod(from.DailyOpeningTime.Value, from.DailyClosingTime.Value))
                {
                    this.ShopStatus = BussinessLogic.ShopStatus.Bussinessing;
                }
                else
                {
                    this.ShopStatus = BussinessLogic.ShopStatus.StopBussinessing;
                }
            }
            this.TemporaryClosingBeginDate = from.TemporaryClosingBeginDate;
            this.TemporaryClosingEndDate = from.TemporaryClosingEndDate;
            return this;
        }
    }
}