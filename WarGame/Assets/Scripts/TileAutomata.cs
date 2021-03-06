﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TileAutomata : MonoBehaviour {


    [Range(0,100)]
    public int iniChance;
    [Range(1,8)]
    public int birthLimit;
    [Range(1,8)]
    public int deathLimit;

    [Range(1,10)]
    public int numR;
    private int count = 0;

    private int[,] terrainMap;
    public Vector3Int tmpSize;
    public Tilemap topMap;
    public Tilemap botMap;
    public Tile botTile;

    [Range(0, 101)]
    public int treeIniChance;
    [Range(0, 101)]
    public int buildingIniChance;

    int width;
    int height;

    public void doSim(int nu)
    {
        clearMap(false);
        width = tmpSize.x;
        height = tmpSize.y;

        if (terrainMap==null)
        {
            terrainMap = new int[width, height];
            initPos();
        }


        for (int i = 0; i < nu; i++)
        {
            terrainMap = genTilePos(terrainMap);
        }
        //GameTile topT = (GameTile)ScriptableObject.CreateInstance(typeof(GameTile));
        //GameTile botT = (GameTile)ScriptableObject.CreateInstance(typeof(GameTile));
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                if (terrainMap[x, y] == 1)
                {
                    TerrainTile topTile = new TerrainTile(treeIniChance, buildingIniChance);
                    var ground = new Tile();
                    ground.sprite = topTile.GrassSprite;
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), ground);
                    topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile);
                }
                else
                {
                    botMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), botTile);
                }
            }
        }
    }

    public void initPos()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                terrainMap[x, y] = Random.Range(1, 101) < iniChance ? 1 : 0;
            }
        }

    }


    public int[,] genTilePos(int[,] oldMap)
    {
        int[,] newMap = new int[width,height];
        int neighb;
        BoundsInt myB = new BoundsInt(-1, -1, 0, 3, 3, 1);


        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                neighb = 0;
                foreach (var b in myB.allPositionsWithin)
                {
                    if (b.x == 0 && b.y == 0) continue;
                    if (x+b.x >= 0 && x+b.x < width && y+b.y >= 0 && y+b.y < height)
                    {
                        neighb += oldMap[x + b.x, y + b.y];
                    }
                    else
                    {
                        neighb++;
                    }
                }

                if (oldMap[x,y] == 1)
                {
                    if (neighb < deathLimit) newMap[x, y] = 0;
                    else
                    {
                        newMap[x, y] = 1;

                    }
                }

                if (oldMap[x,y] == 0)
                {
                    if (neighb > birthLimit) newMap[x, y] = 1;
                else
                {
                    newMap[x, y] = 0;
                }
                }

            }

        }



        return newMap;
    }

    private void Start()
    {
        doSim(numR);
    }
    void Update () {

        if (Input.GetKey(KeyCode.P))
        {
            SaveAssetMap();
            count++;
        }
    }


    public void SaveAssetMap()
    {
        string saveName = "tmapXY_" + count;
        var mf = GameObject.Find("Grid");

        if (mf)
        {
            var savePath = "Assets/" + saveName + ".prefab";
            if (PrefabUtility.CreatePrefab(savePath, mf))
            {
                EditorUtility.DisplayDialog("Tilemap saved", "Your Tilemap was saved under" + savePath, "Continue");
            }
            else
            {
                EditorUtility.DisplayDialog("Tilemap NOT saved", "An ERROR occured while trying to saveTilemap under" + savePath, "Continue");
            }

        }
    }

    public void clearMap(bool complete)
    {

        topMap.ClearAllTiles();
        botMap.ClearAllTiles();
        if (complete)
        {
            terrainMap = null;
        }


    }



}
