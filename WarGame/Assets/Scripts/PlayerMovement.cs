﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;

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


    private Inventory inventory;


    //private void Awake()
    //{
    //    inventory = new Inventory();
    //    uiInventory.SetInventory(inventory);
    //}

    private void Start()
    {
        stamina = 300;
        anim = GetComponent<Animator>();
        startPos = transform.position;
        endPos = transform.position;

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        //ItemWorld.SpawnItemWorld(new Vector3(-150, -90), new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
        //ItemWorld.SpawnItemWorld(new Vector3(-171, -110), new Item { itemType = Item.ItemType.Sword, amount = 1 });
        //ItemWorld.SpawnItemWorld(new Vector3(-171, -90), new Item { itemType = Item.ItemType.Medkit, amount = 1 });
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
        Debug.Log(direction);
        endPos.x += direction.x;
        endPos.y += direction.y;
        return endPos;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    void Move()
    {
        endPos = GetInput();
        transform.position = Vector2.Lerp(startPos, endPos, progress);
        progress += step;
        Vector3Int cellPos = new Vector3Int((int)grid.WorldToCell(startPos).x, (int)grid.WorldToCell(startPos).y, 0);
        Debug.Log(top.GetTile(cellPos));
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