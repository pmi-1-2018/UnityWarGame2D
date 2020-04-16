using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArtifactType
{
    fightArt,
    heroArt
}

public abstract class Artifact : MonoBehaviour
{
    protected int value;
    protected ArtifactType type;

    public int Value { get => value; }
    public ArtifactType Type { get => type; }

    public abstract void EnableBoost(List<GameObject> army);
    public abstract void DisableBoost(List<GameObject> army);
}
