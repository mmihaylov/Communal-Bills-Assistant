using Autofac;
using CBA.DataAccess;
using CBA.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CBA.Modules
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType(typeof(EFDataContext))
                .As(typeof(IDatabaseContext))
                .InstancePerLifetimeScope();
        }
    }
}