using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    private GameObject opponent;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        opponent = collision.gameObject;
        StartCoroutine(ChangeScene("BattleScene", opponent));
        PositionWarriors.PositionUnits(GetComponent<Army>().GetArmy, opponent.GetComponent<Army>().GetArmy, true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ReturnToMainScene();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && SceneManager.GetActiveScene().name == "BattleScene")
        {
            GameObject loser = gameObject;
            StartCoroutine(Fight(loser));
            if (loser == null)
            {
                GameObject.Destroy(gameObject);
                GameObject.Destroy(opponent);
            }
            else if (opponent == loser)
            {
                Debug.Log("winner: " + gameObject.name);
            }
            else
            {
                Debug.Log("winner: " + loser.name);
            }
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
    IEnumerator Fight(GameObject loser)
    {
        var attackingArmy = GetComponent<Army>().GetArmy;
        var defendingArmy = opponent.GetComponent<Army>().GetArmy;
        while (attackingArmy.Count > 0 && defendingArmy.Count > 0)
        {
            attackingArmy[0].GetComponentInChildren<Unit>().Attack(defendingArmy[0]);
            defendingArmy[0].GetComponentInChildren<Unit>().Attack(attackingArmy[0]);
            if (defendingArmy[0].GetComponentInChildren<Unit>().Health <= 0)
            {
                GameObject.Destroy(defendingArmy[0]);
                defendingArmy.RemoveAt(0);
            }
            if (attackingArmy[0].GetComponentInChildren<Unit>().Health <= 0)
            {
                GameObject.Destroy(attackingArmy[0]);
                attackingArmy.RemoveAt(0);
            }
            PositionWarriors.PositionUnits(GetComponent<Army>().GetArmy, opponent.GetComponent<Army>().GetArmy, false);
            yield return new WaitForSeconds(1);
        }
        if (attackingArmy.Count == 0 && defendingArmy.Count == 0)
        {
            loser = null;
        }
        if (defendingArmy.Count == 0)
        {
            loser = opponent;
        }
    }
    IEnumerator ChangeScene(string newSceneName, GameObject opponent)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newSceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetSceneByName(newSceneName));
        SceneManager.MoveGameObjectToScene(opponent, SceneManager.GetSceneByName(newSceneName));
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
