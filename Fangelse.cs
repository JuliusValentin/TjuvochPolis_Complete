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

        public void visaFangelse() 
        {
            for (int i = 0; i < Cols - 3; i++)
            {
                if (i == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Prison");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write('x');
                }
            }
            Console.WriteLine();

            for (int i = 0; i < Rows; i++)
            {
                Console.Write('x');
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(fangelse[i, j]);
                }
                Console.Write('x');
                Console.WriteLine();
            }
            for (int i = 0; i < Cols + 2; i++)
            {
                Console.Write('x');
            }
            Console.WriteLine();
        }


    }
}



    
