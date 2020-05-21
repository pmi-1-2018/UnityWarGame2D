using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class spawnBots : MonoBehaviour
{
    public GameObject enemy;
    public int numOfBots;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        GameObject parent = GameObject.Find("bots");
        System.Random rnd = new System.Random();
        for (int i = 0; i < numOfBots; i++)
        {
            enemy.tag = "Player";
            double randomNumberX = rnd.Next(-57, 57) * 3 + 1.5;
            double randomNumberY = rnd.Next(-33, 33) * 3 + 1.5;
            var newEnemy = Instantiate(enemy, new Vector3((float)randomNumberX, (float)randomNumberY, 0), Quaternion.identity);
            newEnemy.transform.parent = parent.transform;
            sprite = newEnemy.GetComponent<SpriteRenderer>();
            sprite.sortingOrder = 6;
            

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
