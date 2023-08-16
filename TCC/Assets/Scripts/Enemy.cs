using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isFlipped = false;
    [SerializeField] GameObject flippableAssets;

    public void Flip()
    {
        Quaternion newRotation = flippableAssets.transform.rotation;

        if (isFlipped)
        {
            newRotation.y = 0.0f;
            isFlipped = false;
        }
        else
        {
            newRotation.y = -180.0f;
            isFlipped = true;
        }

        flippableAssets.transform.rotation = newRotation;
    }

    public bool IsFlipped()
    {
        return isFlipped;
    }
}
