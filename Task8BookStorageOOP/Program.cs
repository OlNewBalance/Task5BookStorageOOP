namespace DeckOfCards
{
    internal class Program
    {
        public static void Main()
        {
            var cd = new DeckOfCards();
            cd.AddCard("Bubnovyj", "King", 1);
            cd.AddCard("Bubnovyj", "Queen", 2);
            cd.AddCard("Bubnovyj", "Jack", 3);
            cd.AddCard("Bubnovyj", "10", 4);
            cd.AddCard("Bubnovyj", "9", 5);
            cd.AddCard("Bubnovyj", "8", 6);
            cd.AddCard("Bubnovyj", "7", 7);
            cd.AddCard("Bubnovyj", "6", 8);
            cd.AddCard("Bubnovyj", "5", 9);
            cd.AddCard("Bubnovyj", "4", 10);
            cd.AddCard("Bubnovyj", "3", 11);
            cd.AddCard("Bubnovyj", "2", 12);
            cd.AddCard("Bubnovyj", "Ace", 13);

            Console.WriteLine("Перед вами колода карт, чтобы достать карты, нажмите ENTER");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                if (cd._playerDeckOfCards.Count == 0)
                {
                    cd.CardReplacer();
                }
                Console.WriteLine("13 карты были вытащены из колоды");
                Console.WriteLine("Чтобы посмотреть карты, нажмите ENTER");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    cd.PrintCards();
                }
            }
        }
    }
}
