﻿using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using FlexiMvvm.ViewModels;
using VacationsTracker.Core.Application.Connectivity;
using VacationsTracker.Core.Communication;
using VacationsTracker.Core.Infrastructure;
using VacationsTracker.Core.Infrastructure.Connectivity;
using VacationsTracker.Core.Navigation;
using VacationsTracker.Core.Presentation.ViewModels;
using VacationsTracker.Core.Presentation.ViewModels.Login;
using VacationsTracker.Core.Presentation.ViewModels.MainList;
using Connectivity = VacationsTracker.Core.Infrastructure.Connectivity.Connectivity;

namespace VacationsTracker.Core.Bootstrappers
{
    public class CoreBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var simpleIoc = config.GetSimpleIoc();

            SetupDependencies(simpleIoc);
            SetupViewModelLocator(simpleIoc);
            SetupViewModelProvider(simpleIoc);
        }

        private void SetupDependencies(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register<IConnectivity>(() =>
                Connectivity.Instance);
            simpleIoc.Register<IConnectivityService>(() =>
                new ConnectivityService(simpleIoc.Get<IConnectivity>()), Reuse.Singleton);

            simpleIoc.Register<IAppSettings>(() =>
                new AppSettings(), Reuse.Singleton);
            simpleIoc.Register<IXmpProxy>(() =>
                new XmpProxy(simpleIoc.Get<IAppSettings>()), Reuse.Singleton);
        }

        private void SetupViewModelLocator(ISimpleIoc simpleIoc)
        {
            simpleIoc.Register(() =>
                new EntryViewModel(simpleIoc.Get<INavigationService>()));
            simpleIoc.Register(() =>
                new LoginViewModel(
                    simpleIoc.Get<INavigationService>(),
                    simpleIoc.Get<IXmpProxy>()));
            simpleIoc.Register(() =>
                new MainListViewModel(
                    simpleIoc.Get<INavigationService>(),
                    simpleIoc.Get<IXmpProxy>()));
            simpleIoc.Register(() =>
                new VacationRequestViewModel(
                    simpleIoc.Get<INavigationService>(),
                    simpleIoc.Get<IXmpProxy>()));
        }

        private void SetupViewModelProvider(IDependencyProvider dependencyProvider)
        {
            ViewModelProvider.SetFactory(new DependencyProviderViewModelFactory(dependencyProvider));
        }
    }
}
