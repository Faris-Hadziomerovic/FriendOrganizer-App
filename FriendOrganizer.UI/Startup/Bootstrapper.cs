using Autofac;
using Prism.Events;
using FriendOrganizer.UI.ViewModels;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Views.Services;
//using FriendOrganizer.DataAccess;
//using FriendOrganizer.UI.Data.Lookups;
//using FriendOrganizer.UI.Data.Repositories;
//using FriendOrganizer.UI.Views.Services;

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
            builder.RegisterType<NavigationViewModel>().AsSelf();
            builder.RegisterType<FriendDetailsViewModel>().AsSelf();

            builder.RegisterType<FriendDataService>().As<IFriendDataService>(); // change later

            //builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            //builder.RegisterType<FriendDetailsViewModel>().As<IFriendDetailsViewModel>();

            builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();

            //builder.RegisterType<FriendsOrganizerDbContext>().AsSelf();

            //builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            //builder.RegisterType<FriendRepository>().As<IFriendRepository>();

            return builder.Build();

        }
    }
}