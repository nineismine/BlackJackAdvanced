using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackAdvanced
{
    class Player
    {
        List<Card> heldCards = new List<Card>();
        int total = 0;
        bool busted = false;  
        bool standing = false;
        string name;
        public int Total { get => total; set => total = value; }
      
      //  public bool IsStanding { get => isStanding; set => isStanding = value; }
        public string Name { get => name; set => name = value; }
        internal List<Card> HeldCards { get => heldCards; set => heldCards = value; }
        public bool Busted { get => busted; set => busted = value; }
        public bool Standing { get => standing; set => standing = value; }

        public Player(string name)
        {
            Name = name;
        }

        //add a card to the play collection
        public void AddCard(Card card)
        {
            heldCards.Add(card);
        }

        public int GetTotal()
        {
            this.Total = 0;
            foreach (Card card in HeldCards)
            {
                this.Total += card.Value;
            }
            return Total;
        }
        //TODO: display element should move to display class
        public void Stand()
        {
         
            standing = true;
        }


        public bool IsBusted()
        {

            return busted = (Total > 21) ? true : false;
        }

        public void Init()
        {
            heldCards.Clear();
            total = 0;
            name = "";
            standing = false;
            busted = false;

        }
    }
    //End Player
   
    public enum PlayerType
    {
        Player = 1,
        Dealer = 2
    }
}
