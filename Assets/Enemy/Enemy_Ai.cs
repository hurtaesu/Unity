using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ai : MonoBehaviour
{
    public float Enemy_speed;
    public int Move_Dir;
    SpriteRenderer sprite;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        Invoke("Think", 3);
    }

    void Update()
    {
        //좌우전환
        if (Move_Dir == 1)
        {
            sprite.flipX = true;
        }
        else if(Move_Dir == -1)
        {
            sprite.flipX = false;
        }
        //움직임
        rigid.velocity = new Vector2(Move_Dir * Enemy_speed, rigid.velocity.y);
        //바닥 체크
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
}
