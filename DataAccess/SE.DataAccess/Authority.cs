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
    
    public partial class Authority
    {
        public Authority()
        {
            this.AccountAuthority = new HashSet<AccountAuthority>();
        }
    
        public int Id { get; set; }
        public int AuthorityType { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<AccountAuthority> AccountAuthority { get; set; }
    }
}
