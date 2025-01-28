using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace Hillel_HW7_Demchenko 
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.Play();
        }
    }

    public class TicTacToe
    {
        public void Play()
        {
            int activePlayer = 0;
            char[] field = new char[9];
            int move;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Player 1: X");
                Console.WriteLine("Player 2: O");
                Console.WriteLine();
                Console.WriteLine("Current field:");

                for (int i = 0; i < field.Length; i++)
                {
                    if (field[i] == '\0')
                    {
                        Console.Write((i + 1) + " ");
                    }
                    else
                    {
                        Console.Write(field[i] + " ");
                    }
                    if ((i + 1) % 3 == 0)
                    {
                        Console.WriteLine();
                    }
                }

                if (activePlayer == 0)
                {
                    Console.WriteLine("Player 1, enter your move (1-9):");
                }
                else
                {
                    Console.WriteLine("Player 2, enter your move (1-9):");
                }

                while (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 9 || field[move - 1] != '\0')
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 9 that is not already taken.");
                }

                field[move - 1] = activePlayer == 0 ? 'X' : 'O';

                activePlayer = (activePlayer + 1) % 2;
                if (CheckWin(field))
                {
                    Console.Clear();
                    Console.WriteLine("Player {0} wins!", activePlayer == 0 ? 2 : 1);
                    break;
                }

                if (Array.IndexOf(field, '\0') == -1) 
                {
                    Console.Clear();
                    Console.WriteLine("It's a draw!");
                    break;
                }
            }
        }

        private bool CheckWin(char[] field)
        {
            int[,] winConditions = new int[,]
            {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, 
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8},  
                {0, 4, 8}, {2, 4, 6}               
            };
            return false;
        }
    }
}