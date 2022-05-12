using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public int Hp = 3;
    
    [SerializeField]
    private Image Hp_image;

    void Start()
    {
        Hp_image = GetComponent<Image>();
    }

    void Update()
    {
        Hp_reduce();
    }

    public void Hp_reduce()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Hp--;
            Hp_image.fillAmount -= 0.333f * 1;
                
        }
    }
}
