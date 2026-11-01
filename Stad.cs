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

        public string visaStad()
        {

            string toReturn = "";

            for (int i
                = 0; i < 99; i++)
            {
                if (i == 2)
                {

                    // Console.ForegroundColor = ConsoleColor.Green;
                    toReturn += "City";
                    // Console.ResetColor();
                }
                else
                {
                    toReturn += '*';
                }
            }
            toReturn += "\n";

            for (int i = 0; i < 25; i++)
            {
                toReturn += '*';
                for (int j = 0; j < 100; j++)
                {
                    toReturn += stad[i, j];
                }
                toReturn += '*';
                toReturn += "\n";
            }
            for (int i = 0; i < 102; i++)
            {
                toReturn += '*';
            }
            toReturn += "\n";
            return toReturn;
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
