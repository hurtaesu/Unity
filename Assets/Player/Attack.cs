using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    Controller controller;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack_Sword(float x)
    {
        if (x == 0)
        {
            x = 1;
        }
        Debug.DrawRay(transform.position, new Vector3(x, 0, 0)*2, new Color(0, 1, 0));

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(x, 0, 0),2f,LayerMask.GetMask("Enemy"));

        if (hit.collider != null)
        {
            Debug.Log("Àû¿¡ ´êÀ½");
            Destroy(hit.collider.gameObject);
        }
    }
}
