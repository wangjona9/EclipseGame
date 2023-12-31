using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    int isIdleHash;
    int isRunningHash;
    int isWalkingHash;
    int isCrouchingHash;

    public bool animatorDebug = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        isIdleHash = Animator.StringToHash("isIdle");
        isRunningHash = Animator.StringToHash("isRunning");
        isWalkingHash = Animator.StringToHash("isWalking");
        isCrouchingHash = Animator.StringToHash("isCrouching");
    }

    void Update()
    {
        bool isIdle = animator.GetBool(isIdleHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isCrouching = animator.GetBool(isCrouchingHash);

        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool crouchPressed = Input.GetKey(KeyCode.LeftAlt);

        if (runPressed)
        {
            Debug.Log("isRunning");
            animator.SetBool(isRunningHash, true);
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isIdleHash, false);
        }

        if (crouchPressed)
        {
            Debug.Log("isCrouching");
            animator.SetBool(isRunningHash, false);
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isCrouchingHash, true);
            animator.SetBool(isIdleHash, false);
        }

        if (forwardPressed && !runPressed)
        {
            Debug.Log("isWalking");
            animator.SetBool(isWalkingHash, true);
            animator.SetBool(isRunningHash, false);
            animator.SetBool(isIdleHash, false);
        }

        else 
            animator.SetBool(isIdleHash, true);
    }
}
