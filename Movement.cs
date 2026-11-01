using System;
using System.Collections.Generic;
using System.Threading;

namespace TjuvochPolis
{
    enum Riktning
    {
        Höger,
        NedreHöger,
        Ner,
        NedreVänster,
        Vänster,
        ÖvreVänster,
        Upp,
        ÖvreHöger
    }

    enum PersonTyp
    {
        Polis,
        Tjuv,
        Medborgare
    }

    internal partial class Person
    {
        public string Namn { get; set; }
        public PersonTyp Typ
        {
            get
            {
                if (this is Police) return PersonTyp.Polis;
                if (this is Thief) return PersonTyp.Tjuv;
                return PersonTyp.Medborgare;
            }
        }

        private static readonly Random slump = new Random();

        public void Flytta(Riktning riktning, int bredd, int höjd)
        {
            switch (riktning)
            {
                case Riktning.Höger: X++; break;
                case Riktning.NedreHöger: X++; Y++; break;
                case Riktning.Ner: Y++; break;
                case Riktning.NedreVänster: X--; Y++; break;
                case Riktning.Vänster: X--; break;
                case Riktning.ÖvreVänster: X--; Y--; break;
                case Riktning.Upp: Y--; break;
                case Riktning.ÖvreHöger: X++; Y--; break;
            }

            X = (X + bredd) % bredd;
            Y = (Y + höjd) % höjd;
        }

        public void SlumpmässigFörflyttning(int bredd, int höjd)
        {
            Flytta((Riktning)slump.Next(0, 8), bredd, höjd);
        }

        public void FlyttaMot(Person mål, int bredd, int höjd)
        {
            int dx = mål.X - X;
            int dy = mål.Y - Y;

            if (dx > bredd / 2) dx -= bredd;
            else if (dx < -bredd / 2) dx += bredd;

            if (dy > höjd / 2) dy -= höjd;
            else if (dy < -höjd / 2) dy += höjd;

            Flytta(BestämRiktning(Math.Sign(dx), Math.Sign(dy)),
                bredd, höjd);
        }

        public void FlyttaBortFrån(Person hot, int bredd, int höjd)
        {
            int dx = X - hot.X;
            int dy = Y - hot.Y;

            if (dx > bredd / 2) dx -= bredd;
            else if (dx < -bredd / 2) dx += bredd;

            if (dy > höjd / 2) dy -= höjd;
            else if (dy < -höjd / 2) dy += höjd;

            dx = Math.Sign(dx);
            dy = Math.Sign(dy);

            if (dx == 0 && dy == 0)
            {
                SlumpmässigFörflyttning(bredd, höjd);
                return;
            }

            Flytta(BestämRiktning(dx, dy), bredd, höjd);
        }

        private Riktning BestämRiktning(int dx, int dy)
        {
            if (dx > 0 && dy == 0) return Riktning.Höger;
            if (dx > 0 && dy > 0) return Riktning.NedreHöger;
            if (dx == 0 && dy > 0) return Riktning.Ner;
            if (dx < 0 && dy > 0) return Riktning.NedreVänster;
            if (dx < 0 && dy == 0) return Riktning.Vänster;
            if (dx < 0 && dy < 0) return Riktning.ÖvreVänster;
            if (dx == 0 && dy < 0) return Riktning.Upp;
            if (dx > 0 && dy < 0) return Riktning.ÖvreHöger;

            return (Riktning)slump.Next(0, 8);
        }

        public char HämtaSymbol()
        {
            switch (Typ)
            {
                case PersonTyp.Polis: return 'P';
                case PersonTyp.Tjuv: return 'T';
                default: return 'M';
            }
        }
    }
}

