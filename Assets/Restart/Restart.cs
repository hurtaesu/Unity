using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    private Restart_Check check;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (check.gameover)
        {
            animator.SetBool("isgameover", true);
        }
    }
}
