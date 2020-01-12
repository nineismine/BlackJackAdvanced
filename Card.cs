using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackAdvanced
{
    class Card
    {
        private int value;
        private CardType type;
        private PlayerType owner;
        //0 is down 1 is up 
        private Facing facing;
        private bool isUp; 

        public int Value { get => value; private set => this.value = value; }
        public PlayerType Owner { get => owner; set => owner = value; }
        internal CardType Type { get => type; set => type = value; }
         public Facing Facing { get => facing; set => facing = value; }
        public bool IsUp { get => this.IsFaceUp(this); set => this.isUp = value; }

        public Card(int card,  Facing isFaceUp)
        {
            Type = (CardType)card;
            Value = GetCardValue(Type);
             IsUp = isUp;
         }

        private bool IsFaceUp(Card card)
        {
            return (card.Facing == (Facing )1)  ?  true : false;            
        }

        private int GetCardValue(CardType type)
        {
            switch (type)
            {
                case CardType.Two:
                    return 2;
                case CardType.Three:
                    return 3;
                case CardType.Four:
                    return 4;
                case CardType.Five:
                    return 5;
                case CardType.Six:
                    return 6;
                case CardType.Seven:
                    return 7;
                case CardType.Eight:
                    return 8;
                case CardType.Nine:
                    return 9;
                case CardType.Ten:
                case CardType.Jack:
                case CardType.Queen:
                case CardType.King:
                    return 10;
                case CardType.Ace:
                    return 11;
                default:
                    break;
            }
            return 0;
        }
    }

    public  enum Facing
    {
        Down = 0,
        Up = 1
    }
    public enum CardType
    {
        
        Two = 2,
        Three = 3, 
        Four = 4, 
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10 , 
        Jack = 11, 
        Queen = 12, 
        King = 13, 
        Ace = 14 

    }
}
