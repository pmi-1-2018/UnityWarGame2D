using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    private Transform pl;
    void Update()
    {
        pl = getPlayer();
        transform.position = new Vector3(pl.position.x + offset.x, pl.position.y + offset.y, offset.z);
    }
    Transform getPlayer()
    {
        Transform player;
        player = GameObject.Find("PlayerParent").transform;
        return player;
    }
}
