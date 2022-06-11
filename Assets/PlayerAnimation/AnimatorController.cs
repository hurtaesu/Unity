using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    WeaponDatabase weaponDatabase;
    [SerializeField]
    RuntimeAnimatorController[] animatorControllers;

    private Status status;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        status = GetComponent<Status>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponDatabase.Sword == true)
        {
            animator.runtimeAnimatorController = animatorControllers[0];
        }

        if (weaponDatabase.Wand == true)
        {
            animator.runtimeAnimatorController = animatorControllers[1];
        }

        if (weaponDatabase.Shield == true)
        {
            animator.runtimeAnimatorController = animatorControllers[2];
        }
    }
}
