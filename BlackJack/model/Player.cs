using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Player
    {
        //private List<BlackJack.model.IObserver> subscribers = new List<BlackJack.model.IObserver>();

        private List<Card> m_hand = new List<Card>();


        public void DealCard(Card a_card)
        {
            m_hand.Add(a_card);
            //Notify();
        }

        public IEnumerable<Card> GetHand()
        {
            return m_hand.Cast<Card>();
        }

        public void ClearHand()
        {
            m_hand.Clear();
        }

        public void ShowHand()
        {
            foreach (Card c in GetHand())
            {
                c.Show(true);
                //Notify();
            }
        }

        public int CalcScore()
        {
            int[] cardScores = new int[(int)model.Card.Value.Count]
                {2, 3, 4, 5, 6, 7, 8, 9, 10, 10 ,10 ,10, 11};
            int score = 0;

            foreach(Card c in GetHand()) {
                if (c.GetValue() != Card.Value.Hidden)
                {
                    score += cardScores[(int)c.GetValue()];
                }
            }

            if (score > 21)
            {
                foreach (Card c in GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace && score > 21)
                    {
                        score -= 10;
                    }
                }
            }

            return score;
        }

        /*
        public void AddSubscribers(IObserver a_subscriber)
        {
            subscribers.Add(a_subscriber);
        }
        

        private void Notify()
        {
            foreach (IObserver a_subscriber in subscribers)
            {
                a_subscriber.Update();
            }
        }
        */
    }
}
