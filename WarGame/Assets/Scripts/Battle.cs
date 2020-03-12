using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ChangeScene("BattleScene"));
        Fight();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ReturnToMainScene();
        }
    }
    void ReturnToMainScene()
    {
        foreach (var unit in GetComponent<Army>().GetArmy)
        {
            unit.GetComponent<SpriteRenderer>().enabled = false;
        }
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
    }
    void Fight()
    {
        foreach(var unit in GetComponent<Army>().GetArmy)
        {
            unit.GetComponent<SpriteRenderer>().enabled = true;
        }
        
    }
    IEnumerator ChangeScene(string newSceneName)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newSceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName(newSceneName));
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
