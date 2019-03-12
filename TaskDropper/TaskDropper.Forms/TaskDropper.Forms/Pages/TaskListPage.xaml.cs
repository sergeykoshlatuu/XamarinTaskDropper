using MvvmCross.Forms.Views;
using System;
using System.Diagnostics;
using TaskDropper.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace TaskDropper.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskListPage : MvxContentPage<TasksListViewModel>
    {
        public TaskListPage()
        {
            try
            {               
                 InitializeComponent();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("_____________________________________");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("_____________________________________");
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        
    }
}