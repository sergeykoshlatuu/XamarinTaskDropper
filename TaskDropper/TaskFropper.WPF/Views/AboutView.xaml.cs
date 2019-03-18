

using MvvmCross.Platforms.Wpf.Binding;
using MvvmCross.Platforms.Wpf.Views;
using System.Windows;
using TaskDropper.Core.ViewModels;

namespace TaskFropper.WPF.Views
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class AboutView : MvxWpfView<AboutViewModel>
    {
        public AboutView()
        {
            InitializeComponent();
        }

        private void CustomControl_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Console.WriteLine("click");
        }

        private void LabeledTextBox_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ShowTaskChange_Click(object sender, RoutedEventArgs e)
        {
            TaskChangeView taskChangeView = new TaskChangeView();
          
        }
    }
}
