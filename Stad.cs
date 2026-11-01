using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvochPolis
{
    internal class Stad
    {
        char[,] stad = new char[25, 100];// Stad diameter

        public Stad() // Constructor for filling every place in Stad 
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    stad[i, j] = ' ';
                }
            }

        }

        public void visaStad()
        {
            for (int i = 0; i < 99; i++)
            {
                if (i == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("City");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write('*');
                }
            }
            Console.WriteLine();

            for (int i = 0; i < 25; i++)
            {
                Console.Write('*');
                for (int j = 0; j < 100; j++)
                {
                    Console.Write(stad[i, j]);
                }
                Console.Write('*');
                Console.WriteLine();
            }
            for (int i = 0; i < 102; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
        }


        

        public void updateStad(List<Person> personer)
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    stad[i, j] = ' ';
                }
            }

            foreach (Person person in personer)
            {
                stad[person.Y, person.X] = person.HämtaSymbol();
            }
        }
    }
}
