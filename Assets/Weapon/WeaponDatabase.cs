using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDatabase : MonoBehaviour
{
    public bool Sword; //칼
    public bool Wand; //마법지팡이
    public bool Shield; //방패

    public int Damage; //공격력
    public float AttackSpeed; //공속
    public float AttackCooltime;//공격 쿨타임;

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
