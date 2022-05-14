using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    public GameObject FieldItem;
    public Vector3[] pos;

    private void Awake()
    {
        instance = this;
    }
    public List<Item>itemDB = new List<Item>();

    private void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject go = Instantiate(FieldItem,pos[i],Quaternion.identity);
            go.GetComponent<FieldItem>().SetItem(itemDB[0]);
        }
    }
}
