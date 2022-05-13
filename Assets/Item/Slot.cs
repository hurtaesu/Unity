using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int i;
    private Inventory inventory;

    private void Awake()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.fullCheck[i] = false;
        }
    }
}
