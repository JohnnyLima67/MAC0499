using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    [SerializeField] Transform topOfHead;
    [SerializeField] Transform bottomOfFeet;
    [SerializeField] Transform front;
    [SerializeField] Transform back;
    [SerializeField] Transform flippable;
    public bool allowCritFront = false;
    public bool allowCritBack = false;
    public bool allowCritUp = false;
    public bool allowCritDown = false;

    public bool IsPlayerCorrectPos(Transform player)
    {
        if (IsPlayerFront(player) && allowCritFront)
        {
            return true;
        }
        if (IsPlayerBack(player) && allowCritBack)
        {
            return true;
        }
        if (IsPlayerUp(player) && allowCritUp)
        {
            return true;
        }
        if (IsPlayerDown(player) && allowCritDown)
        {
            return true;
        }

        return false;
    }

    public bool IsHittable()
    {
        return true;
    }

    private bool IsPlayerFront(Transform player)
    {
        Vector3 result = new Vector3(0, 0, 0);

        if (!IsFlipped())
            result = player.position - front.position;
        else
            result = player.position - back.position;

        if ((result.x < 0 && !IsFlipped()) || (result.x > 0 && IsFlipped()))
        {
            return true;
        }

        return false;
    }

    private bool IsPlayerBack(Transform player)
    {
        Vector3 result = new Vector3(0, 0, 0);

        if (!IsFlipped())
            result = player.position - back.position;
        else
            result = player.position - front.position;

        if ((result.x > 0 && !IsFlipped()) || (result.x < 0 && IsFlipped()))
            return true;

        return false;
    }

    private bool IsPlayerUp(Transform player)
    {
        Vector3 result = player.position - topOfHead.position;

        if (result.y > 0)
            return true;

        return false;
    }

    private bool IsPlayerDown(Transform player)
    {
        Vector3 result = player.position - bottomOfFeet.position;

        if (result.y < 0)
            return true;

        return false;
    }

    private bool IsFlipped()
    {
        if (flippable.rotation.y == -180)
            return true;

        return false;
    }
}
