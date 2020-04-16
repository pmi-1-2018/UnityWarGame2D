using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    private GameObject opponent;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        opponent = collision.gameObject;
        GameObject manager = GameObject.Find("GameManager");
        manager.GetComponent<GameManager>().BeginBattle(gameObject, opponent);
    }
}
