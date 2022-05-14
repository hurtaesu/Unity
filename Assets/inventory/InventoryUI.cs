using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject InventoryPanel;
    bool activeInventory = false;
    Inventory inventory;

    public Slot[] slots;
    public Transform slotHolder;
    private void Start()
    {
        inventory = Inventory.Instance;
        inventory.onSlotCountChange += SlotChange;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        InventoryPanel.SetActive(activeInventory);
        inventory.onChangeItem += RedrawSlotUI;
    }

    private void SlotChange(int val)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    public void AddSlot()
    {
        inventory.SlotCnt++;
    }

    void RedrawSlotUI()
    {
        for(int i = 0;i < slots.Length;i++)
        {
            slots[i].RemoveSlot();
        }
        for(int i = 0;i < inventory.items.Count;i++)
        {
            slots[i].item = inventory.items[i];
            slots[i].UpdateSlotUI();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            activeInventory = !activeInventory; 
            InventoryPanel.SetActive(activeInventory);
        }
    }

}
