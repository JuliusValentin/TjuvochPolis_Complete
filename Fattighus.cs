using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvochPolis
{
    internal class Fattighus : Place // OBS! alla kommentarer finns i Stad.cs
    {
        char[,] fattighus;

        public Fattighus() : base (10,50) 
        {
            fattighus = new char[Rows, Cols];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    fattighus[i, j] = ' ';
                }
            }
        }

        public void visaFattighus() 
        {
            for (int i = 0; i < Cols - 7; i++)
            {
                if (i == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Poor House");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write('*');
                }
            }
            Console.WriteLine();

            for (int i = 0; i < Rows; i++)
            {
                Console.Write('*');
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(fattighus[i, j]);
                }
                Console.Write('*');
                Console.WriteLine();
            }
            for (int i = 0; i < Cols + 2; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
        }

    }
}
