using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKsystems.CodingExercise.Console.Utility;

namespace TEKsystems.CodingExercise.Console
{
    public static class ConfigBuilder
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(ReceiptUtility).Assembly)
                    .Where(t => t.Name.EndsWith("Utility")).AsImplementedInterfaces().InstancePerLifetimeScope();

            var container = builder.Build();
            return container;
        }
    }
}
