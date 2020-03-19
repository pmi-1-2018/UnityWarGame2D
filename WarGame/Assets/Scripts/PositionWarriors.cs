using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionWarriors : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PositionUnits(List<GameObject> armyAttacking, List<GameObject> armyDefending, bool enableRendering)
    {
        var maxCount = System.Math.Max(armyDefending.Count, armyAttacking.Count);
        for (int i = 0; i < maxCount; i++)
        {
            try
            {
                armyDefending[i].transform.position = new Vector3(10 + 4 * i, 0, 0);
                if (enableRendering)
                {
                    armyDefending[i].GetComponent<SpriteRenderer>().enabled = true;
                }
            }
            catch (System.Exception)
            {
            }
            try
            {
                armyAttacking[i].transform.position = new Vector3(-10 - 4 * i, 0, 0);
                if (enableRendering)
                {
                    armyAttacking[i].GetComponent<SpriteRenderer>().enabled = true;
                }
            }
            catch (System.Exception)
            {
            }
        }
    }
}
