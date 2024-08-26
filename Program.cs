using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hid_Konem
{
    internal class Program
    {
        static char[,] ChessPossitionArray = new Char[8, 8];

        enum Term
        {
            None = '0',
            Player = 'P',
            Enemy = 'E',
            PlTail = '+',
            EnTail = '-'
        }

        static void Main(string[] args)
        {

            #region Створення дошки
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ChessPossitionArray[i, j] = (char)Term.None;
                }
            }
            #endregion

            Random rand = new Random();


            Console.WriteLine("Hallo");
            Console.Write("Pls write your position: ");
            string position = Console.ReadLine();

            int row = 0;
            int PRow = 0;
            int PCol = 0;
            bool isPlayerFounded = false;

            #region Пошук позиції
            foreach (var letter in "ABCDEFGH")
            {
                for (int i = 1; i < 9; i++)
                {
                    string i1 = i.ToString();
                    string l1 = letter.ToString();
                    l1 += i1;
                    if (l1 == position) 
                    {
                        ChessPossitionArray[row, i - 1] = (char)Term.Player;
                        PRow = row;
                        PCol = i - 1;
                        isPlayerFounded = true;
                        break;
                    }

                    if (letter == 'H' && i == 8)
                    {
                        Console.WriteLine("Sorry, I cant understand your position on a chess board");
                        Console.WriteLine("Pls, restart the app");
                    }
                }
                if (isPlayerFounded)
                {
                    break;
                }
                row++;
            }
            #endregion

            if (isPlayerFounded)
            {
                SetEnemy(rand, PRow, PCol);

                #region Відображення дошки
                Console.WriteLine();
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write(' ');
                        Console.Write(ChessPossitionArray[i, j]);
                    }

                    Console.WriteLine();
                }
                #endregion
            }

            // Delay
            Console.ReadKey();
        }

        static void SetEnemy(Random rand, int PRow, int PCol) 
        {
            int EnRow = rand.Next(0, 8);
            int EnCol = rand.Next(0, 8);

            if (ChessPossitionArray[EnRow, EnCol] != ChessPossitionArray[PRow, PCol]) 
            {
                ChessPossitionArray[EnRow, EnCol] = (char)Term.Enemy;
            }
            else
            {
                SetEnemy(rand, PRow, PCol);
            }
        }
    }
}
