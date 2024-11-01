using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace PigGameSpace
{

    public class PigGame
    {

        public delegate void OnNotify();
        public event OnNotify OnGameEnd;
        public event OnNotify OnGameLost;

        class Player
        {
            public int score;
            public int curr_score;

            public Player()
            {
                score = 0;
                curr_score = 0;
            }

        };

        List<Player> players = [];

        Player ActivePlayer;

        public int Score(int player)
        {
            if (player <= no_of_players)
            {
                return players[player].score;
            }
            else
            {
                return 0;
            }
        }

        public int Current_Score(int player)
        {
            if (player <= no_of_players)
            {
                return players[player].curr_score;
            }
            else
            {
                return 0;
            }
        }


        //default true in case someone calls it without setting
        bool _gameEnd = true;
        public bool GameEnd { get => _gameEnd; }

        //in case they run score and curr score without setting
        int no_of_players = -1;

        int _curr_player = 0;
        //Property created to control setting of curr player
        int Curr_player
        {
            get => _curr_player;
            set
            {
                if (value >= no_of_players)
                {
                    _curr_player = 0;
                }
                else
                {
                    _curr_player = value;
                }
            }

        }


        //to set the values for game start
        public void Set(int no_of_players)
        {
            this.no_of_players = no_of_players;
            players = [];

            while (no_of_players > 0)
            {
                players.Add(new Player());
                no_of_players--;
            }

            _curr_player = 0;
            _gameEnd = false;
            ActivePlayer = players[_curr_player];
        }

        //REturns A random dice roll
        static int RollDice()
        {
            return RandomNumberGenerator.GetInt32(1, 7);
        }

        //Starts the Game
        public int GameStart()
        {
            if (GameEnd)
            {
                throw new Exception("Please call set first before calling gamestart");
            }

            int dice = RollDice();

            if (dice == 1)
            {
                ActivePlayer.curr_score = 0;
                OnGameLost?.Invoke();
                End();
            }
            else
            {
                ActivePlayer.curr_score += dice;
            }

            return dice;
        }

        public void End()
        {
            ActivePlayer.score += ActivePlayer.curr_score;
            ActivePlayer.curr_score = 0;

            if (ActivePlayer.score >= 100)
            {
                OnGameEnd?.Invoke();
                no_of_players = -1;
                _gameEnd = true;
                return;
            }

            Curr_player++;
            ActivePlayer = players[Curr_player];

        }

    }

}