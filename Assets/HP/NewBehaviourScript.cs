using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    private Status status; 
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

           status.health--;
           Hp_image.fillAmount -= 0.333f * 1;
        }
    }
}
