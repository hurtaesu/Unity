using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movespeed = 5.0f;
    private float defaultspeed;
    [SerializeField]
    private float jumpforce = 8.0f;
    public float dashforce = 10.0f;
    public float jumpcount = 2;
    private Rigidbody2D rigid;
    private SpriteRenderer sprite;
    private Status status;
    public bool isdash;
    [SerializeField]
    private float startdashtime;
    private float dashtime;

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
        status = GetComponent<Status>();
        defaultspeed = movespeed;
    }

    void Update()
    {
        Bounds bounds = boxCollider.bounds;
        footposition = new Vector2(bounds.center.x, bounds.min.y);
        isground = Physics2D.OverlapCircle(footposition, 0.1f, groundlayer);


        if (isground == true && jumpcount <= 0)
        {
            jumpcount = 2;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && status.stamina > 0)
        {
            isdash = true;
            status.stamina--;
        }
        if(dashtime <= 0)
        {
            defaultspeed = movespeed;
            if(isdash)
            {
                dashtime = startdashtime;
            }
        }
        else
        {
            dashtime -= Time.deltaTime;
            defaultspeed = dashforce;
        }
        isdash = false;
    }

    public void jump()
    {
        if (jumpcount > 0)
        rigid.velocity = Vector2.up * jumpforce;
        jumpcount--;
    }

    public void Move(float x)
    {
        rigid.velocity = new Vector2(x * defaultspeed, rigid.velocity.y);

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
