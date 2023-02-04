using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningBehavior : StateMachineBehaviour
{
    [SerializeField] private FrontDoorLogic _frontDoorLogic;
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _frontDoorLogic.canInteractWithDoor = false;    
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _frontDoorLogic.canInteractWithDoor = true;
    }
}
