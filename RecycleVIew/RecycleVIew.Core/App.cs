using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;
using RecycleVIew.Core.ViewModels;
using MvvmCross;
using MvvmCross.IoC;
using RecycleVIew.Core.Interface;

namespace RecycleVIew.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
               .EndingWith("Service")
               .AsInterfaces()
               .RegisterAsLazySingleton();

            var foo = Mvx.IoCProvider.Resolve<IDatabaseConnectionService>();
            RegisterAppStart<TasksListViewModel>();            
        }
    }
}
