using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGeneration : MonoBehaviour
{
    public GameObject player;
    public GameObject tileAutomata;
    public Grid grid;
    public Tilemap top;
    public Tilemap bot;

    void Start()
    {
        if (GameObject.Find("PlayerParent") == null)
        {
            SpawnPlayers();
        }
    }
    
    void SpawnPlayers()
    {
        Vector3 spawnVector1 = new Vector3(-175.5f, -100.5f, 0);
        var res = Instantiate(player, spawnVector1, Quaternion.identity);
        res.name = "PlayerParent";
        res.GetComponent<PlayerMovement>().grid = grid;
        res.GetComponent<PlayerMovement>().top = top;
        res.GetComponent<PlayerMovement>().bot = bot;

    }
}
