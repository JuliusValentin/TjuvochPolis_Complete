using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvochPolis
{
    internal class MyView
    {
    
        // Here we will 'render' all the data 

        public void Render(String stad, String fattighus, String fangelse, List<Person> personer)
        {
            Console.Clear();
            Console.WriteLine(stad);
            Console.WriteLine(fattighus);
            Console.WriteLine(fangelse);
            int total = personer.Count(p => p.Typ == PersonTyp.Polis) + personer.Count(p => p.Typ == PersonTyp.Tjuv) + personer.Count(p => p.Typ == PersonTyp.Medborgare);
            Console.WriteLine("P = Polis | T = Tjuv | M = Medborgare | * = Flera på samma ruta");
            Console.WriteLine($"Polis:{personer.Count(p => p.Typ == PersonTyp.Polis)}\t Tjuvar:{personer.Count(p => p.Typ == PersonTyp.Tjuv)}\t Medborgare:{personer.Count(p => p.Typ == PersonTyp.Medborgare)}\t Totala personer:{total}");
            Console.WriteLine("Tryck Ctrl+C för att avsluta.");

        }
    }
}
