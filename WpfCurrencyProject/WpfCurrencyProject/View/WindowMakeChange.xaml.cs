using CurrencyProject;
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
using WpfCurrencyProject.ViewModel;

namespace WpfCurrencyProject.View
{
    /// <summary>
    /// Interaction logic for WindowMakeChange.xaml
    /// </summary>
public partial class WindowMakeChange : Window
    {
        ICurrencyRepo repo;

        public WindowMakeChange(ICurrencyRepo repo)
        {
            this.repo = repo;
            InitializeComponent();
        }

        /// <summary>
        /// Sets DataContext for UserControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakeChangeView1_Loaded(object sender, RoutedEventArgs e)
        {
            this.MakeChangeView1.DataContext = new MakeChangeViewModel(repo);
        }
    }
}
