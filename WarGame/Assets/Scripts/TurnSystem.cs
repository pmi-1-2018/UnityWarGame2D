using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public Button TurnPass;
    private int turnCounter = 0;
    public GameObject player1;
    public GameObject player2;
    public CameraFollow cam;
    void Start()
    {
        player2.GetComponent<Player>().stamina = 0;
        TurnPass.onClick.AddListener(NextTurn);
    }
    private void Update()
    {
        if (turnCounter % 2 != 1)
        {
            cam.cameraPos = player1.transform.position;
        }
        else
        {
            cam.cameraPos = player2.transform.position;
        }
    }
    void NextTurn()
    {
        if(turnCounter % 2 != 0)
        {
            player1.GetComponent<Player>().stamina = 10;
            player2.GetComponent<Player>().stamina = 0;
        }
        else
        {
            player2.GetComponent<Player>().stamina = 10;
            player1.GetComponent<Player>().stamina = 0;
        }

        turnCounter += 1;
        Debug.Log("Next Turn");
        Debug.Log(turnCounter);
    }
}
