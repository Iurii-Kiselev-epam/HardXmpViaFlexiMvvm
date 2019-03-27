using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using System;

namespace VacationsTracker.Core.Bootstrappers
{
    public static class BootstrapRunner
    {
        public static void Run(Func<IBootstrapper> platformBootstrapperFactory)
        {
            if (platformBootstrapperFactory == null)
            {
                throw new ArgumentNullException(nameof(platformBootstrapperFactory));
            }
            var config = new BootstrapperConfig();
            config.SetSimpleIoc(new SimpleIoc());
            var compositeBootstrapper = new CompositeBootstrapper(
                new CoreBootstrapper(),
                platformBootstrapperFactory());
            compositeBootstrapper.Execute(config);
        }
    }
}
