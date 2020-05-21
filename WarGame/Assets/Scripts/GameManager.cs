using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private List<GameObject> neutralArmies;
    private GameObject mainCameraRef;
    private GameObject tileAutomataRef;
    private GameObject gridRef;
    private GameObject canvasRef;
    private GameObject botsRef;
    private string winnerName;
    private string loserName;
    private Text winText;
    public void BeginBattle(GameObject attackingPlayer, GameObject opponent)
    {
        
        StartCoroutine(LoadBattleScene(attackingPlayer, opponent));
    }

    void Update()
    {
    }

    IEnumerator LoadBattleScene(GameObject attackingPlayer, GameObject opponent)
    {
        botsRef = GameObject.Find("bots");
        mainCameraRef = GameObject.Find("Main Camera");
        tileAutomataRef = GameObject.Find("TileAutomata");
        gridRef = GameObject.Find("Grid");
        canvasRef = GameObject.Find("Canvas");
        neutralArmies = new List<GameObject>();
        foreach (Transform child in botsRef.transform)
        {
            if(child.gameObject != opponent)
            {
                neutralArmies.Add(child.gameObject);
                child.gameObject.SetActive(false);
            }
        }
        mainCameraRef.SetActive(false);
        tileAutomataRef.SetActive(false);
        gridRef.SetActive(false);
        canvasRef.SetActive(false);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BattleScene", LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        if(opponent.transform.parent != null)
        {
            SceneManager.MoveGameObjectToScene(GameObject.Find("bots"), SceneManager.GetSceneByName("BattleScene"));
            SceneManager.MoveGameObjectToScene(attackingPlayer, SceneManager.GetSceneByName("BattleScene"));
            PositionWarriors.PositionUnits(attackingPlayer.GetComponent<Army>().GetArmy, opponent.GetComponent<Army>().GetArmy, true);
            StartCoroutine(Fight(attackingPlayer, opponent));
        }
        else
        {
            SceneManager.MoveGameObjectToScene(attackingPlayer, SceneManager.GetSceneByName("BattleScene"));
            SceneManager.MoveGameObjectToScene(opponent, SceneManager.GetSceneByName("BattleScene"));
            PositionWarriors.PositionUnits(attackingPlayer.GetComponent<Army>().GetArmy, opponent.GetComponent<Army>().GetArmy, true);
            StartCoroutine(Fight(attackingPlayer, opponent));
        }
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
                attackingArmy[0].GetComponentInChildren<Unit>().Attack(defendingArmy, 0);
                PositionWarriors.EnableAttackAnim(attackingArmy, defendingArmy, true);
            }
            else
            {
                Archer.ManageArchersRangedAttack(defendingArmy, attackingArmy);
                defendingArmy[0].GetComponentInChildren<Unit>().Attack(attackingArmy, 0);
                PositionWarriors.EnableAttackAnim(attackingArmy, defendingArmy, false);
            }
            yield return new WaitForSeconds(1f);
            turn++;
            while (defendingArmy.Count > 0 && defendingArmy[0].GetComponentInChildren<Unit>().Health <= 0)
            {
                GameObject.Destroy(defendingArmy[0]);
                defendingArmy.RemoveAt(0);
                PositionWarriors.DisableAttackAnim(attackingArmy);
            }
            while (attackingArmy.Count > 0 && attackingArmy[0].GetComponentInChildren<Unit>().Health <= 0)
            {
                GameObject.Destroy(attackingArmy[0]);
                attackingArmy.RemoveAt(0);
                PositionWarriors.DisableAttackAnim(defendingArmy);
            }
            PositionWarriors.PositionUnits(attackingArmy, defendingArmy, false);
            yield return new WaitForSeconds(1f);
        }
        if (attackingArmy.Count == 0 && defendingArmy.Count == 0)
        {
            Debug.Log("peremogla druzhba");
            GameObject.Destroy(opponent);
            GameObject.Destroy(attackingPlayer);
        }
        else if (defendingArmy.Count == 0)
        {
            loserName = opponent.name;
            GameObject.Destroy(opponent);
            opponent = null;
            Debug.Log("winner: " + attackingPlayer.name);
            winnerName = attackingPlayer.name;
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
            winnerName = opponent.name;
            loserName = attackingPlayer.name;
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
        Debug.Log(winnerName != "PlayerParent" || winnerName != "PlayerParent2");
        if ((winnerName == "PlayerParent" || winnerName == "PlayerParent2") && (loserName == "PlayerParent" || loserName == "PlayerParent2"))
        {
            GameObject.Find("WinnerText").GetComponentInChildren<Text>().text = winnerName + " WINS";
        }
        else
        {
            ReturnToMainScene(attackingPlayer, opponent);
        }
    }
    void ReturnToMainScene(GameObject attackingPlayer, GameObject opponent)
    {
        if (attackingPlayer != null)
        {
            foreach (var unit in attackingPlayer.GetComponent<Army>().GetArmy)
            {
                unit.GetComponent<SpriteRenderer>().enabled = false;
                unit.GetComponent<Animator>().enabled = false;
            }
        }
        else
        {

        }
        if (opponent != null)
        {
            foreach (var unit in opponent.GetComponent<Army>().GetArmy)
            {
                unit.GetComponent<SpriteRenderer>().enabled = false;
                unit.GetComponent<Animator>().enabled = false;
            }
        }
        mainCameraRef.SetActive(true);
        tileAutomataRef.SetActive(true);
        gridRef.SetActive(true);
        canvasRef.SetActive(true);
        foreach (var child in neutralArmies)
        {
            child.SetActive(true);
        }
        if (opponent != null)
        {
            if(opponent.transform.parent != null)
            {
                SceneManager.MoveGameObjectToScene(botsRef, SceneManager.GetSceneByName("SampleScene"));
            }
            else
            {
                SceneManager.MoveGameObjectToScene(opponent, SceneManager.GetSceneByName("SampleScene"));
            }
        }
        if (attackingPlayer != null)
        {
            SceneManager.MoveGameObjectToScene(botsRef, SceneManager.GetSceneByName("SampleScene"));
            SceneManager.MoveGameObjectToScene(attackingPlayer, SceneManager.GetSceneByName("SampleScene"));
        }
        SceneManager.UnloadSceneAsync("BattleScene");
    }
}
