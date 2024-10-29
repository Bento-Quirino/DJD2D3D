using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private Animator animator;
    private bool isFrozen = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFrozen)
        {

            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                FreezeAnimation();
            }
        }
    }

    private void FreezeAnimation()
    {
        isFrozen = true;
        animator.speed = 0; 
    }
}
