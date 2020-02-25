using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    private Animator anim;
    public int stamina = 10;
    // Update is called once per frame
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I'm standing on Grass");
        if (collision.name == "testDirt")
        {
            Debug.Log("I'm standing on Grass");
            stamina -= 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I'm standing on Grass");
        if (other.name == "Grass")
        {
            Debug.Log("I'm standing on Grass");
            stamina -= 1;
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Move();
        }
        //Vector3Int cur = new Vector3Int((int)GetComponent<Rigidbody>().position.x,(int)GetComponent<Rigidbody>().position.y, (int)GetComponent<Rigidbody>().position.z);
        //TileBase curTile = map.GetTile(cur);
        //movement.x = rb.position.x+ray.origin.x;
        //movement.y = rb.position.y + ray.origin.y;
        //transform.parent.position = Vector2.MoveTowards(transform.parent.position,ray.origin, moveSpeed * Time.deltaTime);
        //else
        //{
        //    movement.x = 0;
        //    movement.y = 0;
        //}
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x == 0 && movement.y == 0)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }
        
    }
    void Move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //map.GetTile(ray.origin);
        Debug.Log(ray);
        Vector2 numTilesToGo = new Vector2(0, 0);
        numTilesToGo.x = (int)ray.origin.x / 3F;
        numTilesToGo.y = (int)ray.origin.y / 3F;
        print(numTilesToGo);
        //ray.origin.x;
        Vector3 diff = new Vector3(ray.origin.x - transform.position.x, ray.origin.y - transform.position.y, 0);
        //Debug.Log("Dif::");
        //Debug.Log(diff);
        transform.position = Vector2.MoveTowards(transform.position , ray.origin, moveSpeed * Time.deltaTime);
        //void FixedUpdate()
        //{
        //    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //}
    }
}
