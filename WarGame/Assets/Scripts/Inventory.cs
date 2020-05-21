using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour, IList<Item>
{
    public event EventHandler OnItemListChanged;
    private List<Item> itemList;
    private Action<Item> useItemAction;


    private bool InventoryEnabled;
    public GameObject inv;
    public Button TurnPass;
    private bool checkButtonIsPresses;

    public List<Item> ItemList { get => itemList; }

    void Start()
    {
        TurnPass.onClick.AddListener(NextTurn);
    }

    public Inventory()
    {
        itemList = new List<Item>();
    }

    void Update()
    {
        if (checkButtonIsPresses == false)
        {
            if (Input.GetKeyDown(KeyCode.I) && gameObject.name == "PlayerParent")
            {
                InventoryEnabled = !InventoryEnabled;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.I) && gameObject.name == "pidar")
            {
                InventoryEnabled = !InventoryEnabled;
            }
        }

        if (InventoryEnabled == true)
        {
            inv.SetActive(true);
        }
        else
        {
            inv.SetActive(false);
        }
    }

    public void NextTurn()
    {
        Debug.Log("PLAYER IS CHANGED!");
        checkButtonIsPresses = !checkButtonIsPresses;
    }

    public Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();

        //AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
    }

    public void AddItem(Item item)
    {
        if (itemList.Count != 8)
        {
            if (item.IsStackable())
            {
                bool itemAlreadyInInventory = false;
                foreach (Item inventoryItem in itemList)
                {
                    if (inventoryItem.itemType == item.itemType)
                    {
                        inventoryItem.amount += item.amount;
                        itemAlreadyInInventory = true;
                    }
                }
                if (!itemAlreadyInInventory)
                {
                    itemList.Add(item);
                }
            }
            else //to add all items
            {
                itemList.Add(item);
            }
        }
        //else //to add only one item and ignore another
        //{
        //    bool itemAlreadyInInventory2 = false;

        //    foreach (Item inventoryItem in itemList)
        //    {
        //        if (inventoryItem.itemType == item.itemType)
        //        {
        //            itemAlreadyInInventory2 = true;
        //        }
        //    }
        //    if (!itemAlreadyInInventory2)
        //    {
        //        itemList.Add(item);
        //    }
        //}

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }


    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(itemInInventory);
            }
        }
        else 
        {
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(Item item)
    {
        useItemAction(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    public Item this[int index]
    {
        get
        {
            if (index >= 0 && index < itemList.Count)
            {
                return itemList[index];
            }
            else
            {
                Debug.Log("WRONG INDEX IN ARTIFACTS BAG");
                return null;
            }
        }
        set
        {
            if (index >= 0 && index < itemList.Count && !Contains(value))
            {
                itemList[index] = value;
            }
            else
            {
                Debug.Log($"WRONG INDEX IN ARTIFACTS BAG OR ALREADY CONTAINS: {value.itemType}");
            }
        }
    }

    public int Count => itemList.Count;

    public bool IsReadOnly => false;

    public void Add(Item item)
    {
        if (!Contains(item))
        {
            itemList.Add(item);
        }
        else
        {
            Debug.Log($"ALREADY CONTAINS THIS ITEM: {item.itemType}");
        }
    }

    public void Clear()
    {
        itemList.Clear();
    }

    public bool Contains(Item item)
    {
        return itemList.Contains(item);
    }

    public void CopyTo(Item[] array, int arrayIndex)
    {
        itemList.CopyTo(array, arrayIndex);
    }

    public IEnumerator<Item> GetEnumerator()
    {
        return itemList.GetEnumerator();
    }

    public int IndexOf(Item item)
    {
        return itemList.IndexOf(item);
    }

    public void Insert(int index, Item item)
    {
        if (!Contains(item))
        {
            itemList.Insert(index, item);
        }
        else
        {
            Debug.Log($"ALREADY CONTAINS THIS ITEM: {item.itemType}");
        }
    }

    public bool Remove(Item item)
    {
        return itemList.Remove(item);
    }

    public void RemoveAt(int index)
    {
        itemList.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return itemList.GetEnumerator();
    }

}
