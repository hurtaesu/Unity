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
    public float jumpcount = 1;
    private Rigidbody2D rigid;
    private SpriteRenderer sprite;
    private Status status;
    public bool isdash;
    public bool isdodge;
    public bool isMove;
    [SerializeField]
    private float startdashtime;
    private float dashtime;
    private Animator animator;

    [SerializeField]
    private LayerMask groundlayer;
    private BoxCollider2D boxCollider;
    public bool isground;
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
        //바닥 체크
        Bounds bounds = boxCollider.bounds;
        footposition = new Vector2(bounds.center.x, bounds.min.y);
        isground = Physics2D.OverlapCircle(footposition, 0.1f, groundlayer);

    }

    //점프
    public void jump()
    {
        if (jumpcount > 0)
        {
            rigid.velocity = Vector2.up * jumpforce;
            jumpcount--;
            animator.SetBool("jump", true);
            animator.SetTrigger("jumping");
        }
    }

    public void dash(float x)
    {
        //대쉬
        if (Input.GetKeyDown(KeyCode.LeftShift) && status.stamina > 0 && x != 0)
        {
            animator.SetTrigger("dash");
            status.stamina--;
            isdash = true;
        }
        if (dashtime <= 0)
        {
            defaultspeed = movespeed;
            gameObject.GetComponent<NewBehaviourScript>().enabled = true;
            isdodge = false;
            if (isdash)
            {
                dashtime = startdashtime;
            }
        }
        else
        {
            dashtime -= Time.deltaTime;
            defaultspeed = dashforce;
            gameObject.GetComponent<NewBehaviourScript>().enabled = false;
            isdodge = true;
        }
        isdash = false;
    }

    //움직임
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
            isMove = true;
            animator.SetBool("move",true);
        }
        else if(x == 0)
        {
            isMove = false;
            animator.SetBool("move",false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(footposition, 0.1f);
    }
}
