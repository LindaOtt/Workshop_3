using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class DealerWinsOnEqualScore : IWhoWinsOnEqualScoreStrategy
    {
        public bool DoesDealerWin(Dealer a_dealer, Player a_player)
        {
            if (a_dealer.CalcScore() == a_player.CalcScore()) {
                return true;
            }
            return false;
        }
    }
}
