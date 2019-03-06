using MvvmCross.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDropper.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskDropper.Forms.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutView : MvxContentPage<AboutViewModel>
	{
		public AboutView ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
           
            
            base.OnAppearing();
        }
    }
}