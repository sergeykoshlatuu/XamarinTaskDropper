using MvvmCross.Forms.Views;
using System;
using System.Diagnostics;
using TaskDropper.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace TaskDropper.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskChangePage : MvxContentPage<TaskChangedViewModel>
    {
      
        public TaskChangePage()
        {
            InitializeComponent();
            Subscribe();
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
                //ViewModel.CheckPermissionForCamera();
                
                //if (ViewModel.CheckPermissionForCamera())
                
                    ViewModel.TakePictureCommand.Execute();
            }
            
        }

        private void Subscribe()
        {
           
            MessagingCenter.Subscribe<Page>(
               this, // кто подписывается на сообщения
               "iosPermission",   // название сообщения
               (sender) => {
                   var action = DisplayActionSheet("Go to app setings and get this app camera permission", "Cancel", null);
               });    // вызываемое действие


        }
    }
}