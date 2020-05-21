using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionWarriors : MonoBehaviour
{
    public static void PositionUnits(List<GameObject> armyAttacking, List<GameObject> armyDefending, bool enableRendering)
    {
        var maxCount = System.Math.Max(armyDefending.Count, armyAttacking.Count);
        for (int i = 0; i < maxCount; i++)
        {
            try
            {
                if (enableRendering)
                {
                    armyDefending[i].transform.position = new Vector3(5 + 4 * i, 0, 0);
                    armyDefending[i].GetComponent<SpriteRenderer>().enabled = true;
                    armyDefending[i].GetComponent<Animator>().enabled = true;
                    armyDefending[i].GetComponentInChildren<Unit>().StartPos = armyDefending[i].transform.position;
                    armyDefending[i].GetComponentInChildren<Unit>().NewPos = armyDefending[i].transform.position;
                    armyDefending[i].GetComponent<Animator>().SetInteger("speed", -1);
                }
                else
                {
                    Vector3 newPosition = new Vector3(5 + 4 * i, 0, 0);
                    if (armyDefending[i].transform.position != newPosition)
                    {
                        armyDefending[i].GetComponentInChildren<Unit>().NewPos = newPosition;
                        armyDefending[i].GetComponent<Animator>().SetInteger("speed", -1);
                    }
                }
            }
            catch (System.Exception)
            {
            }
            try
            {
                if (enableRendering)
                {
                    armyAttacking[i].transform.position = new Vector3(-5 - 4 * i, 0, 0);
                    armyAttacking[i].GetComponent<SpriteRenderer>().enabled = true;
                    armyAttacking[i].GetComponent<Animator>().enabled = true;
                    armyAttacking[i].GetComponentInChildren<Unit>().StartPos = armyAttacking[i].transform.position;
                    armyAttacking[i].GetComponentInChildren<Unit>().NewPos = armyAttacking[i].transform.position;
                    armyAttacking[i].GetComponent<Animator>().SetInteger("speed", 1);
                }
                else
                {
                    Vector3 newPosition = new Vector3(-5 - 4 * i, 0, 0);
                    if(armyAttacking[i].transform.position != newPosition)
                    {
                        armyAttacking[i].GetComponentInChildren<Unit>().NewPos = newPosition;
                        armyAttacking[i].GetComponent<Animator>().SetInteger("speed", 1);
                    }
                }
            }
            catch (System.Exception)
            {
            }
        }
    }
    public static void EnableAttackAnim(List<GameObject> armyAttacking, List<GameObject> armyDefending, bool even)
    {
        if(even)
        {
            armyAttacking[0].GetComponent<Animator>().SetInteger("attack", 1);
            armyDefending[0].GetComponent<Animator>().SetInteger("attack", -1);
        }
        else
        {
            armyAttacking[0].GetComponent<Animator>().SetInteger("attack", -1);
            armyDefending[0].GetComponent<Animator>().SetInteger("attack", 1);
        }
    }
    public static void DisableAttackAnim(List<GameObject> army)
    {
        army[0].GetComponent<Animator>().SetInteger("attack", 10);
    }
}
