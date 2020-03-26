using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle
{
    public Sprite Sprite { get; set; }
    public bool IsTree { get; set; }
    public Obstacle()
    {
        this.Sprite = null;
    }
}
public class Tree : Obstacle
{
    private Sprite[] allSprites = Resources.LoadAll<Sprite>("Sprites/trees");
    public Tree()
    {

        this.Sprite = this.allSprites[Random.Range(0, this.allSprites.Length)];
        if (this.Sprite != null)
        {
            Debug.Log("Obstacle loaded");
        }
        else
        {
            Debug.Log("Missing image file");
        }
    }
}
