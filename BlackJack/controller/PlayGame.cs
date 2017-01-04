using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BlackJack.model;
using BlackJack.view;

namespace BlackJack.controller
{
    class PlayGame : Observer
    {

        private Game a_game;
        private IView a_view;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            this.a_game = a_game;
            this.a_view = a_view;

            a_game.AddObserver(this);

            //this.a_game.AddSubscribers(this);
        }

        public void Update()
        {
            a_view.delay();
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());
        }

        /*
        public void Update()
        {
            Thread.Sleep(1500);
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            Thread.Sleep(1500);
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());
            Thread.Sleep(1000);

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }
        }
        */


        public bool Play()
        {
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }


            //Get int input from view
            int input = a_view.GetInput();

            if (a_view.WantToPlay(input))
            {
                a_game.NewGame();
            }
            else if (a_view.WantToHit(input))
            {
                a_game.Hit();
            }
            else if (a_view.WantToStand(input))
            {
                a_game.Stand();
            }
            else if (a_view.WantToQuit(input))
            {
                return false;
            }

            return true;

            //Change int input into string
            /*
            char inputCharacter = (char)input;
            string inputString = inputCharacter.ToString();

            if (inputString != "q")
            {
                
                if (inputString == "p")
                {
                    a_game.NewGame();
                    return true;
                }
                if (inputString == "h")
                {
                    a_game.Hit();
                    return true;
                }
                if (inputString == "s")
                {
                    a_game.Stand();
                    return true;
                }
                return true;
            }
            else
            {
                return false;
            }
            */

        }
    }
}
