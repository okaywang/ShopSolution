﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShopTest10Entities : DbContext
    {
        public ShopTest10Entities()
            : base("name=ShopTest10Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountAuthority> AccountAuthority { get; set; }
        public DbSet<AdminPerson> AdminPerson { get; set; }
        public DbSet<Authority> Authority { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<BrandSkuType> BrandSkuType { get; set; }
        public DbSet<ChinaCity> ChinaCity { get; set; }
        public DbSet<ChinaCounty> ChinaCounty { get; set; }
        public DbSet<ChinaProvince> ChinaProvince { get; set; }
        public DbSet<Community> Community { get; set; }
        public DbSet<CommunityShop> CommunityShop { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<OrderBody> OrderBody { get; set; }
        public DbSet<OrderHead> OrderHead { get; set; }
        public DbSet<RecipientAddress> RecipientAddress { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<Sku> Sku { get; set; }
        public DbSet<SkuCategory> SkuCategory { get; set; }
        public DbSet<SkuType> SkuType { get; set; }
        public DbSet<SkuUnit> SkuUnit { get; set; }
        public DbSet<CashBack> CashBack { get; set; }
    }
}
