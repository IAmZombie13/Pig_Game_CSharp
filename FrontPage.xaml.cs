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
    /// Interaction logic for FrontPage.xaml
    /// </summary>
    public partial class FrontPage : UserControl
    {
        List<ContentControl> controls;
        DataTable dt = new DataTable();
        public FrontPage(List<ContentControl> cc)
        {
            InitializeComponent();
            controls = cc;
            
            

            dt.Columns.Add("String");
            dt.Columns.Add("Int");

            dt.Rows.Add("2 Player",2);
            dt.Rows.Add("3 Player", 3);
            dt.Rows.Add("4 Player", 4);

            FrontCB.ItemsSource = dt.DefaultView;
            FrontCB.DisplayMemberPath = "String";
            FrontCB.SelectedValuePath = "Int";
            FrontCB.SelectedIndex=0;
        }

        private void OnExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnPlayGame(object sender, RoutedEventArgs e)
        {
            MainGame main = new MainGame(controls);
            EndPage end = new EndPage(controls,dt);

            controls[0].Content = main;
            controls[1].Content = end;

            main.No_of_players = int.Parse(FrontCB.SelectedValue.ToString());
        }
    }
}
