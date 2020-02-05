using System;
using System.Collections.Generic;
using System.Text;

namespace TrePåRad
{

    /*
     *   a b c
        ┌─────┐
       1│o    │
       2│    o│
       3│× ×  │
        └─────┘
     */
    class BoardView
    {
        public static void Show()
        {
            var board = "Hei";
            Console.WriteLine("  a b c ");
            Console.WriteLine(" ┌─────┐");
            Console.WriteLine("1│o    │");
            Console.WriteLine("2│    o│");
            Console.WriteLine("3│× ×  │");
            Console.WriteLine(" └─────┘");

        }

        public static void ShowBoardModel(BoardModel brett)
        {
            var rader = new string[] { "1|", "2|", "3|" };


            for (int i = 0; i < brett.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < brett.matrix.GetLength(0); j++)
                {

                    var karakter = brett.matrix[i, j] == null ? " " : brett.matrix[i,j];

                    rader[i] += karakter;

                    var radutfyller =  j == (brett.matrix.GetLength(0) - 1) ? rader[i] += "|" : rader[i] += " ";
                }
            }




            Console.WriteLine("  a b c ");
            Console.WriteLine(" ┌─────┐");
            Console.WriteLine(rader[0]);
            Console.WriteLine(rader[1]);
            Console.WriteLine(rader[2]);
            Console.WriteLine(" └─────┘");
        }
    }
}
