using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ChangeWeapon(ItemType itemType) //필요 없어질 수도 있음
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

    public void ChangeSword()
    {
        Sword = true;
        Wand = false;
        Shield = false;

        status.stamina = 1;
        status.stamina_limit = 1;
        SceneManager.LoadScene("Lobby");
    }

    public void ChangeWand()
    {
        Sword = false;
        Wand = true;
        Shield = false;

        status.stamina = 3;
        status.stamina_limit = 3;
        SceneManager.LoadScene("Lobby");
    }
}
