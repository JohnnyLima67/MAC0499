using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBehaviour : HittableBehaviour
{
    [SerializeField] protected int hitpoints = 3;

    public override void TakeDamage(float damage, bool hitWeakSpot)
    {
        if (hitpoints > 0)
        {
            hitpoints -= 1;
            if (hitpoints <= 0)
            {
                Die();
            }
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
