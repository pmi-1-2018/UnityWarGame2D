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
    public Tree()
    {
        this.Sprite = Resources.Load<Sprite>("Grass");
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
