//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SE.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public Customer()
        {
            this.OrderHead = new HashSet<OrderHead>();
            this.RecipientAddress = new HashSet<RecipientAddress>();
            this.CashBack = new HashSet<CashBack>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    
        public virtual ICollection<OrderHead> OrderHead { get; set; }
        public virtual ICollection<RecipientAddress> RecipientAddress { get; set; }
        public virtual ICollection<CashBack> CashBack { get; set; }
    }
}
