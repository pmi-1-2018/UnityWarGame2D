using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle
{
    public Sprite Sprite { get; set; }
    public bool IsTree { get; set; }
    public bool IsBuilding { get; set; }
    public Obstacle()
    {
        this.Sprite = null;
    }
    public void LogSpriteLoadState(Sprite sp)
    {
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

public class Tree : Obstacle
{
    private Sprite[] allSprites = Resources.LoadAll<Sprite>("Sprites/trees");
    public Tree()
    {
        this.Sprite = this.allSprites[Random.Range(0, this.allSprites.Length)];
        this.LogSpriteLoadState(this.Sprite);
    }
}

public class Building : Obstacle
{
    enum Buildings
    {
        SwordsMen = 0,
        Archer,
        Hydra,
    }
    private Sprite[] allSprites = Resources.LoadAll<Sprite>("Sprites/buildings");
    private int buildingType;
    public Building()
    {
        this.buildingType = Random.Range(0, 3);
        switch(buildingType)
        {
            case (int) Buildings.SwordsMen:
                this.Sprite = this.allSprites[this.buildingType];
                break;
            case (int)Buildings.Archer:
                this.Sprite = this.allSprites[this.buildingType];
                break;
            case (int)Buildings.Hydra:
                this.Sprite = this.allSprites[this.buildingType];
                break;
        }
        this.LogSpriteLoadState(this.Sprite);
    }
}

