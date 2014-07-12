using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SE.DataAccess.ShopTest7Entities();

            var v = context.Account.ToList();

            var x = context.Community.ToList();

            var z = context.ChinaCounty.ToList();

            var count0 = context.Community.Count();
            using (var trans = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                var count1 = context.Community.Count();
                context.Community.Add(new SE.DataAccess.Community()
                {
                    Name = "tiantongyuan1",
                    CountyId = 1
                });
                context.SaveChanges();
                var count2 = context.Community.Count();
                context.Community.Add(new SE.DataAccess.Community()
                {
                    Name = "tiantongyuan2",
                    CountyId = 1
                });

                context.SaveChanges();
                var count3 = context.Community.Count();
                trans.Rollback();
                var count4 = context.Community.Count();
            }
            ;

            var y = x;
        }
    }
}
