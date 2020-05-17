using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Unit
{
    private double rangedDamage;

    private void Update()
    {
        Move(0.03f);
    }

    void Move(float step)
    {
        transform.position = Vector2.Lerp(startPos, newPos, progress);
        progress += step;
        if(transform.position.x == newPos.x && transform.position.y == newPos.y)
        {
            progress = 0f;
            startPos = newPos;
            GetComponent<Animator>().SetInteger("speed", 0);
        }
    }

    void Flip()
    {
        GetComponent<SpriteRenderer>().flipX = GetComponent<SpriteRenderer>().flipX == true ? false : true;
    }

    void Start()
    {
        rangedDamage = 100;
        health = 50;
        damage = 25;
    }

    public override void Attack(List<GameObject> targetArmy, int targetIndex)
    {
        targetArmy[targetIndex].GetComponentInChildren<Unit>().Health -= damage;
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
