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

    public override void Attack(GameObject target)
    {
        target.GetComponentInChildren<Unit>().Health -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
