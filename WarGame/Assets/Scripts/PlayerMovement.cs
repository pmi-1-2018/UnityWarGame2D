using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Animator anim;
    public int stamina;
    private Vector2 direction;

    public Tilemap top;
    public Tilemap bot;

    private Vector2 startPos;
    public Vector2 endPos;
    public float step;
    private float progress;
    public Grid grid;

    private void Start()
    {
        stamina = 10;
        anim = GetComponent<Animator>();
        startPos = transform.position;
        endPos = transform.position;
    }
    private void Update()
    {
        Move();
    }
    private Vector2 GetInput()
    {
        direction = Vector2.zero;
        Vector2 moveVectorUp = new Vector2(0f, 3f);
        Vector2 moveVectorDown = new Vector2(0f, -3f);
        Vector2 moveVectorLeft = new Vector2(-3f, 0);
        Vector2 moveVectorRight = new Vector2(3f, 0);
        if(stamina > 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                direction += moveVectorUp;
                stamina -= 1;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                direction += moveVectorDown;
                stamina -= 1;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                direction += moveVectorLeft;
                stamina -= 1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                direction += moveVectorRight;
                stamina -= 1;
            }
        }
        else
        {
            rb.Sleep();
        }
        endPos.x += direction.x;
        endPos.y += direction.y;
        Vector3Int cellPos = new Vector3Int((int)grid.WorldToCell(endPos).x, (int)grid.WorldToCell(endPos).y, 0);
        TerrainTile targetTile = top.GetTile(cellPos) as TerrainTile;
        if (targetTile != null && targetTile.Obj != null)
        {
            Debug.Log(cellPos);
            Debug.Log("Cannot go further");
            endPos.x -= direction.x;
            endPos.y -= direction.y;
            stamina += 1;
        }
        return endPos;
       
    }
    void Move()
    {
        endPos = GetInput();
        transform.position = Vector2.Lerp(startPos, endPos, progress);
        progress += step;
        Vector3Int cellPos = new Vector3Int((int)grid.WorldToCell(startPos).x,(int)grid.WorldToCell(startPos).y,0);

        if (progress != 1f)
        {
            anim.SetBool("isMoving", true);
        }
        if (transform.position.x == endPos.x && transform.position.y == endPos.y)
        {
             startPos = endPos;
             progress = 0f;
             anim.SetBool("isMoving", false);
        }
    }
}
