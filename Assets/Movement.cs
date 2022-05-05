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

    [SerializeField]
    private LayerMask groundlayer;
    private CapsuleCollider2D capsuleCollider;
    private bool isground;
    private Vector3 footposition;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        Bounds bounds = capsuleCollider.bounds;
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
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(footposition, 0.1f);
    }
}
