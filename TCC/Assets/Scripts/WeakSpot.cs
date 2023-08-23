using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    [SerializeField] PlayerDirection calculatePlayerDirection;
    public bool allowCritFront = false;
    public bool allowCritBack = false;
    public bool allowCritUp = false;
    public bool allowCritDown = false;

    public bool IsPlayerCorrectPos(Transform player)
    {
        if (calculatePlayerDirection.IsPlayerFront(player) && allowCritFront)
        {
            return true;
        }
        if (calculatePlayerDirection.IsPlayerBack(player) && allowCritBack)
        {
            return true;
        }
        if (calculatePlayerDirection.IsPlayerUp(player) && allowCritUp)
        {
            return true;
        }
        if (calculatePlayerDirection.IsPlayerDown(player) && allowCritDown)
        {
            return true;
        }

        return false;
    }

    public bool IsHittable()
    {
        return true;
    }


}
