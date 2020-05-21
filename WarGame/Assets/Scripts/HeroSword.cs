using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSword : Artifact
{
    void Start()
    {
        value = 50;
        type = ArtifactType.fightArt;
    }

    public override void EnableBoost(List<GameObject> army)
    {
        foreach (GameObject unit in army)
        {
            unit.GetComponentInChildren<Unit>().Damage += value;
        }
    }

    public override void DisableBoost(List<GameObject> army)
    {
        foreach (GameObject unit in army)
        {
            unit.GetComponentInChildren<Unit>().Damage -= value;
        }
    }
}
