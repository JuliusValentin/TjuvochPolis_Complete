using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvochPolis
{
    internal partial class Person
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<Item> Inventory { get; set; }


        public Person(int x, int y)
        {
            X = x;
            Y = y;
            Inventory = new List<Item>();
        }
    }

    class Citizen : Person
    {
        public Citizen(int x, int y) : base(x, y)
        {
            Inventory = ItemManager.CitizenItems();
        }
    }

    class Thief : Person
    {
        public Thief(int x, int y) : base(x, y)
        {

        }
    }

    class Police : Person
    {
        public Police(int x, int y) : base(x, y)
        {

        }
    }



}