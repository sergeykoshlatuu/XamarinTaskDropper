using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using TaskDropper.Core.ViewModels;

namespace TaskDropper.Forms.Pages
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Root, WrapInNavigationPage = false, NoHistory =true)]
    public partial class MainPage : MvxMasterDetailPage<MainViewModel>
    {
       

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            if (!ViewModel.IsUserLogin())
            {
                ViewModel.ShowFormsLogin.Execute(null);
            }
            else
            {
                ViewModel.ShowHomeViewModelCommand.Execute(null);
            }

            base.OnAppearing();
        }
    }
}