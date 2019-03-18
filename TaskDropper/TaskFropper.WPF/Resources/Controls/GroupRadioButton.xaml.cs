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

namespace TaskFropper.WPF.Resources.Controls
{
    /// <summary>
    /// Interaction logic for GroupRadioButton.xaml
    /// </summary>
    public partial class GroupRadioButton : UserControl
    {
        public GroupRadioButton()
        {
            InitializeComponent();
        }

        public string LabelTextRadio1
        {
            get { return (string)GetValue(LabelTextPropertyRadio1); }
            set { SetValue(LabelTextPropertyRadio1, value); }
        }

        public static readonly DependencyProperty LabelTextPropertyRadio1 =
            DependencyProperty.Register("LabelTextRadio1", typeof(string), typeof(GroupRadioButton), new PropertyMetadata(string.Empty));

        public string LabelTextRadio2
        {
            get { return (string)GetValue(LabelTextPropertyRadio2); }
            set { SetValue(LabelTextPropertyRadio2, value); }
        }

        public static readonly DependencyProperty LabelTextPropertyRadio2 =
            DependencyProperty.Register("LabelTextRadio2", typeof(string), typeof(GroupRadioButton), new PropertyMetadata(string.Empty));

    }
}
