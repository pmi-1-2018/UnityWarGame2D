using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GotoBattleScene();
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BeginBattle();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ReturnToMainScene();
        }
    }
    void ReturnToMainScene()
    {
        
        gameObject.SetActive(true);
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
        gameObject.SetActive(false);
        SceneManager.LoadScene("BattleScene");
    }
}
