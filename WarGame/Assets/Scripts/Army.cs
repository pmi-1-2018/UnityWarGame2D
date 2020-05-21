using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
    private ArtifactsBag artifacts = new ArtifactsBag();
    private List<GameObject> army = new List<GameObject>();
    private Inventory inventoryItems = new Inventory();
    public GameObject pepega;
    public GameObject archerPrefab;
    public GameObject PoorMansShieldPrefab;
    public GameObject HeroSwordPrefab;
    

    public List<GameObject> GetArmy { get => army; }
    public ArtifactsBag GetArtifacts { get => artifacts; }
    public Inventory GetInventoryItems { get => inventoryItems; }


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
            //artifacts.Add(Instantiate(PoorMansShieldPrefab, gameObject.transform));
            //artifacts[0].GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
