using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame
    {
        public bool Play(model.Game a_game, view.IView a_view)
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

            //Store it in model
            a_game.Input = input;

            //Change int input into string
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
            
        }
    }
}
