using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{
    private Movement movement;
    private Status status;
    [SerializeField]
    private GameObject bullet;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        status = GetComponent<Status>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.jump();
            animator.SetTrigger("jumping");
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical"); 
        movement.Move(x);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
           animator.SetBool("jump", false);
        }
    }
}
