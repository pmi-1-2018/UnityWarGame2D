using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGeneration : MonoBehaviour
{
    // Start is called before the first frame update

    public Tilemap map;
    public Tile tile;
    public int endX;
    public int endY;
    public Sprite one;
    public Sprite two;
    public GameObject player1;

    void Start()
    {
        SpawnMap();
        SpawnPlayer();
    }

    void SpawnMap()
    {
        for (int i = 0; i < endX; i++)
        {
            for (int j = 0; j < endY; j++)
            {
                Vector3Int v = new Vector3Int(i, j, 0);
                GameTile o = (GameTile)ScriptableObject.CreateInstance(typeof(GameTile));
                if (Random.Range(0, 101) > 50)
                {
                    o.sprite = one;
                }
                else
                {
                    o.sprite = two;
                }
                map.SetTile(v, o);
                Debug.Log(o);
            }
        }
    }
    void SpawnPlayer()
    {
        System.Random rnd = new System.Random();
        double randomNumberX = rnd.Next(1, endX) * 3 +1.5;
        double randomNumberY = rnd.Next(1, endY) * 3 + 1.5;
        Vector3 spawnVector = new Vector3((float)randomNumberX,(float)randomNumberY);
        Instantiate(player1, spawnVector, Quaternion.identity);
        //player.GetComponent<PlayerMovement>().map = map;

        //playerMovementScript.map = map;
    }
}
