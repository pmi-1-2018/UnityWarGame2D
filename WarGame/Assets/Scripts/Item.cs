using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    //public bool pickedUp;

    public Item(int id, string itemType, string descr, Dictionary<string, int> stats)
    {
        this.ID = id;
        this.type = itemType;
        this.description = descr;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + type);
        this.stats = stats;
        //this.pickedUp = picked;
    }

    public Item(Item item)
    {
        this.ID = item.ID;
        this.type = item.type;
        this.description = item.description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + item.type);
        this.stats = item.stats;
        //this.pickedUp = item.pickedUp;
    }

}
