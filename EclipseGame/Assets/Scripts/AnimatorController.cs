using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    int isRunningHash;
    int isWalkingHash;

    public bool animatorDebug = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);

        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        if (runPressed)
        {
            Debug.Log("isRunning");
            animator.SetBool(isRunningHash, true);
        }

        if (forwardPressed && !runPressed)
        {
            Debug.Log("isWalking");
            animator.SetBool(isWalkingHash, true);
        }
            

    }
}
