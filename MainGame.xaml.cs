using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
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
using System.Windows.Threading;
using PigGameSpace;
using static System.Net.Mime.MediaTypeNames;

namespace ThePigGame
{
    /// <summary>
    /// Interaction logic for MainGame.xaml
    /// </summary>
    public partial class MainGame : UserControl
    {
        List<ContentControl> controls;
        PigGame pi = new();

        DispatcherTimer timer;

        int _no_of_players;
        public int No_of_players 
        { 
            get => _no_of_players;
            set
            {
                _no_of_players = value;

                PlayerScores[0].Text = "0";
                PlayerScores[1].Text = "0";
                PlayerScores[2].Text = "0";
                PlayerScores[3].Text = "0";

                DiceScore.Text = "0";


                _curr_player = 0;

                switch(value)
                {
                    case 2: Player3.Visibility = Visibility.Hidden;
                            Player4.Visibility = Visibility.Hidden;
                            break;
                    case 3: Player4.Visibility = Visibility.Hidden;
                            break;
                    case 4: break;
                    default: throw new Exception("unknown value for no. of players");
                }

                pi.Set(value);
                ShowPlayerNotification();
            }
        }

        int _curr_player = 0;
        //Property created to control setting of curr player
        int Curr_player
        {
            get => _curr_player;
            set
            {
                if (value >= No_of_players)
                {
                    _curr_player = 0;
                }
                else
                {
                    _curr_player = value;
                }
            }

        }

        List<BitmapImage> Dices;
        List<TextBlock> PlayerScores;
        public MainGame(List<ContentControl> cc)
        {
            InitializeComponent();
            controls = cc;
            pi.OnGameEnd += GameOver;
            pi.OnGameLost += GameLost;

            timer = new();
            timer.Interval = TimeSpan.FromSeconds(1.5);
            timer.Tick += RemovePlayerNotification;

            PlayerNotification.Visibility = Visibility.Hidden;


            PlayerScores = new List<TextBlock>{ Player1Score, Player2Score, Player3Score, Player4Score};

            Dices = new List<BitmapImage> 
            {
                new(new Uri("pack://application:,,,/Images/One.png")),
                new(new Uri("pack://application:,,,/Images/Two.png")),
                new(new Uri("pack://application:,,,/Images/Three.png")),
                new(new Uri("pack://application:,,,/Images/Four.png")),
                new(new Uri("pack://application:,,,/Images/Five.png")),
                new(new Uri("pack://application:,,,/Images/Six.png"))
            };

            DiceImage.Source = Dices[5];
        }

        //WhenGameEnds
        public void GameOver()
        {
            (controls[1].Content as EndPage).Change(Curr_player + 1);
            controls[0].Content = controls[1].Content;
            controls[1].Content = this;
            Player3.Visibility = Visibility.Visible;
            Player4.Visibility = Visibility.Visible;
        }

        public void GameLost()
        {
            Curr_player++;
            DiceScore.Text = "0";
            MessageBox.Show("oops you rolled a 1","you lost :( womp womp", MessageBoxButton.OK);
            ShowPlayerNotification();
        }

        private void OnRollDice(object sender, RoutedEventArgs e)
        {
            int diceroll = pi.GameStart();
            DiceImage.Source = Dices[diceroll - 1];
            DiceScore.Text = pi.Current_Score(Curr_player).ToString();
        }

        private void OnEndTurn(object sender, RoutedEventArgs e)
        {
            pi.End();
            PlayerScores[Curr_player].Text = pi.Score(Curr_player).ToString();
            DiceScore.Text = "0";
            Curr_player++;
            ShowPlayerNotification();
        }
    
        private void ShowPlayerNotification()
        {
            PlayerNotificationText.Text = string.Format("Player {0}'s Turn",Curr_player+1);
            PlayerNotification.Visibility = Visibility.Visible;
            timer.Start();
        }

        private void RemovePlayerNotification(object sender, EventArgs e)
        {
            PlayerNotification.Visibility = Visibility.Hidden;
            timer.Stop();
        }
    }
}
