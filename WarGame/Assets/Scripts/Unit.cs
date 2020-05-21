using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{

    protected double damage;
    protected double health;
    protected Vector2 newPos;
    protected Vector2 startPos;
    protected float progress;

    public double Damage { get => damage; set => damage = value; }
    public double Health { get => health; set => health = value; }
    public Vector2 StartPos { set => startPos = value; }
    public Vector2 NewPos { set => newPos = value; }

    public void Move(float step)
    {
        transform.position = Vector2.Lerp(startPos, newPos, progress);
        progress += step;
        if (transform.position.x == newPos.x && transform.position.y == newPos.y)
        {
            progress = 0f;
            startPos = newPos;
            GetComponent<Animator>().SetInteger("speed", 0);
        }
    }

    public abstract void Attack(List<GameObject> targetArmy, int targetIndex);
    
}
