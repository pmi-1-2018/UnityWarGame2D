using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Battle : MonoBehaviour
{
    public Tilemap map;
    public int sizeX;
    public int sizeY;
    public Sprite cellSprite;


    // Start is called before the first frame update
    void Start()
    {
        CreateBattleField();
    }
    
    void CreateBattleField()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                Vector3Int tileCoords = new Vector3Int(j, i, 0);
                GameTile tile = (GameTile)ScriptableObject.CreateInstance(typeof(GameTile));
                tile.sprite = cellSprite;
                map.SetTile(tileCoords, tile);
            }
        }
    }
}
