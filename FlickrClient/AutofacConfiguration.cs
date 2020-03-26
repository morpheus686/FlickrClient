using Autofac;
using FlickrClient.DomainModel.Services;
using FlickrClient.Services;
using FlickrClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrClient
{
    public class AutofacConfiguration : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DialogService>()
                .As<IDialogService>()
                .SingleInstance();

            builder.RegisterType<MainWindowViewModel>()
                .SingleInstance();
        }
    }
}
