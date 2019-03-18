using MvvmCross.Binding.Wpf;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platforms.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFropper.WPF
{
    public class Setup : MvxWpfSetup<TaskDropper.Core.App>
    {
        /// <summary>Initializes a new instance of the <see cref="Setup"/> class.</summary>
        /// <param name="applicationDelegate">The application delegate.</param>
        /// <param name="window">The window.</param>
        public Setup()
            : base()
        {

        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

        }
    }
}
