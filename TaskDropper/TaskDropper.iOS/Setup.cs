using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Reflection;
using TaskDropper.Core;
using TaskDropper.Core.Interface;
using TaskDropper.iOS.Services;
using UIKit;

namespace TaskDropper.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        /// <summary>Initializes a new instance of the <see cref="Setup"/> class.</summary>
        /// <param name="applicationDelegate">The application delegate.</param>
        /// <param name="window">The window.</param>
        public Setup()
            : base()
        {
            
        }

        /// <summary>Creates the application.</summary>
        /// <returns>The IMvxApplication <see langword="object"/></returns>
        protected override IMvxApplication CreateApp()
        {
            CreatableTypes()
                      .EndingWith("Service")
                      .AsInterfaces()
                      .RegisterAsLazySingleton();
            Mvx.RegisterType<IDatabaseConnectionService, DatabaseConnectionService>();
            Mvx.RegisterType<IPhotoService, PhotoService>();
            return new Core.App();
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
        }
    }
}
