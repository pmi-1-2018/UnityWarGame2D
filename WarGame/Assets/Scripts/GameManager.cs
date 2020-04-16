using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject mainCameraRef;
    private GameObject tileAutomataRef;
    private GameObject gridRef;
    private GameObject canvasRef;

    public void BeginBattle(GameObject attackingPlayer, GameObject opponent)
    {
        StartCoroutine(LoadBattleScene(attackingPlayer, opponent));
    }

    void Update()
    {
    }

    IEnumerator LoadBattleScene(GameObject attackingPlayer, GameObject opponent)
    {
        mainCameraRef = GameObject.Find("Main Camera");
        tileAutomataRef = GameObject.Find("TileAutomata");
        gridRef = GameObject.Find("Grid");
        canvasRef = GameObject.Find("Canvas");
        mainCameraRef.SetActive(false);
        tileAutomataRef.SetActive(false);
        gridRef.SetActive(false);
        canvasRef.SetActive(false);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BattleScene", LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(attackingPlayer, SceneManager.GetSceneByName("BattleScene"));
        SceneManager.MoveGameObjectToScene(opponent, SceneManager.GetSceneByName("BattleScene"));
        PositionWarriors.PositionUnits(attackingPlayer.GetComponent<Army>().GetArmy, opponent.GetComponent<Army>().GetArmy, true);
        StartCoroutine(Fight(attackingPlayer, opponent));
    }
    IEnumerator Fight(GameObject attackingPlayer, GameObject opponent)
    {
        var attackingArmy = attackingPlayer.GetComponent<Army>().GetArmy;
        var defendingArmy = opponent.GetComponent<Army>().GetArmy;
        foreach (GameObject art in attackingPlayer.GetComponent<Army>().GetArtifacts)
        {
            var artComp = art.GetComponentInChildren<Artifact>();
            if (artComp.Type == ArtifactType.fightArt)
            {
                artComp.EnableBoost(attackingArmy);
            }
        }
        foreach (GameObject art in opponent.GetComponent<Army>().GetArtifacts)
        {
            var artComp = art.GetComponentInChildren<Artifact>();
            if (artComp.Type == ArtifactType.fightArt)
            {
                artComp.EnableBoost(defendingArmy);
            }
        }
        int turn = 0;
        while (attackingArmy.Count > 0 && defendingArmy.Count > 0)
        {
            if (turn % 2 == 0)
            {
                Archer.ManageArchersRangedAttack(attackingArmy, defendingArmy);
                attackingArmy[0].GetComponentInChildren<Unit>().Attack(defendingArmy[0]);
            }
            else
            {
                Archer.ManageArchersRangedAttack(defendingArmy, attackingArmy);
                defendingArmy[0].GetComponentInChildren<Unit>().Attack(attackingArmy[0]);
            }
            turn++;
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
            PositionWarriors.PositionUnits(attackingArmy, defendingArmy, false);
            yield return new WaitForSeconds(0.5f);
        }
        if (attackingArmy.Count == 0 && defendingArmy.Count == 0)
        {
            Debug.Log("peremogla druzhba");
            GameObject.Destroy(opponent);
            GameObject.Destroy(attackingPlayer);
        }
        else if (defendingArmy.Count == 0)
        {
            GameObject.Destroy(opponent);
            opponent = null;
            Debug.Log("winner: " + attackingPlayer.name);
            foreach (GameObject art in attackingPlayer.GetComponent<Army>().GetArtifacts)
            {
                var artComp = art.GetComponentInChildren<Artifact>();
                if (artComp.Type == ArtifactType.fightArt)
                {
                    artComp.DisableBoost(attackingArmy);
                }
            }
        }
        else
        {
            Debug.Log("winner: " + opponent.name);
            GameObject.Destroy(attackingPlayer);
            attackingPlayer = null;
            foreach (GameObject art in opponent.GetComponent<Army>().GetArtifacts)
            {
                var artComp = art.GetComponentInChildren<Artifact>();
                if (artComp.Type == ArtifactType.fightArt)
                {
                    artComp.DisableBoost(defendingArmy);
                }
            }
        }
        ReturnToMainScene(attackingPlayer, opponent);
    }
    void ReturnToMainScene(GameObject attackingPlayer, GameObject opponent)
    {
        if (attackingPlayer != null)
        {
            foreach (var unit in attackingPlayer.GetComponent<Army>().GetArmy)
            {
                unit.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (opponent != null)
        {
            foreach (var unit in opponent.GetComponent<Army>().GetArmy)
            {
                unit.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        mainCameraRef.SetActive(true);
        tileAutomataRef.SetActive(true);
        gridRef.SetActive(true);
        canvasRef.SetActive(true);
        if (opponent != null)
        {
            SceneManager.MoveGameObjectToScene(opponent, SceneManager.GetSceneByName("SampleScene"));
        }
        if (attackingPlayer != null)
        {
            SceneManager.MoveGameObjectToScene(attackingPlayer, SceneManager.GetSceneByName("SampleScene"));
        }
        SceneManager.UnloadSceneAsync("BattleScene");
    }
}
