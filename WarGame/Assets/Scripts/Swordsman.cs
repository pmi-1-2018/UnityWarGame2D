using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman : Unit
{
    
    void Start()
    {
        health = 100;
        damage = 50;
    }

    public override void Attack(List<GameObject> targetArmy, int targetIndex)
    {
        targetArmy[targetIndex].GetComponentInChildren<Unit>().Health -= damage;
    }
}
