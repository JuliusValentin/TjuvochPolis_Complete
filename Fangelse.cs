using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvochPolis
{
    internal class Fangelse : Place // OBS! alla kommentarer finns i Stad.cs
    {
        char[,] fangelse; 

        
        public Fangelse() : base(10, 10)  
        {
            fangelse = new char[Rows, Cols];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    fangelse[i, j] = ' ';
                }
            }

        }

        public string visaFangelse() 
        {
            string toReturn = "";
    
            for (int i = 0; i < Cols - 3; i++)
            {
                if (i == 3)
                {
                    // Console.ForegroundColor = ConsoleColor.Red;
                    toReturn += "Prison";
                    // Console.ResetColor();
                }
                else
                {
                    toReturn += 'x';
                }
            }
            toReturn += "\n";

            for (int i = 0; i < Rows; i++)
            {
                toReturn += 'x';
                for (int j = 0; j < Cols; j++)
                {
                    toReturn += fangelse[i, j];
                }
                toReturn += 'x';
                toReturn += "\n";
            }
            for (int i = 0; i < Cols + 2; i++)
            {
                toReturn += 'x';
            }
            toReturn += "\n";
            return toReturn;
        }


    }
}



    
