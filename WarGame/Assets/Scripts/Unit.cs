using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{

    protected double damage;
    protected double health;

    public double Damage { get => damage; }
    public double Health { get => health; set => health = value; }

    void Start()
    {

    }
    public abstract void Attack(GameObject target);
    // Update is called once per frame
    void Update()
    {
        
    }
}
