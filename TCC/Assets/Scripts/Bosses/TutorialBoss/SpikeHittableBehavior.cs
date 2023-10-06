using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHittableBehavior : HittableBehaviour
{
    public override void TakeDamage(float damage)
    {

	}

    public override void TakeDamage(float damage, bool hitWeakSpot)
    {

	}

    public override void Die()
    {

	}

    public override void AfterDie()
    {

	}

    public override bool IsBounceable()
    {
		return isBounceable;
	}
}
