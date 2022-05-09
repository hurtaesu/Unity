using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float movespeed = 5.0f;
    [SerializeField]
    private float jumpforce = 8.0f;
    public float jumpcount = 2;
    private Rigidbody2D rigid;
    private SpriteRenderer sprite;

    [SerializeField]
    private LayerMask groundlayer;
    private BoxCollider2D boxCollider;
    private bool isground;
    private Vector3 footposition;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>(); 
    }

    private void FixedUpdate()
    {
        Bounds bounds = boxCollider.bounds;
        footposition = new Vector2(bounds.center.x, bounds.min.y);
        isground = Physics2D.OverlapCircle(footposition, 0.1f, groundlayer);


        if (isground == true && jumpcount <= 0)
        {
            jumpcount = 2;
        }
    }

    public void jump()
    {
        if (jumpcount > 0)
        rigid.velocity = Vector2.up * jumpforce;
        jumpcount--;
    }

    public void Move(float x)
    {
        rigid.velocity = new Vector2(x * movespeed, rigid.velocity.y);

        if (x == 1 || x == 0)
        {
            sprite.flipX = false;
        }
        else if (x == -1)
        {
            sprite.flipX= true;
        }

              

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(footposition, 0.1f);
    }
}
