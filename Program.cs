using System;

namespace TrePåRad
{
    class Program
    {
        static void Main(string[] args)
        {
            var Spillerbrett = new BoardModel();
            string brukerinput;
            var PlayAgain = true;

            while (PlayAgain == true)
            {
                while (Spillerbrett.Vunnet() == false)
                {
                    Console.Clear();
                    BoardView.ShowBoardModel(Spillerbrett);

                    System.Console.WriteLine("Spiller \"{0}\": Skriv inn koordinat (eks: \"a2\")", Spillerbrett.Spiller());
                    //System.Console.WriteLine($"Spiller \"{Spillerbrett.Spiller()}\": Skriv inn koordinat (eks: \"a2\")");
                    brukerinput = Console.ReadLine();
                    Spillerbrett.Board(brukerinput, Spillerbrett.Spiller());

                }
                BoardView.ShowBoardModel(Spillerbrett);

                System.Console.WriteLine($"Spiller {Spillerbrett.Spiller("Forrigespiller")} har vunnet!");
                var tekst = System.Console.ReadLine() == "y" ? PlayAgain = true : PlayAgain = false;
                Spillerbrett.SpillPaaNytt();
            }
        }
    }
}
