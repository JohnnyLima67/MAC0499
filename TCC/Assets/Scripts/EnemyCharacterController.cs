using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterController : CharacterController
{


    public override void BeforeStartKnockback()
    {

    }

    public override void AfterEndKnockback()
    {
        this.EndExternalSpeed();
    }
}
