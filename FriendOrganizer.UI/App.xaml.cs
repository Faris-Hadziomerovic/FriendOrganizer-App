﻿using Autofac;
using FriendOrganizer.UI.Startup;
using System.Windows;


namespace FriendOrganizer.UI
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var mainWindow = container.Resolve<MainWindow>();

            mainWindow.Show();
        }
    }
}

//      not good because of code expansion but can be used for unit testing

// var mainWindow = new MainWindow(new MainViewModel(new FriendDataService()));
