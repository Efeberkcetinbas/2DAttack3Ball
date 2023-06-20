using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : Interactable
{
    internal override void DoAction(PlayerTrigger player)
    {
        Debug.Log("WORK");
    }

    internal override void InteractionExit(PlayerTrigger player)
    {
        //
    }
}
