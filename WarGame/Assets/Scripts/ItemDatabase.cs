using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void BuildDatabase()
    {
        items = new List<Item>() {
            new Item(0, "Weapon", "Simple axe used as a weapon.",
            new Dictionary<string, int>
            {
                {"Power", 10},
                {"Defence", 10 }
            }),
            new Item(1, "Values", "A beautiful diamond.",
            new Dictionary<string, int>
            {
                {"Value", 400},
            }),
            new Item(2, "Values", "Gold.",
            new Dictionary<string, int>
            {
                {"Value", 200},
            }),
            new Item(3, "Weapon", "A diamond sword.",
            new Dictionary<string, int>
            {
                {"Power", 15},
                {"Defence", 12 }
            }),
            new Item(4, "Weapon", "A silver sword.",
            new Dictionary<string, int>
            {
                {"Power", 10},
                {"Defence", 8 }
            }),
            new Item(5, "Weapon", "A gold sword.",
            new Dictionary<string, int>
            {
                {"Power", 12},
                {"Defence", 10 }
            }),
            new Item(6, "Values", "Iron.",
            new Dictionary<string, int>
            {
                {"Value", 50},
            }),
            new Item(7, "Weapon", "Magic Oil",
            new Dictionary<string, int>
            {
                {"Defence", 50 }
            }),
            new Item(8, "Weapon", "Shield",
            new Dictionary<string, int>
            {
                {"Defence", 50 }
            }),
            new Item(9, "Weapon", "Hammer",
            new Dictionary<string, int>
            {
                {"Power", 7},
                {"Defence", 5 }
            })
            };
    }
}
