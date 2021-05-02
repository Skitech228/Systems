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
using System.Windows.Shapes;

namespace Systems.Views
{
    /// <summary>
    /// Логика взаимодействия для UnregisteredUserPage.xaml
    /// </summary>
    public partial class UnregisteredUserPage : Page
    {
        public UnregisteredUserPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //new MainWindow().Frame1.Source = new Uri(@"Views\LogInAndRegistrationPage.xaml",
            //                                         System.UriKind.RelativeOrAbsolute);
        }
    }
}
