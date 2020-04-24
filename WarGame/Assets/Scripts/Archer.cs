﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Unit
{
    private double rangedDamage = 100;

    void Start()
    {
        health = 50;
        damage = 25;
    }

    public override void Attack(GameObject target)
    {
        target.GetComponentInChildren<Unit>().Health -= damage;
    }

    private void AttackRanged(GameObject target)
    {
        target.GetComponentInChildren<Unit>().Health -= rangedDamage;
    }

    public static void ManageArchersRangedAttack(List<GameObject> attackingArmy, List<GameObject> defendingArmy)
    {
        if(attackingArmy.Count >= 2 && attackingArmy[1].GetComponent<Archer>() != null)
        {
            attackingArmy[1].GetComponent<Archer>().AttackRanged(defendingArmy[0]);
        }
    }
}