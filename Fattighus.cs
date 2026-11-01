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

        public string visaFattighus() 
        {
            string toReturn = "";

            for (int i = 0; i < Cols - 7; i++)
            {
                if (i == 3)
                {
                    // Console.ForegroundColor = ConsoleColor.Yellow;
                    toReturn += "Poor House";
                    // Console.ResetColor();
                }
                else
                {
                    toReturn += '*';
                }
            }
            toReturn += "\n";

            for (int i = 0; i < Rows; i++)
            {
                toReturn += '*';
                for (int j = 0; j < Cols; j++)
                {
                    toReturn += fattighus[i, j];
                }
                toReturn += '*';
                toReturn += "\n";
            }
            for (int i = 0; i < Cols + 2; i++)
            {
                toReturn += '*';
            }
            toReturn += "\n";
            return toReturn;
        }

    }
}
