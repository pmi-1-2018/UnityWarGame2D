using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> army = new List<GameObject>();
    public GameObject pepega;
    public GameObject archerPrefab;

    public List<GameObject> GetArmy { get => army; }

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
