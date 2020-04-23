using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydra : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        health = 200;
        damage = 50;
    }

    // Update is called once per frame
    public override void Attack(List<GameObject> targetArmy, int targetIndex)
    {
        targetArmy[targetIndex].GetComponentInChildren<Unit>().Health -= damage;
        if(targetArmy.Count > 1)
        {
            targetArmy[targetIndex + 1].GetComponentInChildren<Unit>().Health -= damage;
        }
    }
}
