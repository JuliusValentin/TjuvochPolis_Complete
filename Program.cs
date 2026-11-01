using System;
using System.Collections.Generic;
using System.Threading;

namespace TjuvochPolis
{
    internal class Program
    {
        static readonly int bredd = 100;
        static readonly int höjd = 25;
        static readonly List<Person> personer = new List<Person>();
        static readonly Random slump = new Random();
        static readonly Stad stad = new Stad();
        static readonly Fangelse fangelse = new Fangelse();
        static readonly Fattighus fattighus = new Fattighus();
        static readonly MyView myView = new MyView();

        static void Main(string[] args)
        {
            int nrOfCitizen = 20;
            for (int i = 1; i <= nrOfCitizen; i++)
            {
                int x = slump.Next(1, 99);
                int y = slump.Next(1, 24);
                Citizen citizen = new Citizen(x, y);
                personer.Add(citizen);
            }

            int nrOfThief = 10;
            for (int i = 1; i <= nrOfThief; i++)
            {
                int x = slump.Next(1, 99);
                int y = slump.Next(1, 24);
                Thief thief = new Thief(x, y);
                personer.Add(thief);
            }

            int nrOfPolice = 5;
            for (int i = 1; i <= nrOfPolice; i++)
            {
                int x = slump.Next(1, 99);
                int y = slump.Next(1, 24);
                Police police = new Police(x, y);
                personer.Add(police);
            }

            

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo tangent = Console.ReadKey(true);
                    int x = slump.Next(1, 99);
                    int y = slump.Next(1, 24);

                    if (tangent.Key == ConsoleKey.M)
                        personer.Add(new Citizen(x, y));
                    else if (tangent.Key == ConsoleKey.P)
                        personer.Add(new Police(x, y));
                    else if (tangent.Key == ConsoleKey.T)
                        personer.Add(new Thief(x, y));
                }

                SimuleraTur();
                ItemManager.CheckEncounters(personer);
                VisaStad();
                Thread.Sleep(300);
            }
        }

        static void SimuleraTur()
        {
            foreach (Person tjuv in personer)
            {
                if (tjuv.Typ != PersonTyp.Tjuv)
                    continue;

                Person? polis = HittaNärmaste(tjuv, PersonTyp.Polis);
                if (polis != null && Avstånd(tjuv, polis) <= 5)
                    tjuv.FlyttaBortFrån(polis, bredd, höjd);
                else
                    tjuv.SlumpmässigFörflyttning(bredd, höjd);
            }

            foreach (Person polis in personer)
            {
                if (polis.Typ != PersonTyp.Polis)
                    continue;

                Person? tjuv = HittaNärmaste(polis, PersonTyp.Tjuv);
                if (tjuv != null)
                    polis.FlyttaMot(tjuv, bredd, höjd);
                else
                    polis.SlumpmässigFörflyttning(bredd, höjd);
            }

            foreach (Person medborgare in personer)
            {
                if (medborgare.Typ == PersonTyp.Medborgare)
                    medborgare.SlumpmässigFörflyttning(bredd, höjd);
            }
        }
        static Person? HittaNärmaste(Person person, PersonTyp söktTyp)
        {
            Person? närmaste = null;
            double kortasteAvstånd = double.MaxValue;

            foreach (Person annan in personer)
            {
                if (annan.Typ != söktTyp)
                    continue;

                double avstånd = Avstånd(person, annan);

                if (avstånd < kortasteAvstånd)
                {
                    kortasteAvstånd = avstånd;
                    närmaste = annan;
                }
            }

            return närmaste;
        }
        static double Avstånd(Person a, Person b)
        {
            int dx = Math.Abs(a.X - b.X);
            int dy = Math.Abs(a.Y - b.Y);

            dx = Math.Min(dx, bredd - dx);
            dy = Math.Min(dy, höjd - dy);

            return Math.Sqrt(dx * dx + dy * dy);
        }


        static void VisaStad()
        {
            Console.SetCursorPosition(0, 0);
            stad.updateStad(personer);
            string stadString = stad.visaStad();
            string fangelseString = fangelse.visaFangelse();
            string fattighusString = fattighus.visaFattighus();

            myView.Render(stadString, fangelseString, fattighusString, personer);

        }


    }
}

