using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {
        //안녕하세요
    }

    // Update is called once per frame
    void Update()
    {
        //노유신씨 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject); //이렇게 만나뵙네요 하하
    }
}
