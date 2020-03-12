using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ChangeScene("BattleScene"));
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
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
        
    }
    void Fight()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
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
