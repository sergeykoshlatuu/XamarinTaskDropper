using MvvmCross.Forms.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDropper.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace TaskDropper.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskChangePage : MvxContentPage<TaskChangedViewModel>
    {
        public TaskChangePage()
        {
            InitializeComponent();
        }

        private async void AttachPhotoClicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Attach Photo", "Cancel", null, "From gallery", "From Camera");
            Debug.WriteLine("Action: " + action);
            if (action == "From gallery")
            {
                ViewModel.ChoosePictureCommand.Execute();
            }
            if (action == "From Camera")
            {
                ViewModel.TakePictureCommand.Execute();
            }
        }

    }
}