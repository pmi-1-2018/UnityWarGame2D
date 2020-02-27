using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BeginBattle();
        }
        if (Input.GetKeyDown(KeyCode.F) && SceneManager.GetActiveScene().ToString() != "SampleScene")
        {
            ReturnToMainScene();
        }
    }
    void ReturnToMainScene()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("SampleScene");
    }
    void BeginBattle()
    {
        GotoBattleScene();
        Fight();
    }
    void Fight()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
    }
    void GotoBattleScene()
    {
        DontDestroyOnLoad(gameObject);
       
        SceneManager.LoadScene("BattleScene");
    }
}
