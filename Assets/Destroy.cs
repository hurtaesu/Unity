using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {
        //�ȳ��ϼ���
    }

    // Update is called once per frame
    void Update()
    {
        //�����ž� 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject); //�̷��� �����˳׿� ����
    }
}
