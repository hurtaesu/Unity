using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{
    private Movement movement;
    private Status status;
    private Animator animator;

    [SerializeField]
    WeaponDatabase weaponDatabase;

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

        if(weaponDatabase.AttackCooltime < 0 && Input.GetMouseButtonDown(0))
        { 
            animator.SetTrigger("Attack");
            weaponDatabase.AttackCooltime = 1;
        }
        else
        {
            weaponDatabase.AttackCooltime -= Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
           animator.SetBool("jump", false);
        }
    }
}
