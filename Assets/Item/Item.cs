using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemObject;

    private void Awake()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            for(int i = 0;i < inventory.slots.Length;i++)
            {
                if(inventory.fullCheck[i] == false)
                {
                    inventory.fullCheck[i] = true;
                    Instantiate(itemObject, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }


}
