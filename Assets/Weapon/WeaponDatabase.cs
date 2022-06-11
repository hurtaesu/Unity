using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDatabase : MonoBehaviour
{
    public bool Sword; //Į
    public bool Wand; //����������
    public bool Shield; //����

    public int Damage; //���ݷ�
    public float AttackSpeed; //����
    public float AttackCooltime;//���� ��Ÿ��;

    private Status status;
    private void Awake()
    {
        status = GetComponent<Status>();
    }

    public void ChangeWeapon(ItemType itemType)
    {
        if(itemType == ItemType.Sworld)
        {
            Sword = true;
            Wand = false;
            Shield = false;

            status.stamina = 1;
            status.stamina_limit = 1;
        }
        else if(itemType == ItemType.Test)
        {
            Sword = false;
            Wand = true;
            Shield = false;

            status.stamina = 3;
            status.stamina_limit = 3;
        }
    }
}
