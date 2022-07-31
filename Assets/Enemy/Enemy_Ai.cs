using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ai : MonoBehaviour
{
    public float Enemy_speed;
    public int Move_Dir;
    public float DashTime;
    private bool isDash;
    SpriteRenderer sprite;
    Rigidbody2D rigid;
    Movement movement;
    Animator animator;
    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        movement = GameObject.Find("Player").GetComponent<Movement>();
        Invoke("Think", 3);
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        if(isDash == true)
        {
            Enemy_speed = 3;
            if (sprite.flipX == true)
            {
                Move_Dir = 1;
            }
            else
            {
                Move_Dir = -1;
            }
            animator.SetBool("isDash", true);
        }
        else
        {
            Enemy_speed = 1;
            animator.SetBool("isDash",false);
        }
        if(movement.isdodge == true)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
        //ÁÂ¿ìÀüÈ¯
        if (Move_Dir == 1)
        {
            sprite.flipX = true;
            boxCollider.offset = new Vector2(6,0);
            animator.SetBool("isMove",true);
        }
        else if(Move_Dir == -1)
        {
            sprite.flipX = false;
            animator.SetBool("isMove", true);
            boxCollider.offset = new Vector2(-6, 0);
        }
        else
        {
            animator.SetBool("isMove", false);
        }
        //¿òÁ÷ÀÓ
        rigid.velocity = new Vector2(Move_Dir * Enemy_speed, rigid.velocity.y);
        //¹Ù´Ú Ã¼Å©
        Vector2 front = new Vector2(rigid.position.x + (Move_Dir * Enemy_speed), rigid.position.y);
        Debug.DrawRay(front, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D hit = Physics2D.Raycast(front, Vector3.down, 10, LayerMask.GetMask("Ground"));
        if(hit.collider == null)
        {
            Move_Dir *= -1;
            CancelInvoke();
            Invoke("Think", 3);
        }

    }

    private void Think()
    {
        Move_Dir = Random.Range(-1,2);

        float Think_Time = Random.Range(2f, 5f);
        Invoke("Think", Think_Time);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("µÅÁö µ¹Áø");
        if(collision.CompareTag("Player") == true)
        {
            isDash = true;
        }
        else
        {
            isDash = false;
        }
    }
}
