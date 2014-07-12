using Autofac;
using Autofac.Integration.Mvc;
using SE.BussinessLogic;
using SE.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SE.Website
{
    public class DependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ShopTest10Entities>().As<DbContext>().InstancePerHttpRequest();
            builder.RegisterGeneric(typeof(EfRepository<>)).InstancePerHttpRequest();
            builder.RegisterType<ShopBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<CommunityBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<CustomerBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<AccountBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<ChinaAreaBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<GoodsBussinessLogic>().InstancePerHttpRequest();
            builder.RegisterType<OrderBussinessLogic>().InstancePerHttpRequest();
        }
    }
}