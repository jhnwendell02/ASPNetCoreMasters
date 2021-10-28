using ASPNetCoreMastersTodoList.Api.Authorization;
using Autofac;
using Microsoft.AspNetCore.Authorization;
using Repositories;
using Repositories.Implementation;
using Repositories.Interfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Dependency
{
    public class RegisterDependency : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Scoped
            builder.RegisterType<ItemService>().As<IItemService>().InstancePerLifetimeScope();
            //Transient
            builder.RegisterType<ItemRepository>().As<IItemRepository>().InstancePerDependency();
            //Singleton
            builder.RegisterType<DataContext>().SingleInstance();

        }
    }
}
