using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
    private List<GameObject> artifacts = new List<GameObject>();
    private List<GameObject> army = new List<GameObject>();
    public GameObject pepega;
    public GameObject archerPrefab;
    public GameObject PoorMansShieldPrefab;
    public GameObject HeroSwordPrefab;

    public List<GameObject> GetArmy { get => army; }
    public List<GameObject> GetArtifacts { get => artifacts; }

    void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            if (gameObject.name == "PlayerParent" && i == 2)
            {
                army.Add(Instantiate(archerPrefab, new Vector3(-25 + 4 * i, 0, 0), Quaternion.identity, gameObject.transform));
                army[i].GetComponent<SpriteRenderer>().enabled = false;
                continue;
            }
            army.Add(Instantiate(pepega, new Vector3( -25 + 4 * i, 0, 0), Quaternion.identity, gameObject.transform));
            army[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        if (gameObject.name == "pidar")
        {
            army.Add(Instantiate(archerPrefab, new Vector3(-25 + 4 * 5, 0, 0), Quaternion.identity, gameObject.transform));
            army[5].GetComponent<SpriteRenderer>().enabled = false;
        }
        if (gameObject.name == "PlayerParent")
        {
            artifacts.Add(Instantiate(PoorMansShieldPrefab, gameObject.transform));
            artifacts[0].GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
