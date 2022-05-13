using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Movement movement;
    private Status status;
    [SerializeField]
    private GameObject bullet;
    private Animator animator;
    [SerializeField]
    private Inventory inventoryprefab;
    Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        status = GetComponent<Status>();
        animator = GetComponent<Animator>();
        inventory = Instantiate(inventoryprefab);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.jump();
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical"); 
        movement.Move(x);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           GameObject clone = Instantiate(bullet,transform.position,Quaternion.identity);
            clone.GetComponent<bulletMovement>().Setup(new Vector3(x, 0, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        {
            Scriptable hitObject = collision.gameObject.GetComponent<Item>().sword; 

            if(hitObject != null)
            {
                bool GetItem = false;
                if(hitObject.itemType == Scriptable.ItemType.WEAPON)
                {
                    GetItem = inventory.AddItem(hitObject);
                }
                if(GetItem)
                {
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }
}
