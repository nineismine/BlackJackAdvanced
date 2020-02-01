using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackAdvanced
{
    class BlackjackEngine
    {
        public Card DealCard( Facing facing)
        {
            Random newCard = new Random();
            Card card = new Card(newCard.Next(2, 15),  facing);
            //add faceup 
            return card;
        }

        public Card HIt()
        {
             return DealCard(Facing.Up);
        }

        public List<Card> GetStartingHand(List<Card> cardsHeld, PlayerType playerType)
        {
            cardsHeld.Clear();
            for (int i = 0; i < 2; i++)
            {
                cardsHeld.Add(DealCard((Facing)i ) );
            }
            return cardsHeld;
        }
        public int GetPlayerTotal(Player player)
        {
            //initialize the player total so we can recalculate
            player.Total = 0;
            foreach(Card card in player.HeldCards)
            {
                player.Total += card.Value;
            }
             return player.Total;
        }
        

        public bool DealerCanHit(Player dealer)
        {
            //Dealer rules 
            // if the dealers total is > 17.. STAY
            //IF the dealer total is < 17 hit
            dealer.GetTotal();
            if (!dealer.IsBusted() && dealer.Total < 17  )
                return true;
            else return false;
        }

        public bool PlayerCanHit(Player player)
        {
            player.GetTotal();
            
          if (player.IsBusted())
            return false;
          else
            return true;

        }

        public Player GetWinner(Player player, Player dealer)
        {
            player.GetTotal();
            dealer.GetTotal();
            //if busted 
            if (player.IsBusted())
                return dealer;
            if (dealer.IsBusted())
                return player;
            //else who has a greater hand
            if (player.Total > dealer.Total )
                return player;
            else
                return dealer;
        }
              
    }
}


    

