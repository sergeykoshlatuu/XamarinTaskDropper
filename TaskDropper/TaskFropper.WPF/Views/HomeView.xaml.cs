using MvvmCross.Platforms.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskDropper.Core.ViewModels;

namespace TaskFropper.WPF.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : MvxWpfView<HomeViewModel>
    {
        public HomeView()
        {
            InitializeComponent();
            TextBox textBox = new TextBox();
            textBox.Text = "Hello world";
            textBox.FontSize = 72;

            contentView.Content = textBox;
        }

        private void TaskChangedItem_Click(object sender, RoutedEventArgs e)
        {
            contentView.Content = ViewModel.TaskChangedViewModel;
        }

        private void AboutItem_Click(object sender, RoutedEventArgs e)
        {
            contentView.Content = ViewModel.AboutViewModel;
        }
    }
}
