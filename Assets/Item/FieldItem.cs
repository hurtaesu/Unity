using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;

    public void SetItem(Item _item)
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;

        image.sprite = _item.itemImage;
    }
    public Item GetItem()
    {
        return item;
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("아이템");
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("e누름");
        }
    }
}
