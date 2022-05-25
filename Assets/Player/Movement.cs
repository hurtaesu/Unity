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
    private Animator animator;

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
        animator = GetComponent<Animator>();
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
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            if(isdash)
            {
                dashtime = startdashtime;
            }
        }
        else
        {
            dashtime -= Time.deltaTime;
            defaultspeed = dashforce;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        isdash = false;
    }
    public void jump()
    {
        if (jumpcount > 0)
        rigid.velocity = Vector2.up * jumpforce;
        jumpcount--;
        animator.SetBool("jump", true);
    }


    public void Move(float x)
    {
        rigid.velocity = new Vector2(x * defaultspeed, rigid.velocity.y);

        if (x == 1)
        {
            sprite.flipX = false;
        }
        else if (x == -1)
        {
            sprite.flipX= true;
        }   
        if(x == 1 || x == -1)
        {
            animator.SetBool("move",true);
        }
        else if(x == 0)
        {
            animator.SetBool("move",false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(footposition, 0.1f);
    }
}
