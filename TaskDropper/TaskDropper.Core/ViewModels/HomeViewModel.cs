using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskDropper.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {

        public override async Task Initialize()
        {
            await base.Initialize();

        }

        public HomeViewModel()
        {

        }

        public TaskChangedViewModel TaskChanged { get; set; }
        public TasksListViewModel TaskList { get; set; }
    }
}
