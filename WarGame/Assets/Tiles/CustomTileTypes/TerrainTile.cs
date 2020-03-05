using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tiles/Terrain")]
public class TerrainTile : Tile {

    // method for rendering tile, all data returned via tileData
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        tileData.sprite = null;
        tileData.colliderType = Tile.ColliderType.Grid;
    }
}
