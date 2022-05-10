using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int health;
    public int stamina = 3;
    [SerializeField]
    private float stamina_timer;
    void Start()
    {
        
    }


    void Update()
    {
        if(stamina < 3)
        {
            StartCoroutine(stamina_reload());
        }
        else
        {
            StopCoroutine(stamina_reload());
        }
    }

    IEnumerator stamina_reload()
    {
        yield return new WaitForSeconds(stamina_timer);

        stamina++;
    }
}
