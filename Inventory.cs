using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvochPolis
{
    // en sak som personen har
    public class Item
    {
        public string Name { get; set; }

        public Item(string name)
        {
            Name = name;
        }
    }

    internal class ItemManager
    {
        private static Random random = new Random();

        // medborgarens saker
        public static List<Item> CitizenItems()
        {
            List<Item> items = new List<Item>();

            items.Add(new Item("Nycklar"));
            items.Add(new Item("Mobiltelefon"));
            items.Add(new Item("Pengar"));
            items.Add(new Item("Klocka"));

            return items;
        }

        // tjuven tar en random sak från medborgaren
        // kolla att medborgaren har saker innan
        public static Item StealItem(Person citizen, Person thief)
        {
            int index = random.Next(0, citizen.Inventory.Count);
            Item stolenItem = citizen.Inventory[index];

            citizen.Inventory.RemoveAt(index);
            thief.Inventory.Add(stolenItem);

            return stolenItem;
        }

        // polisen tar alla saker från tjuven
        public static int SeizeItems(Person thief, Person police)
        {
            int count = thief.Inventory.Count;

            police.Inventory.AddRange(thief.Inventory);
            thief.Inventory = new List<Item>();

            return count;
        }

        // Kontrollerar om personer möts på samma position
        public static void CheckEncounters(List<Person> personer)
        {
            foreach (Person person in personer)
            {
                if (person.Typ == PersonTyp.Tjuv)
                {
                    foreach (Person annan in personer)
                    {
                        if (person == annan)
                            continue;

                        if (person.X == annan.X && person.Y == annan.Y)
                        {
                            // Tjuven möter en medborgare
                            if (annan.Typ == PersonTyp.Medborgare &&
                                annan.Inventory.Count > 0)
                            {
                                StealItem(annan, person);
                            }

                            // Tjuven möter en polis
                            else if (annan.Typ == PersonTyp.Polis &&
                                     person.Inventory.Count > 0)
                            {
                                SeizeItems(person, annan);
                            }
                        }
                    }
                }
            }
        }
    }
}