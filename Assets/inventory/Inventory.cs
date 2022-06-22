using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    WeaponDatabase weaponDatabase;
    private AnimatorController animatorController;
    #region Singleton
    public static Inventory Instance;
    private bool isItem;
    private FieldItem fielditems;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    #endregion
    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    public List<Item> items = new List<Item>(); 

    private int slotCnt;
    public int SlotCnt 
    { 
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }

    private void Start()
    {
        SlotCnt = 14;
    }

    public bool AddItme(Item _itme)
    {
        if(items.Count < SlotCnt)
        {
            items.Add(_itme);
            if(onChangeItem != null)
            {
               onChangeItem.Invoke();
            }
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ring"))
        {
            isItem = true;
        }
        fielditems = collision.GetComponent<FieldItem>();

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isItem = false;
    }

    private void Update()
    {
        if(isItem == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (AddItme(fielditems.GetItem()))
                   {
                    weaponDatabase.ChangeWeapon(fielditems.item.itemType);
                    fielditems.DestroyItem();
                   }
            }
        }
    }
}
