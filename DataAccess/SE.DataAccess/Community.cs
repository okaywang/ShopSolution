//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SE.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Community
    {
        public Community()
        {
            this.CommunityShop = new HashSet<CommunityShop>();
        }
    
        public int Id { get; set; }
        public int CountyId { get; set; }
        public string FirstLetter { get; set; }
        public string Name { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
    
        public virtual ChinaCounty ChinaCounty { get; set; }
        public virtual ICollection<CommunityShop> CommunityShop { get; set; }
    }
}
