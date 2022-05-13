using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    private Status status;
    private float starttime;
    [SerializeField]
    private float cooltime = 5.0f;
    
    [SerializeField]
    private Image Hp_image;

    void Start()
    {
        Hp_image = GetComponent<Image>();
        status = GetComponent<Status>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            if(starttime <= 0)
            {
                status.health--;
                Hp_image.fillAmount -= 0.333f * 1;
                starttime = cooltime;
            }
            else
            {
                starttime -= Time.deltaTime;
            }               
        }
    }
}
