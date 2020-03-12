using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionWarriors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var list = GameObject.FindGameObjectsWithTag("unit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeployUnits(GameObject[] list)
    {
        for (int i = 1; i <= list.Length; i++)
        {
            list[i - 1].SetActive(true);
            list[i-1].transform.position = new Vector3(30 + 217 * i, 30 + 233 * i, 0);
        }
    }
}
