using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_on_End : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject, stateInfo.length);
    }
}