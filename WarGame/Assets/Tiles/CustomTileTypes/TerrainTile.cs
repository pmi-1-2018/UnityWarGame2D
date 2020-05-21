using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tiles/Terrain")]
public class TerrainTile : Tile
{
    private Sprite grassSprite;
    [Range(0, 100)]
    private int treeIniChance;
    private int buildingIniChance;
    private ObstacleBuilder obstacleBuilder;
    private Obstacle obj;

    public Sprite GrassSprite { get => grassSprite; }
    public Obstacle Obj { get => obj; }

    public TerrainTile(int treeIniChance, int buildingIniChance)
    {
        this.treeIniChance = treeIniChance;
        this.buildingIniChance = buildingIniChance;
        grassSprite = Resources.LoadAll<Sprite>("Sprites/Grass")[0];
        obstacleBuilder = new ObstacleBuilder();
    }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        if (Random.Range(1, 101) < treeIniChance)
        {
            obstacleBuilder.BuildTree();
            obj = obstacleBuilder.GetResult();
            tileData.sprite = obj.Sprite;
        }
        else if (Random.Range(1, 101) < buildingIniChance)
        {
            obstacleBuilder.BuildHouse();
            obj = obstacleBuilder.GetResult();
            tileData.sprite = obj.Sprite;
        }
        else
        {
            tileData.sprite = grassSprite;
            obj = null;
        }
        tileData.colliderType = Tile.ColliderType.Sprite;
    }
}
