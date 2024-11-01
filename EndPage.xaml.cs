using System;
using System.Collections.Generic;
using System.Data;
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

namespace ThePigGame
{
    /// <summary>
    /// Interaction logic for EndPage.xaml
    /// </summary>
    public partial class EndPage : UserControl
    {
        List<ContentControl> controls;
        public EndPage(List<ContentControl> cc,DataTable dt)
        {
            InitializeComponent();
            controls = cc;

            EndCB.ItemsSource = dt.DefaultView;
            EndCB.DisplayMemberPath = "String";
            EndCB.SelectedValuePath = "Int";
            EndCB.SelectedIndex = 0;
        }

        public void Change(int i)
        {
            EndText.Text = string.Format("Player {0} Won",i);
        }

        private void OnExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnPlayAgain(object sender, RoutedEventArgs e)
        {
            controls[0].Content = controls[1].Content;
            controls[1].Content = this;

            MainGame main = controls[0].Content as MainGame;
            main.No_of_players = int.Parse(EndCB.SelectedValue.ToString());
        }
    }
}
