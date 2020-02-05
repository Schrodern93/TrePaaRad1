using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TrePåRad
{
    class BoardModel
    {
        public string Spiller1 { get; set; } = "X";
        public string Spiller2 { get; set; } = "O";
        private int runde = 1;

        public string[,] matrix { get; set; } = new string[3, 3];

        public void Board(string koordinat, string spiller)
        {
            int koord1;
            int koord2;

            if (CoordinateIsValid(koordinat))
            {
                koord1 = Int32.Parse(koordinat.Substring(1, 1)) - 1;
                koord2 = koordinat.Substring(0, 1) == "a" ? 0 : koordinat.Substring(0, 1) == "b" ? 1 : 2;
                matrix[koord1, koord2] = spiller;
                this.runde++;
            }
            else
            {
                UgyldigKoordinat();
            }
        }

        public bool CoordinateIsValid(string koordinat)
        {
            if (!(koordinat.Substring(0, 1) == "a" || koordinat.Substring(0, 1) == "b" || koordinat.Substring(0, 1) == "c" &&
               koordinat.Substring(1, 1) == "1" || koordinat.Substring(1, 1) == "2" || koordinat.Substring(1, 1) == "3"))
            {
                return false;
            }

            int koord1 = Int32.Parse(koordinat.Substring(1, 1)) - 1;
            int koord2 = koordinat.Substring(0, 1) == "a" ? 0 : koordinat.Substring(0, 1) == "b" ? 1 : 2;

            if (matrix[koord1, koord2] != null)
            {
                return false;
            }

            return true;
        }


        public string Spiller()
        {
            return this.runde % 2 == 0 ? "O" : "X";
        }

        public string Spiller(string forrige)
        {
            return this.runde - 1 % 2 == 0 ? "O" : "X";
        }


        public bool Vunnet()
        {
            var s = this.Spiller("Forrigespiller");
            var m = this.matrix;


            return m[0, 0] == s && m[0, 1] == s && m[0, 2] == s ||
                   m[1, 0] == s && m[1, 1] == s && m[1, 2] == s ||
                   m[2, 0] == s && m[2, 1] == s && m[2, 2] == s ||
                   m[0, 0] == s && m[1, 0] == s && m[2, 0] == s ||
                   m[0, 1] == s && m[1, 1] == s && m[2, 1] == s ||
                   m[0, 2] == s && m[1, 2] == s && m[2, 2] == s ||
                   m[0, 0] == s && m[1, 1] == s && m[2, 2] == s ||
                   m[0, 2] == s && m[1, 1] == s && m[2, 0] == s;
        }

        public void UgyldigKoordinat()
        {
            System.Console.WriteLine("Ugyldig koordinat: prøv igjen (eks.: a3)");
            string input = System.Console.ReadLine();
            Board(input, Spiller());
        }

        public void SpillPaaNytt()
        {
            this.matrix = new string[3, 3];
            this.runde = 1;
        }

    }
}
