using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum TileType {START, GOAL, GROUND, WATER}

public class Astar : MonoBehaviour
{
    private TileType tileType;

    [SerializeField]
    private Tile[] tiles;

    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private Camera camera;

    [SerializeField]
    private LayerMask layerMask;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(camera.WorldToScreenPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity,layerMask);
            if(hit.collider != null)
            {
                Vector3 mouseWorldPos = camera.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int clickPos = tilemap.WorldToCell(mouseWorldPos);
                ChangeTile(clickPos);
            }
        }
    }

    //Create an instance of GameTile class
    // 9 min of that video.
    private void ChangeTile(Vector3Int clickPos)
    {
        tilemap.SetTile(clickPos, tiles[0]);
    }
}
