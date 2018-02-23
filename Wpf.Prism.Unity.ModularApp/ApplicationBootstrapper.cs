using System;
using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;

namespace Wpf.Prism.Unity.ModularApp
{
    public class ApplicationBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (MainWindow)Shell;
            if (Application.Current.MainWindow != null)
                Application.Current.MainWindow.Show();
            else
                throw new NullReferenceException(nameof(Application.Current.MainWindow));

            //var manager = Container.Resolve<IModuleManager>();
            //foreach (var module in ModuleCatalog.Modules)
            //{
            //    manager.LoadModule(module.ModuleName);
            //}
        }

        /// <summary>
        /// Returns the module catalog that will be used to initialize the modules.
        /// </summary>
        /// <returns>
        /// An instance of <see cref="IModuleCatalog"/> that will be used to initialize the modules.
        /// </returns>
        /// <remarks>
        /// When using the default initialization behavior, this method must be overwritten by a derived class.
        /// </remarks>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ApplicationModuleCatalog();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var appCatatlog = (ApplicationModuleCatalog) ModuleCatalog;

            // Module A is referenced to the project and added by code.
            Type moduleAType = typeof(ModuleA.ModuleA);
            appCatatlog.AddModule(new ModuleInfo(moduleAType.Name, moduleAType.AssemblyQualifiedName));

            
            // Module B is defined in configuration AppConfig (module section).
            ConfigurationModuleCatalog configurationCatalog = new ConfigurationModuleCatalog();
            appCatatlog.AddCatalog(configurationCatalog);

            // Module C is not defined by will be loaded from diretory.
            DirectoryModuleCatalog directoryCatalog = new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
            appCatatlog.AddCatalog(directoryCatalog);
        }
    }
}