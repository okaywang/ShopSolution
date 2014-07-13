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
    
    public partial class Account
    {
        public Account()
        {
            this.AccountAuthority = new HashSet<AccountAuthority>();
        }
    
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public SE.Common.Types.AccountType AccountType { get; set; }
    
        public virtual ICollection<AccountAuthority> AccountAuthority { get; set; }
        public virtual AdminPerson AdminPerson { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
