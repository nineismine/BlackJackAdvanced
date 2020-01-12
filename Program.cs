using System;
using System.Collections.Generic;

namespace BlackJackAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackjackEngine engine = new BlackjackEngine();
            Player player = new Player("Player");
            Player dealer = new Player("The house");
            // Start the Game , deal the cards
            StartGameLoop(player, dealer, engine);
        }
        
        public static void StartGameLoop(Player player, Player dealer, BlackjackEngine engine)
        {
            InitializeGame(player, dealer, engine);
            DisplayAllCards(player);
            //Typically in blackjack the dealer's first card is dealt facedowna
            //Show the player their current Total
            DisplayNewTotal(player, engine);

            while (engine.PlayerCanHit(player)) // loop indefinitely
            {
                Console.WriteLine("Would you like to (H)it or (S)tay?");
                string userInput = Console.ReadLine();
                //Check for users input 
                //if the player is busted quit , if the player selects H or HIT give them a card 
                //if the player chooses to stand break the loop 
                if (userInput.ToUpper() == "H" || userInput.ToUpper() == "HIT")
                {
                    Card card = engine.HIt();
                    Console.WriteLine("You got a {0}", card.Type);
                    player.HeldCards.Add(card);
                    DisplayNewTotal(player, engine);
                }
                else
                {
                    if (userInput.ToUpper() == "S" || userInput.ToUpper() == "STAY")
                        player.Stand();
                    break;
                }
            }
            if (player.IsBusted())
            {
                DisplayBust(player);
            }
            //Clear The Console 
            
            while (engine.DealerCanHit(dealer) && !player.IsBusted() )
            {
                Card card = engine.HIt();
                Console.WriteLine("Dealer got a {0}", card.Type);
                dealer.HeldCards.Add(card);
                DisplayNewTotal(dealer, engine);
            }
            if (dealer.IsBusted())
            {
                DisplayBust(dealer);
            }
            else
                DisplayStandMessage(player);

            ShowGameResults(player, dealer, engine);
            StartGameLoop(player, dealer, engine);
        }
        public static bool CheckBust(Player player, BlackjackEngine engine)
        {
            //pass in the payer to get the new total
           engine.GetPlayerTotal(player);
            if (player.IsBusted())
            {
                DisplayBust(player);
            }
            return player.IsBusted();
        }

        public static void ShowGameResults(Player player, Player dealer, BlackjackEngine engine)
        {
            DisplayNewTotal(player, engine);
            DisplayNewTotal(dealer, engine);
            DisplayPlayerWon(engine.GetWinner(player, dealer));
            Console.WriteLine("Play Again? (Y)es or (N)");
            string response = Console.ReadLine();
            if (response.ToUpper() == "Y")
                StartGameLoop(player, dealer, engine);
            Console.Clear();
        }

    public static void DisplayAllCards(Player player)
        {
            Console.WriteLine("{0} has the following cards  : ", player.Name);

            //only show the first card dealt to the dealer 
            foreach (Card card in player.HeldCards)
            {
                Console.WriteLine(card.Type);
            }
        }
        public static void DisplayCardByIndex(Player player, int index) 
        {
            Console.WriteLine("{0} has the following card showing  : ", player.Name);
            Console.WriteLine("{0}", player.HeldCards[index].Type);
            
        }
        public static void DisplayPlayerWon(Player player)
        {
            Console.WriteLine("{0} Won!", player.Name);
        }
        public static void DisplayNewTotal(Player player, BlackjackEngine engine)
        {
            engine.GetPlayerTotal(player);
            Console.WriteLine("{0} 's  total is {1}", player.Name, player.Total.ToString());
        }
        public static void DisplayBust(Player player)
        {
            Console.WriteLine("{0} Busted", player.Name);
        }
        public static void DisplayStandMessage(Player player)
        {
            Console.Clear();
            Console.WriteLine("{0} Stands", player.Name);
        }
        
        public static void InitializeGame(Player player, Player dealer, BlackjackEngine engine)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            player.Busted = false;
            dealer.Busted = false;
            Console.Clear();
            Console.WriteLine("Welcome to Blackjack try to get as close to 21 as you can without busting!");
            player.HeldCards = engine.GetStartingHand(player.HeldCards, PlayerType.Player);
            dealer.HeldCards = engine.GetStartingHand(dealer.HeldCards, PlayerType.Dealer);

        }

        // while ()

        //  PrintCurrentHand(cardsHeld);

        //First card is face down second is face up 
        //cardsHeld.Add(engine.DealCard());
    }
}







    


    

