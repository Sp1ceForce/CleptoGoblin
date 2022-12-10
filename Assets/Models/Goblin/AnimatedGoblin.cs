using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedGoblin : MonoBehaviour
{
    private PlayerController pl;
    private Animator animator;

    void Start()
    {
        pl = gameObject.GetComponent<PlayerController>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pl.isRuning == true)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        if (pl.isAiming)
        {
            animator.SetBool("isAim", true);
        }
        else
        {
            animator.SetBool("isAim", false);
        }
        if (pl.isThrow)
        {
            animator.SetBool("Throw", true);
        }
        else
        {
            animator.SetBool("Throw", false);
        }
    }
}
