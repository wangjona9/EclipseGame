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
    int isJumpingHash;

    public bool animatorDebug = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        isIdleHash = Animator.StringToHash("isIdle");
        isRunningHash = Animator.StringToHash("isRunning");
        isWalkingHash = Animator.StringToHash("isWalking");
        isCrouchingHash = Animator.StringToHash("isCrouching");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    void Update()
    {
        bool isIdle = animator.GetBool(isIdleHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isCrouching = animator.GetBool(isCrouchingHash);
        bool isJumping = animator.GetBool(isJumpingHash);

        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool crouchPressed = Input.GetKey(KeyCode.LeftAlt);
        bool jumpPressed = Input.GetKey(KeyCode.Space);

        if ((forwardPressed && runPressed) || (runPressed && forwardPressed))
        {
            Debug.Log("isRunning");
            animator.SetBool(isRunningHash, true);
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isIdleHash, false);
            animator.SetBool(isJumpingHash, false);
        }

        if (crouchPressed)
        {
            Debug.Log("isCrouching");
            animator.SetBool(isRunningHash, false);
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isCrouchingHash, true);
            animator.SetBool(isIdleHash, false);
            animator.SetBool(isJumpingHash, false);
        }

        if (forwardPressed && !runPressed)
        {
            Debug.Log("isWalking");
            animator.SetBool(isWalkingHash, true);
            animator.SetBool(isRunningHash, false);
            animator.SetBool(isIdleHash, false);
            animator.SetBool(isJumpingHash, false);
        }

        if (jumpPressed)
        {
            Debug.Log("isJumping");
            animator.SetBool(isJumpingHash, true);
        }

        else if (!forwardPressed && !runPressed && !crouchPressed && !jumpPressed)
        {
            Debug.Log("isIdle");
            animator.SetBool(isIdleHash, true);
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isRunningHash, false);
            animator.SetBool(isCrouchingHash, false);
            animator.SetBool(isJumpingHash, false);
        }
            
    }
}
