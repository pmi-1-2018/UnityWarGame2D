using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBuilder
{
    private Obstacle product;

    public void Reset()
    {
        this.product = null;
    }
    public void BuildTree()
    {
        this.product = new Tree();
        this.product.IsTree = true;
    }
    public void BuildHouse()
    {
        this.product = new Building();
        this.product.IsBuilding = true;
    }
    public Obstacle GetResult()
    {
        var prod = this.product;
        Reset();
        return prod;
    }
}
