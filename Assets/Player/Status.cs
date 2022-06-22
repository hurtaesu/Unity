using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public int health = 3;
    public int stamina = 3;
    public int stamina_limit = 3;
    private float currenttime = 5;
    [SerializeField]
    private float stamina_timer;
    [SerializeField]
    private Image staminaimage;
    void Start()
    {

    }
    void Update()
    {
        stamina_reload();
    }

    public void stamina_reload()
    {
        if (stamina < stamina_limit)
        {
            if (currenttime < 0)
            {
                stamina++;
                currenttime = stamina_timer;
            }
            else
            {
                currenttime -= Time.deltaTime;
                staminaimage.fillAmount += 0.2f * Time.deltaTime;
            }
            if(staminaimage.fillAmount == 1)
            {
                staminaimage.fillAmount = 0;
            }
        }
    }
}
