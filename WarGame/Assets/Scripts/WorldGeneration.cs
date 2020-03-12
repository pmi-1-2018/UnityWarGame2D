using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGeneration : MonoBehaviour
{
    public GameObject player;
    public GameObject tileAutomata;

    void Start()
    {
        //SpawnPlayer();
    }
    
    void SpawnPlayer()
    {
        //Vector3 spawnVector = tileAutomata.GetComponent<Camera>().transform.position;
        //Instantiate(player, spawnVector, Quaternion.identity);
    }
}
