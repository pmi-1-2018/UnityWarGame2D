using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public ItemType itemType;
    public int amount;

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

        switch (itemType)
        {
            default:
            case ItemType.Coin:
            case ItemType.ManaPotion:
                break;
            case ItemType.Sword:
                foreach (GameObject unit in army)
                {
                    unit.GetComponentInChildren<Unit>().Damage += GetValue();
                }
                break;
            case ItemType.HealthPotion:
            case ItemType.Medkit:
                foreach (GameObject unit in army)
                {
                    unit.GetComponentInChildren<Unit>().Health += GetValue();
                }
                break;
        }
            
        
    }
    public void DisableBoost(List<GameObject> army)
    {

        switch (itemType)
        {
            default:
            case ItemType.Coin:
            case ItemType.ManaPotion:
                break;
            case ItemType.Sword:
                foreach (GameObject unit in army)
                {

                    unit.GetComponentInChildren<Unit>().Damage -= GetValue();
                }
                break;
            case ItemType.HealthPotion:
            case ItemType.Medkit:
                foreach (GameObject unit in army)
                {
                    unit.GetComponentInChildren<Unit>().Health -= GetValue();

                    if (unit.GetComponentInChildren<Unit>().Health <= 0)
                    {
                        unit.GetComponentInChildren<Unit>().Health = 1;

                    }
                }
                break;
        }


    }

}
