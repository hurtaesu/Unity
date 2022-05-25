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
        for(int i = 0; i < pos.Length; i++)
        {
            GameObject go = Instantiate(FieldItem,pos[i],Quaternion.identity);
            go.GetComponent<FieldItem>().SetItem(itemDB[Random.Range(0,2)]);
        }
    }
}
