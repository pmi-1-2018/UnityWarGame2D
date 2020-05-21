using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public int value;
    public ItemType itemType;
    public int amount;

    public int Value { get => value; }
    public ItemType Type { get => itemType; }

    public enum ItemType
    {
        Sword,
        HealthPotion,
        Coin,
        ManaPotion,
        Medkit,
    }

    public int GetValue()
    {
        switch (itemType){
            default:
            case ItemType.Sword:        return ItemAssets.Instance.swordValue;
            case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionValue;
            case ItemType.ManaPotion:   return ItemAssets.Instance.manaPotionValue;
            case ItemType.Coin:         return ItemAssets.Instance.coinValue;
            case ItemType.Medkit:       return ItemAssets.Instance.medkitValue;
        }
    }

    public Sprite GetSprite(){
        switch(itemType){
        default:
        case ItemType.Sword:        return ItemAssets.Instance.swordSprite;
        case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
        case ItemType.ManaPotion:   return ItemAssets.Instance.manaPotionSprite;
        case ItemType.Coin:         return ItemAssets.Instance.coinSprite;
        case ItemType.Medkit:       return ItemAssets.Instance.medkitSprite;
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Coin:
            case ItemType.HealthPotion:
            case ItemType.ManaPotion:
                return true;
            case ItemType.Sword:
            case ItemType.Medkit:
                return false;
        }
    }

    public void EnableBoost(List<GameObject> army)
    {
        foreach (GameObject unit in army)
        {
            unit.GetComponentInChildren<Unit>().Health += value;
        }
    }

}
