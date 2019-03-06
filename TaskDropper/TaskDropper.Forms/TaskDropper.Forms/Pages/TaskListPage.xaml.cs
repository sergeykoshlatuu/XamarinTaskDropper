using MvvmCross.Forms.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDropper.Core.ViewModels;
using Xamarin.Forms;
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