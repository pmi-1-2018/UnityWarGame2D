using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
    private ArtifactsBag artifacts = new ArtifactsBag();
    private List<GameObject> army = new List<GameObject>();
    public GameObject pepega;
    public GameObject archerPrefab;
    public GameObject hydraPrefab;
    public GameObject PoorMansShieldPrefab;
    public GameObject HeroSwordPrefab;

    public List<GameObject> GetArmy { get => army; }
    public ArtifactsBag GetArtifacts { get => artifacts; }

    void Awake()
    {
        //if (gameObject.transform.lossyScale.x == 0.5f)
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        army.Add(Instantiate(pepega, new Vector3(-25 + 4 * i, 0, 0), Quaternion.identity, gameObject.transform));
        //        army[i].transform.localScale = new Vector3(6f, 6f, 6f);
        //        army[i].GetComponent<SpriteRenderer>().enabled = false;
        //        army[i].GetComponent<Animator>().enabled = false;
        //    }
        //    return;
        //}
        for (int i = 0; i < 5; i++)
        {
            if (gameObject.name == "PlayerParent" && i == 2)
            {
                army.Add(Instantiate(archerPrefab, new Vector3(-25 + 4 * i, 0, 0), Quaternion.identity, gameObject.transform));
                army[i].GetComponent<SpriteRenderer>().enabled = false;
                army[i].GetComponent<Animator>().enabled = false;
                continue;
            }
            army.Add(Instantiate(pepega, new Vector3(-25 + 4 * i, 0, 0), Quaternion.identity, gameObject.transform));
            army[i].GetComponent<SpriteRenderer>().enabled = false;
            army[i].GetComponent<Animator>().enabled = false;
        }
        if (gameObject.name == "PlayerParent2")
        {
            army.Add(Instantiate(archerPrefab, new Vector3(-25 + 4 * 5, 0, 0), Quaternion.identity, gameObject.transform));
            army[5].GetComponent<SpriteRenderer>().enabled = false;
            army[5].GetComponent<Animator>().enabled = false;
        }
        if (gameObject.name == "PlayerParent2")
        {
            army[0] = (Instantiate(hydraPrefab, new Vector3(-25 + 4 * 0, 0, 0), Quaternion.identity, gameObject.transform));
            army[0].GetComponent<SpriteRenderer>().enabled = false;
            army[0].GetComponent<Animator>().enabled = false;
            army[1] = (Instantiate(hydraPrefab, new Vector3(-25 + 4 * 1, 0, 0), Quaternion.identity, gameObject.transform));
            army[1].GetComponent<SpriteRenderer>().enabled = false;
            army[1].GetComponent<Animator>().enabled = false;
        }
    }
}
