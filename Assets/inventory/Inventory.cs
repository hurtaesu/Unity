using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject slotprefab;
    public const int slotnum = 1;
    Image[] itemimages = new Image[slotnum];
    Scriptable[] items = new Scriptable[slotnum];
    GameObject[] slot = new GameObject[slotnum]; 
    // Start is called before the first frame update
    void Start()
    {
        CreateSlots();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateSlots()
    {
        if(slotprefab != null)
        {
            for(int i = 0; i < slotnum; i++)
            {
                GameObject newslot = Instantiate(slotprefab);
                newslot.name = "ItemSlot_" + i;
                newslot.transform.SetParent(gameObject.transform.GetChild(0).transform);
                slot[i] = newslot;

                itemimages[i] = newslot.transform.GetChild(1).GetComponent<Image>();
            }
        }
    }

    public bool AddItem(Scriptable itemToAdd)
    {
        for(int i = 0; i < itemimages.Length; i++)
        {
            if(items[i] == null)
            {
                items[i] = Instantiate(itemToAdd);
                itemimages[i].sprite = itemToAdd.sprite;
                itemimages[i].enabled = true;
                return true;
            }
        }
        return false;
    }
}
