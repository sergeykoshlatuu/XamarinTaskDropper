using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using TaskDropper.Core.ViewModels;

namespace TaskDropper.Forms.Pages
{
    [MvxTabbedPagePresentation(TabbedPosition.Root, NoHistory = true)]
    public partial class HomePage : MvxTabbedPage<HomeViewModel>
    {
        public HomePage ()
        {    
            InitializeComponent();
        }
        public bool IsFirstTime = true;
        protected override void OnAppearing()
        {
            if (IsFirstTime)
            {
                base.OnAppearing();
                TaskListPage page1 = new TaskListPage();
                page1.ViewModel = ViewModel.TaskListViewModel;
                AboutView page2 = new AboutView();
                page2.ViewModel = ViewModel.AboutViewModel;
                tabs.Children.Add(page1);
                tabs.Children.Add(page2);
                IsFirstTime = false;
                tabs.HeightRequest = 30;
            }
        }
    }
}