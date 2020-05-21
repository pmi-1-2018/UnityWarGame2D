using UnityEngine;
using UnityEngine.Tilemaps;
public class Player : MonoBehaviour
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

    public Inventory Inventory { get => inventory; }

    private void Start()
    {
        stamina = 0;
        anim = GetComponent<Animator>();
        startPos = transform.position;
        endPos = transform.position;

        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);
    }

    private void UseItem(Item item)
    {
        switch (item.itemType)
        {
            case Item.ItemType.HealthPotion:
                Debug.Log("It's HEALTH POTION");
                inventory.RemoveItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
                break;
            case Item.ItemType.ManaPotion:
                Debug.Log("It's MANA POTION");
                inventory.RemoveItem(new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
                break;
            case Item.ItemType.Coin:
                Debug.Log("It's COIN");
                inventory.RemoveItem(new Item { itemType = Item.ItemType.Coin, amount = 1 });
                break;
            case Item.ItemType.Medkit:
                Debug.Log("It's MEDKIT");
                inventory.RemoveItem(new Item { itemType = Item.ItemType.Medkit, amount = 1 });
                break;
            case Item.ItemType.Sword:
                Debug.Log("It's SWORD");
                inventory.RemoveItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
                break;
        }
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
            if (targetTile.Obj.IsTree)
            {
                Debug.Log("Hit the tree. Cannot go further");
                endPos.x -= direction.x;
                endPos.y -= direction.y;
                stamina += 1;
            } else if (targetTile.Obj.IsBuilding)
            {
                Debug.Log("Hit the building.");
                // remove these lines to be able to step onto the building
                endPos.x -= direction.x;
                endPos.y -= direction.y;
                stamina += 1;
            }
        } 
        return endPos;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Item")
        //{
            ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
            if (itemWorld != null)
            {
                inventory.AddItem(itemWorld.GetItem());
                itemWorld.DestroySelf();
            }
        //}
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
