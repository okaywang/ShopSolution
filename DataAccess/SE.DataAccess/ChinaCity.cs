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
    
    public partial class ChinaCity
    {
        public ChinaCity()
        {
            this.ChinaCounty = new HashSet<ChinaCounty>();
        }
    
        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public string Name { get; set; }
    
        public virtual ChinaProvince ChinaProvince { get; set; }
        public virtual ICollection<ChinaCounty> ChinaCounty { get; set; }
    }
}
