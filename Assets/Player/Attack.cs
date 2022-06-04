using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    Controller controller;
    [SerializeField]
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, new Vector3(-1, 0, 0) * 2, new Color(0, 1, 0));
    }

    public void Attack_Sword(float x)
    {
        if (sprite.flipX == true)
        {
            x = -1;
        }
        else if(sprite.flipX == false)
        {
            x = 1;
        }

        Debug.DrawRay(transform.position, new Vector3(x, 0, 0)*2, new Color(0, 1, 0));

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(x, 0, 0),2.5f,LayerMask.GetMask("Enemy"));

        if (hit.collider != null)
        {
            Debug.Log("Àû¿¡ ´êÀ½");
            Destroy(hit.collider.gameObject);
        }
    }
}
