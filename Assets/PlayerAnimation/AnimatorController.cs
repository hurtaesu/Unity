using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    WeaponDatabase weaponDatabase;
    [SerializeField]
    RuntimeAnimatorController[] animatorControllers;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponDatabase.Sword == true && weaponDatabase.Wand == false && weaponDatabase.Shield == false)
        {
            animator.runtimeAnimatorController = animatorControllers[0];
        }

        if (weaponDatabase.Sword == false && weaponDatabase.Wand == true && weaponDatabase.Shield == false)
        {
            animator.runtimeAnimatorController = animatorControllers[1];
        }

        if (weaponDatabase.Sword == false && weaponDatabase.Wand == false && weaponDatabase.Shield == true)
        {
            animator.runtimeAnimatorController = animatorControllers[2];
        }
    }
}
