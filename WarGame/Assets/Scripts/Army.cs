using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> army = new List<GameObject>();
    public GameObject pepega;

    public List<GameObject> GetArmy { get => army; }

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            army.Add(Instantiate(pepega, new Vector3( -25 + 4 * i, 0, 0), Quaternion.identity, gameObject.transform));
            army[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
