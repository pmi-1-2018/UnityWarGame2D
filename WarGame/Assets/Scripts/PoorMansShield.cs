using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoorMansShield : Artifact
{
    private void Start()
    {
        value = 2000;
        type = ArtifactType.fightArt;
    }

    public override void EnableBoost(List<GameObject> army)
    {
        foreach (GameObject unit in army)
        {
            unit.GetComponentInChildren<Unit>().Health += value;
        }
    }

    public override void DisableBoost(List<GameObject> army)
    {
        foreach (GameObject unit in army)
        {
            unit.GetComponentInChildren<Unit>().Health -= value;
        }
    }
}
