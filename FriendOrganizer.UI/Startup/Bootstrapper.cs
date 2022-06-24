using Autofac;
using Prism.Events;
using FriendOrganizer.UI.Data;
using FriendOrganizer.DataAccess;
using FriendOrganizer.UI.ViewModels;
using FriendOrganizer.UI.Data.Lookups;
using FriendOrganizer.UI.Views.Services;
using FriendOrganizer.UI.ViewModels.Navigation;
using FriendOrganizer.UI.ViewModels.FriendDetails;

namespace FriendOrganizer.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            //builder.RegisterType<NavigationViewModel>().AsSelf();
            //builder.RegisterType<FriendDetailsViewModel>().AsSelf();

            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<FriendDetailsViewModel>().As<IFriendDetailsViewModel>();

            builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();

            builder.RegisterType<FriendOrganizerDbContext>().AsSelf();

            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>(); 

            return builder.Build();

        }
    }
}