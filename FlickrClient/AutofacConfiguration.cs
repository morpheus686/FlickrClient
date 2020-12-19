using Autofac;
using FlickrClient.DomainModel.Services;
using FlickrClient.Services;
using FlickrClient.ViewModel;
using FlickrClient.ViewModel.Authentification;
using FlickrClient.ViewModel.PhotoStream;
using FlickrClient.ViewModel.Search;

namespace FlickrClient
{
    public class AutofacConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorizationService>()
                .As<IAuthorizationService>()
                .SingleInstance();

            builder.RegisterType<FlickrService>()
                .As<IFlickrService>()
                .SingleInstance();

            builder.RegisterType<ViewService>()
                .As<IViewService>()
                .SingleInstance();

            builder.RegisterType<DialogService>()
                .As<IDialogService>()
                .SingleInstance();

            builder.RegisterType<SettingsService>()
                .As<ISettingsService>()
                .SingleInstance();

            builder.RegisterType<NavigationService>()
                .As<INavigationService>()
                .SingleInstance();

            builder.RegisterType<PhotostreamService>()
                .As<IPhotostreamService>()
                .SingleInstance();

            builder.RegisterType<MainWindowViewModel>()
                .SingleInstance(); 

            builder.RegisterType<SearchTabViewModel>()
                .SingleInstance();

            builder.RegisterType<AuthentificationDialogViewModel>();

            builder.RegisterType<PhotoStreamTabViewModel>()
                .SingleInstance();
        }
    }
}
