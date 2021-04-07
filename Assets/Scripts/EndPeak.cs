using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPeak : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Peak");
    }
}