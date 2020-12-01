using Autofac;
using FlickrClient.DomainModel.Services;
using FlickrClient.Services;
using FlickrClient.ViewModel;
using FlickrClient.ViewModel.PhotoStream;
using FlickrClient.ViewModel.Search;

namespace FlickrClient
{
    public class AutofacConfiguration : Autofac.Module
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

            builder.RegisterType<MainWindowViewModel>()
                .SingleInstance();

            builder.RegisterType<SearchTabViewModel>()
                .As<TabViewModel>()
                .SingleInstance();

            builder.RegisterType<PhotoStreamTabViewModel>()
                .As<TabViewModel>()
                .SingleInstance();
        }
    }
}
