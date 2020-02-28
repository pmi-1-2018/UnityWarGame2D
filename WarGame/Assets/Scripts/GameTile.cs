using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName ="New AstarTile", menuName ="Tiles/AstarTile")]
public class GameTile : Tile
{
    public Sprite sprite;
    public int movePenalty = 1;
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    
   
}
