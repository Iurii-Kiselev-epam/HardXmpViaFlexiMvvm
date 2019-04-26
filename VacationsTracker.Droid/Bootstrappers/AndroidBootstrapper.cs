using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using VacationsTracker.Droid.Navigation;
using VacationsTracker.Core.Bootstrappers;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Infrastructure;
using VacationsTracker.Droid.Infrastructure.Dialogs;

namespace VacationsTracker.Droid.Bootstrappers
{
    public class AndroidBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<INavigationService>(() => new NavigationService(), Reuse.Singleton);
            simpleIoc.Register<IDialogService>(() => new DialogService(), Reuse.Singleton);
        }
    }
}