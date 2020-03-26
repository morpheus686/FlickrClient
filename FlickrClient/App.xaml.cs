using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using FlickrClient.DomainModel.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace FlickrClient
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            InitializeAutofacContainer();
        }

        private static void InitializeAutofacContainer()
        {
            var builder = new ContainerBuilder();
            var executingAssembly = Assembly.GetExecutingAssembly();
            string executionPath = Path.GetDirectoryName(executingAssembly.Location);

            List<Assembly> allAssemblies = new List<Assembly>();
            allAssemblies.Add(executingAssembly);

            foreach (string dll in Directory.GetFiles(executionPath, "*.dll"))
            {
                allAssemblies.Add(Assembly.LoadFile(dll));
            }

            // Perform registrations and build the container.
            builder.RegisterAssemblyModules(allAssemblies.ToArray());
            var container = builder.Build();

            // Set the service locator to an AutofacServiceLocator.
            var autofacServiceLocator = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => autofacServiceLocator);
        }
    }
}
