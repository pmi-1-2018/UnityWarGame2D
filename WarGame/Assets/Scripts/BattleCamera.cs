using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCamera : MonoBehaviour
{
    private float moveSpeed = 0.5f;
    private float scrollSpeed = 10f;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.position += moveSpeed * new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        }
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize + (Input.GetAxisRaw("Mouse ScrollWheel") * scrollSpeed), 10);
        }
    }
}
