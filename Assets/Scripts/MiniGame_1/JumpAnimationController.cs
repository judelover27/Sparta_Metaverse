using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnimationController : MonoBehaviour
{
    private Animator animator;
    private float holdTime = 0f;
    private bool isHolding = false;
    private static readonly int HoldTime = Animator.StringToHash("HoldTime");
    private static readonly int IsHolding = Animator.StringToHash("IsHolding");

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Squash();
    }

    private void Squash()
    {
        if (Input.GetMouseButton(0)) 
        {
            holdTime += Time.deltaTime;
            isHolding = true;
        }
        else // 마우스를 떼면
        {
            isHolding = false;
            holdTime = 0;
        }

        animator.SetFloat(HoldTime, holdTime);
        animator.SetBool(IsHolding, isHolding);

    }
}
