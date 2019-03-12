using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.IoC;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.ViewModels;
using TaskDropper.Core.Interface;
using TaskDropper.Forms.iOS.Services;
using UIKit;

namespace TaskDropper.Forms.iOS
{
    public class Setup : MvxFormsIosSetup<Core.App, App>
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
                      .AsInterfaces();
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