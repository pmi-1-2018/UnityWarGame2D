using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tiles/Terrain")]
public class TerrainTile : Tile
{
    public Sprite grassSprite;
    public Sprite treeSprite;
    [Range(0, 100)]
    public int treeIniChance;
    //public ObstacleBuilder obstacleBuilder;
    
    // method for rendering tile, all data returned via tileData
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        ObstacleBuilder obstacleBuilder = new ObstacleBuilder();
        Obstacle obstacle = new Obstacle();
        if (Random.Range(1, 101) < treeIniChance)
        {
            Debug.Log(111111111111111111);
            obstacleBuilder.BuildTree();
            obstacle = obstacleBuilder.GetResult();
        }
        tileData.sprite = obstacle.Sprite;
        tileData.colliderType = Tile.ColliderType.Sprite;
    }
}
