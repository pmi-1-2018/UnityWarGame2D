using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{

    protected double damage;
    protected double health;

    public double Damage { get => damage; set => damage = value; }
    public double Health { get => health; set => health = value; }

    public abstract void Attack(GameObject target);
    
}
