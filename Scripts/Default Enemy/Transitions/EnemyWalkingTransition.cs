using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkingTransition : Transition
{
    public bool isAbleToGo {get;set;}

    private void Update() {
        if (isAbleToGo)
            NeedSwitch = true;
    }
}
