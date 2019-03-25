using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;
using TaskDropper.Core.ViewModels;
using MvvmCross;
using MvvmCross.IoC;
using TaskDropper.Core.Interface;
using TaskDropper.Core.Services;

namespace TaskDropper.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
               .EndingWith("Service")
               .AsInterfaces()
               .RegisterAsLazySingleton();

            //var foo = Mvx.IoCProvider.Resolve<IDatabaseConnectionService>();
            RegisterAppStart<MainViewModel>();
            //RegisterCustomAppStart<AppStart>();
        }
    }
}