using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE.Website.Models
{
    public class CustomerModel : ITranslatable<Customer, CustomerModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationTime { get; set; }
        public int OrderHeadCounts { get; set; }
        //累积可返现
        public decimal CumulativeBackPrice { get; set; }
        public int CashBack { get; set; }

        public CustomerModel Translate(Customer from)
        {
            this.Id = from.Id;
            this.Name = from.Name;
            this.PhoneNumber = from.PhoneNumber;
            this.OrderHeadCounts = from.OrderHead.Count();
            this.CashBack = from.CashBack.Count();
            return this;
        }
    }
}