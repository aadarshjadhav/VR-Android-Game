using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int iswalkinghash;
    int isrunninghash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        iswalkinghash = Animator.StringToHash("IsWalking");
        isrunninghash = Animator.StringToHash("IsRunning");
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        bool IsRunning = animator.GetBool(isrunninghash);
        bool IsWalking = animator.GetBool(iswalkinghash);
        bool forwardpress = Input.GetKey("w");
        bool runpressed = Input.GetKey("left shift");
        if(!IsWalking && forwardpress)
        {
            animator.SetBool(iswalkinghash, true);

        }
        if(IsWalking && !forwardpress )
         {
            animator.SetBool(iswalkinghash, false);
         }
        if (!IsRunning && (forwardpress && runpressed))
        {
            animator.SetBool(isrunninghash, true);
        }
        if (IsRunning && (!forwardpress || !runpressed))
        {
            animator.SetBool(isrunninghash, false);
        }
    }
}
