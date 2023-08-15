using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    [SerializeField] Enemy thisEnemy;
    [SerializeField] Transform topOfHead;
    [SerializeField] Transform bottomOfFeet;
    [SerializeField] Transform front;
    [SerializeField] Transform back;
    [SerializeField] Transform flippable;

    public bool IsPlayerFront(Transform player)
    {
        Vector3 result = new Vector3(0, 0, 0);

        if (!thisEnemy.IsFlipped())
            result = player.position - front.position;
        else
            result = player.position - back.position;

        if ((result.x < 0 && !thisEnemy.IsFlipped()) || (result.x > 0 && thisEnemy.IsFlipped()))
        {
            return true;
        }

        return false;
    }

    public bool IsPlayerBack(Transform player)
    {
        Vector3 result = new Vector3(0, 0, 0);

        if (!thisEnemy.IsFlipped())
            result = player.position - back.position;
        else
            result = player.position - front.position;

        if ((result.x > 0 && !thisEnemy.IsFlipped()) || (result.x < 0 && thisEnemy.IsFlipped()))
            return true;

        return false;
    }

    public bool IsPlayerUp(Transform player)
    {
        Vector3 result = player.position - topOfHead.position;

        if (result.y > 0)
            return true;

        return false;
    }

    public bool IsPlayerDown(Transform player)
    {
        Vector3 result = player.position - bottomOfFeet.position;

        if (result.y < 0)
            return true;

        return false;
    }

    public int WhichPlayerDirection(Transform player)
    {
        if (IsPlayerBack(player)) return 1;
        else if(IsPlayerFront(player)) return -1;
        else return 0;
    }
}
