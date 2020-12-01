using Autofac;
using FlickrClient.Upload.Services;
using FlickrClient.Upload.ViewModel;

namespace FlickrClient.Upload
{
    public class AutofacConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UploadViewModel>()
                .SingleInstance();

            builder.RegisterType<UploadService>()
                .As<IUploadService>()
                .SingleInstance();
        }
    }
}
