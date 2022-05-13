using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private Inventory inventory;
    public Image itemObject;

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
                    Instantiate(itemObject,inventory.slots[i].transform,false);
                    itemObject.rectTransform.position = new Vector3(0, 0, 0);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }


}
