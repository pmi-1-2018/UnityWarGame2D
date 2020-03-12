using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    private Transform pl;
    public int currentTurn;
    public Vector3 cameraPos;
    void Update()
    {
        //pl = getPlayer();
        transform.position = new Vector3(cameraPos.x + offset.x, cameraPos.y + offset.y, offset.z);
    }
    /*
    Transform getPlayer()
    {

        Transform player;
        player = GameObject.Find("PlayerParent").transform;
        return player;
    }
    */
}
