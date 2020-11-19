using Autofac;
using FlickrClient.Profile.Services;

namespace FlickrClient.Profile
{
    public class AutofacConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProfileManager>()
                .As<IProfileManager>()
                .SingleInstance();
        }
    }
}
