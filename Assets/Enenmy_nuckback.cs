using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enenmy_nuckback : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rigid;
    private SpriteRenderer render;
    private float nuck;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.layer = 8;

            render.color = new Color(1, 1, 1, 0.4f);

            Vector2 nuck = Vector2.zero;
            if (collision.gameObject.transform.position.x > transform.position.x)
            {
                nuck = new Vector2(-2f, 5f);
            }
            else
            {
                nuck = new Vector2(2f, 5f);
            }

            rigid.AddForce(nuck, ForceMode2D.Impulse);

            Invoke("ESC", 2);
        }
    }
    void ESC()
    {
        this.gameObject.layer = 7;
        render.color = new Color(1, 1, 1, 1);
    }
}
